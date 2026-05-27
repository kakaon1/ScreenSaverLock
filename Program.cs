namespace ScreenSaverLock;

static class Program
{
    internal static Icon AppIcon { get; private set; } = SystemIcons.Shield;

    [STAThread]
    static void Main()
    {
        using var mutex = new Mutex(true, "ScreenSaverLock_SingleInstance", out bool createdNew);
        if (!createdNew)
        {
            MessageBox.Show("ScreenSaverLock이 이미 실행 중입니다.", "알림",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ApplicationConfiguration.Initialize();

        // 앱 아이콘 생성 + 기본 배경 이미지 보장
        AppIcon = ResourceHelper.CreateAppIcon();
        ResourceHelper.EnsureDefaultImage();

        Application.Run(new MainForm());
    }
}
