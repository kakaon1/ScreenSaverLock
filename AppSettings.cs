using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Win32;

namespace ScreenSaverLock;

internal static class AppSettings
{
    private static readonly string SettingsPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ScreenSaverLock", "settings.json");

    private static SettingsData _data = Load();

    public static bool AutoStart
    {
        get => _data.AutoStart;
        set { _data.AutoStart = value; ApplyAutoStart(value); Save(); }
    }

    public static bool VerifyPassword(string password)
        => HashPassword(password).Equals(_data.PasswordHash, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// 비밀번호 변경. currentPassword가 현재 비밀번호와 일치해야만 변경된다.
    /// 반환값: 변경 성공 여부
    /// </summary>
    public static bool SetPassword(string currentPassword, string newPassword)
    {
        // 현재 비밀번호 항상 검증 (빈 값도 검증 대상)
        if (!VerifyPassword(currentPassword)) return false;
        if (string.IsNullOrWhiteSpace(newPassword)) return false;

        _data.PasswordHash = HashPassword(newPassword);
        Save();
        return true;
    }

    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }

    private static void ApplyAutoStart(bool enable)
    {
        const string AppName = "ScreenSaverLock";
        using var key = Registry.CurrentUser.OpenSubKey(
            @"Software\Microsoft\Windows\CurrentVersion\Run", writable: true);
        if (key == null) return;

        if (enable)
            key.SetValue(AppName, $"\"{Application.ExecutablePath}\"");
        else
            key.DeleteValue(AppName, throwOnMissingValue: false);
    }

    private static SettingsData Load()
    {
        try
        {
            if (File.Exists(SettingsPath))
            {
                var json = File.ReadAllText(SettingsPath);
                var d = JsonSerializer.Deserialize<SettingsData>(json);
                if (d != null && !string.IsNullOrEmpty(d.PasswordHash))
                    return d;
            }
        }
        catch { }
        return CreateDefault();
    }

    private static SettingsData CreateDefault()
    {
        var d = new SettingsData
        {
            PasswordHash = HashPassword("0000"),
            AutoStart = false
        };
        Save(d);
        return d;
    }

    private static void Save(SettingsData? d = null)
    {
        d ??= _data;
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath)!);
            File.WriteAllText(SettingsPath,
                JsonSerializer.Serialize(d, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch { }
    }

    private sealed class SettingsData
    {
        public string PasswordHash { get; set; } = "";
        public bool AutoStart { get; set; }
    }
}
