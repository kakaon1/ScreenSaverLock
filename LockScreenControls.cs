namespace ScreenSaverLock;

/// <summary>더블 버퍼링이 활성화된 Panel.</summary>
internal class DoubleBufferedPanel : System.Windows.Forms.Panel
{
    public DoubleBufferedPanel() => DoubleBuffered = true;
}

/// <summary>잠금 해제 버튼 스타일.</summary>
internal class FlatButton : System.Windows.Forms.Button
{
    public FlatButton()
    {
        FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        BackColor = System.Drawing.Color.FromArgb(55, 115, 210);
        ForeColor = System.Drawing.Color.White;
        Font      = new System.Drawing.Font("Segoe UI", 12F);
        FlatAppearance.BorderSize            = 0;
        FlatAppearance.MouseOverBackColor    = System.Drawing.Color.FromArgb(75, 135, 230);
        FlatAppearance.MouseDownBackColor    = System.Drawing.Color.FromArgb(40,  95, 190);
        Cursor    = System.Windows.Forms.Cursors.Default;
    }
}
