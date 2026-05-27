namespace ScreenSaverLock;

/// <summary>백그라운드 관리 폼 — 화면에 표시되지 않음. 트레이 아이콘 및 Ctrl+M 전역 단축키 담당.</summary>
internal sealed partial class MainForm : Form
{
    private const int HotkeyId = 1;

    private LockForm?    _lockForm;
    private ControlForm? _controlForm;

    public MainForm()
    {
        InitializeComponent();
        Location                   = new Point(-32000, -32000);
        Icon                       = Program.AppIcon;
        _trayIcon.Icon             = Program.AppIcon;
        _trayIcon.ContextMenuStrip = BuildContextMenu();
    }

    private void TrayIcon_DoubleClick(object? sender, EventArgs e)
        => OpenControlForm();

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        NativeMethods.RegisterHotKey(Handle, HotkeyId, NativeMethods.MOD_CONTROL, NativeMethods.VK_M);
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == NativeMethods.WM_HOTKEY && m.WParam.ToInt32() == HotkeyId)
        {
            ShowLockScreen();
            return;
        }
        base.WndProc(ref m);
    }

    public void ShowLockScreen()
    {
        if (_lockForm != null) return;
        _lockForm = new LockForm();
        _lockForm.FormClosed += (_, _) => _lockForm = null;
        _lockForm.Show();
    }

    private void OpenControlForm()
    {
        if (_controlForm != null)
        {
            if (_controlForm.WindowState == FormWindowState.Minimized)
                _controlForm.WindowState = FormWindowState.Normal;
            _controlForm.BringToFront();
            _controlForm.Activate();
            return;
        }
        _controlForm = new ControlForm(this);
        _controlForm.Icon       = Program.AppIcon;
        _controlForm.FormClosed += (_, _) => _controlForm = null;
        _controlForm.Show();
    }

    private ContextMenuStrip BuildContextMenu()
    {
        var menu = new ContextMenuStrip();

        var lockItem = new ToolStripMenuItem("지금 잠금  (Ctrl+M)")
        {
            Font = new Font(SystemFonts.MenuFont ?? SystemFonts.DefaultFont, FontStyle.Bold)
        };
        lockItem.Click += (_, _) => ShowLockScreen();

        var settingsItem = new ToolStripMenuItem("설정");
        settingsItem.Click += (_, _) => OpenControlForm();

        var exitItem = new ToolStripMenuItem("종료");
        exitItem.Click += (_, _) => ExitApp();

        menu.Items.Add(lockItem);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(settingsItem);
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add(exitItem);
        return menu;
    }

    public void ExitApp()
    {
        _trayIcon.Visible = false;
        NativeMethods.UnregisterHotKey(Handle, HotkeyId);
        Application.Exit();
    }
}
