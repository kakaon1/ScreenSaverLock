namespace ScreenSaverLock;

partial class MainForm
{
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// 사용 중인 모든 리소스를 정리합니다.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다.
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this._trayIcon  = new System.Windows.Forms.NotifyIcon(this.components);
        //
        // _trayIcon
        //
        this._trayIcon.Text    = "ScreenSaverLock\n단축키: Ctrl+M";
        this._trayIcon.Visible = true;
        this._trayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize          = new System.Drawing.Size(1, 1);
        this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
        this.Name                = "MainForm";
        this.Opacity             = 0D;
        this.ShowInTaskbar       = false;
        this.StartPosition       = System.Windows.Forms.FormStartPosition.Manual;
        this.Text                = "ScreenSaverLock";
    }

    #endregion

    private System.Windows.Forms.NotifyIcon _trayIcon;
}
