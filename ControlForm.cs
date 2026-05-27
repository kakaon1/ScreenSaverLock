using System.Drawing.Drawing2D;

namespace ScreenSaverLock;

/// <summary>트레이 아이콘 더블클릭 시 표시되는 설정 GUI 폼.</summary>
internal sealed partial class ControlForm : Form
{
    private static readonly Color BgMain     = Color.FromArgb(28,  28,  40);
    private static readonly Color AccentBlue = Color.FromArgb(52, 110, 200);
    private static readonly Color TextPri    = Color.FromArgb(225, 225, 238);
    private static readonly Color TextSec    = Color.FromArgb(135, 135, 160);

    private readonly MainForm _main;

    public ControlForm() : this(null!) { } // Visual Studio 디자이너 전용

    public ControlForm(MainForm main)
    {
        _main = main;
        InitializeComponent();

        // Checked 초기값은 이벤트 발화를 막기 위해 구독 후 별도 설정
        _chkAutoStart.CheckedChanged -= ChkAutoStart_CheckedChanged;
        _chkAutoStart.Checked         = AppSettings.AutoStart;
        _chkAutoStart.CheckedChanged += ChkAutoStart_CheckedChanged;
    }

    // ── Designer.cs에서 참조하는 이벤트 핸들러 ──

    private void BtnLock_Click(object? sender, EventArgs e)
    {
        Hide();
        _main.ShowLockScreen();
    }

    private void ChkAutoStart_CheckedChanged(object? sender, EventArgs e)
        => AppSettings.AutoStart = _chkAutoStart.Checked;

    private void BtnExit_Click(object? sender, EventArgs e)
        => _main.ExitApp();

    // ── 헤더 배경 커스텀 페인트 ──
    private void OnHeaderPaint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        using var circleBrush = new SolidBrush(AccentBlue);
        g.FillEllipse(circleBrush, 14, 12, 40, 40);

        DrawMiniLock(g, 14, 12, 40, 40);

        using var titleFont  = new Font("Segoe UI", 14, FontStyle.Bold);
        using var titleBrush = new SolidBrush(TextPri);
        g.DrawString("ScreenSaverLock", titleFont, titleBrush, 64, 12);

        using var subFont  = new Font("Segoe UI", 9);
        using var subBrush = new SolidBrush(Color.FromArgb(135, 135, 160));
        g.DrawString("화면 보안 잠금 프로그램", subFont, subBrush, 65, 38);
    }

    private static void DrawMiniLock(Graphics g, int bx, int by, int bw, int bh)
    {
        using var wBrush = new SolidBrush(Color.White);
        using var wPen   = new Pen(Color.White, 2.5f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

        int bodyH = (int)(bh * 0.48f);
        int bodyY = by + bh - bodyH;
        using var bodyPath = RoundRect(bx + 8, bodyY, bw - 16, bodyH, 5);
        g.FillPath(wBrush, bodyPath);

        int shW = bw - 20;
        g.DrawArc(wPen, bx + 10, by + 4, shW, shW, 180, 180);
    }

    // ── 비밀번호 변경 처리 ──
    private void OnChangePassword(object? sender, EventArgs e)
    {
        _lblPwStatus.ForeColor = Color.FromArgb(255, 100, 100);
        _lblPwStatus.Visible   = false;

        if (string.IsNullOrWhiteSpace(_txtNew.Text))
        {
            ShowStatus("새 비밀번호를 입력하세요.", isError: true);
            return;
        }
        if (!AppSettings.SetPassword(_txtCurrent.Text, _txtNew.Text))
        {
            ShowStatus("현재 비밀번호가 올바르지 않습니다.", isError: true);
            return;
        }

        _txtCurrent.Clear();
        _txtNew.Clear();
        ShowStatus("비밀번호가 변경되었습니다.", isError: false);
    }

    private void ShowStatus(string msg, bool isError)
    {
        _lblPwStatus.ForeColor = isError
            ? Color.FromArgb(255, 100, 100)
            : Color.FromArgb(80, 200, 120);
        _lblPwStatus.Text    = msg;
        _lblPwStatus.Visible = true;
    }

    private static GraphicsPath RoundRect(int x, int y, int w, int h, int r)
    {
        r = Math.Min(r, Math.Min(w, h) / 2);
        var p = new GraphicsPath();
        p.AddArc(x, y, r * 2, r * 2, 180, 90);
        p.AddArc(x + w - r * 2, y, r * 2, r * 2, 270, 90);
        p.AddArc(x + w - r * 2, y + h - r * 2, r * 2, r * 2, 0, 90);
        p.AddArc(x, y + h - r * 2, r * 2, r * 2, 90, 90);
        p.CloseAllFigures();
        return p;
    }
}
