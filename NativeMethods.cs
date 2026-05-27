using System.Runtime.InteropServices;

namespace ScreenSaverLock;

internal static class NativeMethods
{
    [StructLayout(LayoutKind.Sequential)]
    private struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }

    [DllImport("user32.dll")]
    private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

    public static uint GetIdleTimeMs()
    {
        var info = new LASTINPUTINFO { cbSize = (uint)Marshal.SizeOf<LASTINPUTINFO>() };
        if (GetLastInputInfo(ref info))
            return unchecked((uint)Environment.TickCount - info.dwTime);
        return 0;
    }

    // AND=1 XOR=0인 모든 픽셀 → 완전 투명 커서 생성 (보이지 않는 커서)
    [DllImport("user32.dll")]
    public static extern IntPtr CreateCursor(IntPtr hInst, int xHotSpot, int yHotSpot,
        int nWidth, int nHeight, byte[] pvANDPlane, byte[] pvXORPlane);

    [DllImport("user32.dll")]
    public static extern bool DestroyCursor(IntPtr hCursor);

    [DllImport("user32.dll")]
    public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    public const uint MOD_CONTROL = 0x0002;
    public const uint VK_M = 0x4D;
    public const int WM_HOTKEY = 0x0312;
    public const int WM_SYSCOMMAND = 0x0112;
    public const int SC_CLOSE = 0xF060;
    public const int SC_SCREENSAVE = 0xF140;
}
