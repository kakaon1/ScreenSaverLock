using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace ScreenSaverLock;

/// <summary>앱 아이콘 및 기본 잠금 배경 이미지를 런타임에 생성한다.</summary>
internal static class ResourceHelper
{
    private static readonly string ImageFolder =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "이미지");

    // ─────────────────────────────────────────────
    // 앱 아이콘
    // ─────────────────────────────────────────────

    public static Icon CreateAppIcon()
    {
        using var bmp = new Bitmap(64, 64);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        g.Clear(Color.Transparent);

        // 파란 원 배경
        using var bgBrush = new SolidBrush(Color.FromArgb(52, 110, 200));
        g.FillEllipse(bgBrush, 1, 1, 62, 62);

        // 흰색 자물쇠
        DrawLockSymbol(g, Color.White, Color.FromArgb(52, 110, 200), 12, 8, 40, 48);

        return BitmapToIcon(bmp);
    }

    // ─────────────────────────────────────────────
    // 기본 배경 이미지 (없을 때 자동 생성)
    // ─────────────────────────────────────────────

    public static void EnsureDefaultImage()
    {
        Directory.CreateDirectory(ImageFolder);
        // 기본 배경은 항상 최신 디자인으로 재생성 (사용자 추가 이미지에는 영향 없음)
        GenerateLockBackground();
    }

    private static void GenerateLockBackground()
    {
        const int W = 1920, H = 1080;
        using var bmp = new Bitmap(W, H);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAlias;

        // ── 배경: 하늘색 그라디언트 ──
        using (var bg = new LinearGradientBrush(
            new Rectangle(0, 0, W, H),
            Color.FromArgb(0x55, 0xC9, 0xED),
            Color.FromArgb(0x28, 0x9E, 0xD4),
            90f))
        {
            g.FillRectangle(bg, 0, 0, W, H);
        }

        // 배경 원 장식 (은은하게)
        using (var cb = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
        {
            g.FillEllipse(cb, -180, -180, 680, 680);
            g.FillEllipse(cb, W - 380, H - 380, 560, 560);
            g.FillEllipse(cb, W - 200, -100, 400, 400);
        }

        // ── 자물쇠 아이콘: 화면 30% 위치 중앙 ──
        // 패널이 화면 55%에 배치되므로 아이콘은 그 위에 위치함
        int cx = W / 2;
        int iconCy = (int)(H * 0.30);
        DrawLockSymbol(g, Color.White, Color.FromArgb(0x46, 0xBA, 0xE0),
            cx - 90, iconCy - 110, 180, 210);

        // 아이콘 아래 힌트 텍스트 (패널과 겹치지 않는 위치)
        using var hintFont = new Font("Malgun Gothic", 24, FontStyle.Regular, GraphicsUnit.Pixel);
        using var hintBrush = new SolidBrush(Color.FromArgb(190, 255, 255, 255));
        var sf = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        g.DrawString("Ctrl+M", hintFont, hintBrush,
            (float)cx, (float)(iconCy + 130), sf);

        string outPath = Path.Combine(ImageFolder, "기본배경.png");
        bmp.Save(outPath, ImageFormat.Png);
    }

    // ─────────────────────────────────────────────
    // GDI+ 헬퍼
    // ─────────────────────────────────────────────

    /// <summary>자물쇠 기호를 그린다. (x,y)는 좌상단, w×h가 전체 크기.</summary>
    private static void DrawLockSymbol(Graphics g, Color fill, Color hole,
        int x, int y, int w, int h)
    {
        float lineW = Math.Max(2, w / 9f);
        using var pen = new Pen(fill, lineW)
            { StartCap = LineCap.Round, EndCap = LineCap.Round };
        using var fillBrush = new SolidBrush(fill);
        using var holeBrush = new SolidBrush(hole);

        // 자물쇠 몸체
        int bodyH = (int)(h * 0.56f);
        int bodyY = y + h - bodyH;
        using var bodyPath = RoundRect(x, bodyY, w, bodyH, (int)(w * 0.14f));
        g.FillPath(fillBrush, bodyPath);

        // 고리 (shackle)
        int shW = (int)(w * 0.46f);
        int shX = x + (w - shW) / 2;
        int shH = (int)(h * 0.52f);
        g.DrawArc(pen, shX, y, shW, shH * 2, 180, 180);

        // 열쇠구멍
        float ks = w * 0.18f;
        float kx = x + (w - ks) / 2f;
        float ky = bodyY + bodyH * 0.18f;
        g.FillEllipse(holeBrush, kx, ky, ks, ks);
        g.FillRectangle(holeBrush, kx + ks * 0.3f, ky + ks * 0.72f, ks * 0.4f, ks * 0.62f);
    }

    private static void DrawRoundRect(Graphics g, Pen pen, int x, int y, int w, int h, int r)
    {
        using var path = RoundRect(x, y, w, h, r);
        g.DrawPath(pen, path);
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

    // ─────────────────────────────────────────────
    // Bitmap → ICO 변환
    // ─────────────────────────────────────────────

    private static Icon BitmapToIcon(Bitmap bmp)
    {
        using var ms = new MemoryStream();

        // ICO 헤더 (6바이트)
        WriteWord(ms, 0);   // Reserved
        WriteWord(ms, 1);   // Type: ICO
        WriteWord(ms, 1);   // Images count

        // ICO 디렉터리 엔트리 (16바이트)
        ms.WriteByte((byte)(bmp.Width > 255 ? 0 : bmp.Width));
        ms.WriteByte((byte)(bmp.Height > 255 ? 0 : bmp.Height));
        ms.WriteByte(0);  // palette
        ms.WriteByte(0);  // reserved
        WriteWord(ms, 1);  // planes
        WriteWord(ms, 32); // bpp

        using var imgStream = new MemoryStream();
        bmp.Save(imgStream, ImageFormat.Png);
        var imgBytes = imgStream.ToArray();

        WriteDword(ms, imgBytes.Length);
        WriteDword(ms, 22); // offset = 6 (header) + 16 (entry) = 22

        ms.Write(imgBytes, 0, imgBytes.Length);

        ms.Position = 0;
        return new Icon(ms);
    }

    private static void WriteWord(Stream s, int v)
    {
        s.WriteByte((byte)(v & 0xFF));
        s.WriteByte((byte)((v >> 8) & 0xFF));
    }

    private static void WriteDword(Stream s, int v)
    {
        s.WriteByte((byte)(v & 0xFF));
        s.WriteByte((byte)((v >> 8) & 0xFF));
        s.WriteByte((byte)((v >> 16) & 0xFF));
        s.WriteByte((byte)((v >> 24) & 0xFF));
    }
}
