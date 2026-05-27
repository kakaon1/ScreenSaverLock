using System.Drawing.Drawing2D;

namespace ScreenSaverLock;

internal sealed partial class LockForm : Form
{
    private static readonly string ImageFolder =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "이미지");

    private static readonly string[] ImageExtensions =
        [".jpg", ".jpeg", ".png", ".bmp", ".gif"];

    // 블랭크 상태 전용 투명 커서 (AND=1 XOR=0 → 완전 투명)
    private static readonly Cursor BlankCursor = CreateBlankCursor();

    private string[] _imageFiles = [];
    private int      _imageIndex;
    private Bitmap?  _currentBitmap;
    private bool     _isBlank;
    private Point    _lastMousePos = new Point(int.MinValue, int.MinValue);

    public LockForm()
    {
        InitializeComponent();
        _lockPanel.Region = BuildRoundedRegion(_lockPanel.Width, _lockPanel.Height, 16);
    }

    private static Cursor CreateBlankCursor()
    {
        const int w = 32, h = 32;
        var and = new byte[w / 8 * h];
        var xor = new byte[w / 8 * h];
        Array.Fill(and, (byte)0xFF);
        return new Cursor(NativeMethods.CreateCursor(IntPtr.Zero, 0, 0, w, h, and, xor));
    }

    // ──────────────── 초기화 ────────────────

    private void OnLoad(object? sender, EventArgs e)
    {
        // 런타임에서만 결정되는 화면 크기 기반 배치
        var vs = SystemInformation.VirtualScreen;
        Bounds             = vs;
        _pbSlideshow.Size  = vs.Size;

        const int panelW = 380, panelH = 390;
        var ps = Screen.PrimaryScreen!.Bounds;
        _lockPanel.Location = new Point(
            (ps.X - vs.X) + (ps.Width  - panelW) / 2,
            (ps.Y - vs.Y) + (int)(ps.Height * 0.55f) - panelH / 2);

        UpdateClock();
        _clockTimer.Start();

        _imageFiles = ScanImageFiles();
        if (_imageFiles.Length > 0)
        {
            ShowSlide(0);
            if (_imageFiles.Length > 1) _slideTimer.Start();
        }
    }

    private void OnShown(object? sender, EventArgs e)
    {
        BeginInvoke(() =>
        {
            Activate();
            _txtPassword.Focus();
            _blankTimer.Start();
        });
    }

    private void OnFormClosed(object? sender, FormClosedEventArgs e)
    {
        _clockTimer.Stop();
        _slideTimer.Stop();
        _blankTimer.Stop();
        DisposeCurrentBitmap();
    }

    // ──────────────── 타이머 핸들러 ────────────────

    private void ClockTimer_Tick(object? sender, EventArgs e) => UpdateClock();
    private void SlideTimer_Tick(object? sender, EventArgs e) => AdvanceSlide();
    private void BlankTimer_Tick(object? sender, EventArgs e) => OnBlankTimerTick();
    private void BtnUnlock_Click(object? sender, EventArgs e) => TryUnlock();

    // ──────────────── 블랭크 (절전 모드) ────────────────

    private void OnBlankTimerTick()
    {
        _blankTimer.Stop();
        _isBlank             = true;
        _pbSlideshow.Visible = false;
        _lockPanel.Visible   = false;
        Cursor               = BlankCursor;
    }

    private void OnUserActivity(object? sender, EventArgs e)
    {
        // MouseMove는 실제 커서 위치가 바뀔 때만 처리 (합성 WM_MOUSEMOVE 무시)
        if (e is MouseEventArgs)
        {
            var pos = Cursor.Position;
            if (pos == _lastMousePos) return;
            _lastMousePos = pos;
        }

        if (_isBlank)
        {
            _isBlank             = false;
            _pbSlideshow.Visible = true;
            _lockPanel.Visible   = true;
            _lblStatus.Visible   = false;
            Cursor               = Cursors.Default;
            BeginInvoke(() => { Activate(); _txtPassword.Focus(); });
        }
        _blankTimer.Stop();
        _blankTimer.Start();
    }

    // ──────────────── 시계 ────────────────

    private void UpdateClock()
    {
        var now = DateTime.Now;
        _lblTime.Text = now.ToString("HH:mm");
        _lblDate.Text = now.ToString("yyyy년 MM월 dd일 (ddd)");
    }

    // ──────────────── 슬라이드쇼 ────────────────

    private string[] ScanImageFiles()
    {
        if (!Directory.Exists(ImageFolder)) return [];
        return Directory.GetFiles(ImageFolder)
            .Where(f => ImageExtensions.Contains(
                Path.GetExtension(f).ToLowerInvariant()))
            .OrderBy(f => f, StringComparer.OrdinalIgnoreCase)
            .ToArray();
    }

    private void ShowSlide(int index)
    {
        if (_imageFiles.Length == 0) return;
        _imageIndex = index % _imageFiles.Length;
        var bmp = LoadImageSafely(_imageFiles[_imageIndex]);
        if (bmp == null) return;
        var old = _currentBitmap;
        _currentBitmap     = bmp;
        _pbSlideshow.Image = _currentBitmap;
        old?.Dispose();
    }

    private void AdvanceSlide()
        => ShowSlide((_imageIndex + 1) % _imageFiles.Length);

    private void DisposeCurrentBitmap()
    {
        _pbSlideshow.Image = null;
        _currentBitmap?.Dispose();
        _currentBitmap = null;
    }

    private static Bitmap? LoadImageSafely(string path)
    {
        try { using var s = Image.FromFile(path); return new Bitmap(s); }
        catch { return null; }
    }

    // ──────────────── 잠금 해제 ────────────────

    private void TryUnlock()
    {
        if (AppSettings.VerifyPassword(_txtPassword.Text))
        {
            Close();
            return;
        }
        _lblStatus.Text    = "비밀번호가 올바르지 않습니다.";
        _lblStatus.Visible = true;
        _txtPassword.Clear();
        _txtPassword.Focus();
    }

    // ──────────────── 이벤트 핸들러 ────────────────

    private void OnPasswordKeyDown(object? sender, KeyEventArgs e)
    {
        OnUserActivity(sender, e);
        _lblStatus.Visible = false;
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            TryUnlock();
        }
    }

    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        OnUserActivity(sender, e);

        if (e.KeyCode is Keys.LWin or Keys.RWin)
        { e.Handled = true; e.SuppressKeyPress = true; }

        if (e.Alt && e.KeyCode == Keys.Tab)
        { e.Handled = true; e.SuppressKeyPress = true; }

        if (e.Alt && e.KeyCode == Keys.F4)
        { e.Handled = true; e.SuppressKeyPress = true; }
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == NativeMethods.WM_SYSCOMMAND)
        {
            int cmd = m.WParam.ToInt32() & 0xFFF0;
            if (cmd == NativeMethods.SC_CLOSE || cmd == NativeMethods.SC_SCREENSAVE)
                return;
        }
        base.WndProc(ref m);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
            DisposeCurrentBitmap();
        }
        base.Dispose(disposing);
    }

    // ──────────────── UI 헬퍼 ────────────────

    private static Region BuildRoundedRegion(int w, int h, int r)
    {
        using var path = new GraphicsPath();
        path.AddArc(0, 0, r * 2, r * 2, 180, 90);
        path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
        path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
        path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
        path.CloseAllFigures();
        return new Region(path);
    }

    private void OnPanelPaint(object? sender, PaintEventArgs e)
    {
        if (sender is not Control c) return;
        const int r = 15;
        int w = c.Width - 1, h = c.Height - 1;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using var path = new GraphicsPath();
        path.AddArc(0, 0, r * 2, r * 2, 180, 90);
        path.AddArc(w - r * 2, 0, r * 2, r * 2, 270, 90);
        path.AddArc(w - r * 2, h - r * 2, r * 2, r * 2, 0, 90);
        path.AddArc(0, h - r * 2, r * 2, r * 2, 90, 90);
        path.CloseAllFigures();
        using var pen = new Pen(Color.FromArgb(60, 115, 170, 255), 1.5f);
        e.Graphics.DrawPath(pen, path);
    }
}
