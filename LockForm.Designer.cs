namespace ScreenSaverLock;

partial class LockForm
{
    /// <summary>
    /// 필수 디자이너 변수입니다.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    #region Windows Form 디자이너에서 생성한 코드

    /// <summary>
    /// 디자이너 지원에 필요한 메서드입니다.
    /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
    /// </summary>
    private void InitializeComponent()
    {
        this.components   = new System.ComponentModel.Container();
        this._pbSlideshow = new System.Windows.Forms.PictureBox();
        this._lockPanel   = new DoubleBufferedPanel();
        this._lblTitle    = new System.Windows.Forms.Label();
        this._sep1        = new System.Windows.Forms.Panel();
        this._lblTime     = new System.Windows.Forms.Label();
        this._lblDate     = new System.Windows.Forms.Label();
        this._sep2        = new System.Windows.Forms.Panel();
        this._lblHint     = new System.Windows.Forms.Label();
        this._txtPassword = new System.Windows.Forms.TextBox();
        this._sep3        = new System.Windows.Forms.Panel();
        this._lblStatus   = new System.Windows.Forms.Label();
        this._btnUnlock   = new FlatButton();
        this._clockTimer  = new System.Windows.Forms.Timer(this.components);
        this._slideTimer  = new System.Windows.Forms.Timer(this.components);
        this._blankTimer  = new System.Windows.Forms.Timer(this.components);
        ((System.ComponentModel.ISupportInitialize)(this._pbSlideshow)).BeginInit();
        this._lockPanel.SuspendLayout();
        this.SuspendLayout();
        //
        // _pbSlideshow
        //
        this._pbSlideshow.BackColor = System.Drawing.Color.Black;
        this._pbSlideshow.Location  = new System.Drawing.Point(0, 0);
        this._pbSlideshow.Name      = "_pbSlideshow";
        this._pbSlideshow.Size      = new System.Drawing.Size(1920, 1080);
        this._pbSlideshow.SizeMode  = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this._pbSlideshow.TabIndex  = 0;
        this._pbSlideshow.TabStop   = false;
        this._pbSlideshow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lockPanel
        //
        this._lockPanel.BackColor = System.Drawing.Color.FromArgb(22, 22, 35);
        this._lockPanel.Controls.Add(this._btnUnlock);
        this._lockPanel.Controls.Add(this._lblStatus);
        this._lockPanel.Controls.Add(this._sep3);
        this._lockPanel.Controls.Add(this._txtPassword);
        this._lockPanel.Controls.Add(this._lblHint);
        this._lockPanel.Controls.Add(this._sep2);
        this._lockPanel.Controls.Add(this._lblDate);
        this._lockPanel.Controls.Add(this._lblTime);
        this._lockPanel.Controls.Add(this._sep1);
        this._lockPanel.Controls.Add(this._lblTitle);
        this._lockPanel.Location  = new System.Drawing.Point(770, 414);
        this._lockPanel.Name      = "_lockPanel";
        this._lockPanel.Size      = new System.Drawing.Size(380, 360);
        this._lockPanel.TabIndex  = 1;
        this._lockPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
        this._lockPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lblTitle
        //
        this._lblTitle.BackColor  = System.Drawing.Color.Transparent;
        this._lblTitle.Font       = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this._lblTitle.ForeColor  = System.Drawing.Color.FromArgb(88, 126, 200);
        this._lblTitle.Location   = new System.Drawing.Point(0, 14);
        this._lblTitle.Name       = "_lblTitle";
        this._lblTitle.Size       = new System.Drawing.Size(380, 20);
        this._lblTitle.Text       = "LOCK SCREEN";
        this._lblTitle.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
        this._lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _sep1
        //
        this._sep1.BackColor = System.Drawing.Color.FromArgb(48, 48, 70);
        this._sep1.Location  = new System.Drawing.Point(20, 40);
        this._sep1.Name      = "_sep1";
        this._sep1.Size      = new System.Drawing.Size(340, 1);
        this._sep1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lblTime
        //
        this._lblTime.BackColor  = System.Drawing.Color.Transparent;
        this._lblTime.Font       = new System.Drawing.Font("Segoe UI", 52F);
        this._lblTime.ForeColor  = System.Drawing.Color.White;
        this._lblTime.Location   = new System.Drawing.Point(0, 42);
        this._lblTime.Name       = "_lblTime";
        this._lblTime.Size       = new System.Drawing.Size(380, 90);
        this._lblTime.Text       = "00:00";
        this._lblTime.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
        this._lblTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lblDate
        //
        this._lblDate.BackColor  = System.Drawing.Color.Transparent;
        this._lblDate.Font       = new System.Drawing.Font("Segoe UI", 12F);
        this._lblDate.ForeColor  = System.Drawing.Color.FromArgb(155, 155, 188);
        this._lblDate.Location   = new System.Drawing.Point(0, 132);
        this._lblDate.Name       = "_lblDate";
        this._lblDate.Size       = new System.Drawing.Size(380, 24);
        this._lblDate.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
        this._lblDate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _sep2
        //
        this._sep2.BackColor = System.Drawing.Color.FromArgb(48, 48, 70);
        this._sep2.Location  = new System.Drawing.Point(20, 162);
        this._sep2.Name      = "_sep2";
        this._sep2.Size      = new System.Drawing.Size(340, 1);
        this._sep2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lblHint
        //
        this._lblHint.BackColor  = System.Drawing.Color.Transparent;
        this._lblHint.Font       = new System.Drawing.Font("Segoe UI", 11F);
        this._lblHint.ForeColor  = System.Drawing.Color.FromArgb(115, 115, 145);
        this._lblHint.Location   = new System.Drawing.Point(0, 178);
        this._lblHint.Name       = "_lblHint";
        this._lblHint.Size       = new System.Drawing.Size(380, 22);
        this._lblHint.Text       = "비밀번호를 입력하세요";
        this._lblHint.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
        this._lblHint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _txtPassword
        //
        this._txtPassword.BackColor             = System.Drawing.Color.FromArgb(35, 35, 50);
        this._txtPassword.BorderStyle           = System.Windows.Forms.BorderStyle.None;
        this._txtPassword.Cursor                = System.Windows.Forms.Cursors.Default;
        this._txtPassword.Font                  = new System.Drawing.Font("Segoe UI", 14F);
        this._txtPassword.ForeColor             = System.Drawing.Color.White;
        this._txtPassword.Location              = new System.Drawing.Point(44, 206);
        this._txtPassword.Name                  = "_txtPassword";
        this._txtPassword.Size                  = new System.Drawing.Size(292, 30);
        this._txtPassword.TabIndex              = 0;
        this._txtPassword.TextAlign             = System.Windows.Forms.HorizontalAlignment.Center;
        this._txtPassword.UseSystemPasswordChar = true;
        this._txtPassword.KeyDown              += new System.Windows.Forms.KeyEventHandler(this.OnPasswordKeyDown);
        this._txtPassword.MouseMove            += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _sep3
        //
        this._sep3.BackColor = System.Drawing.Color.FromArgb(78, 108, 198);
        this._sep3.Location  = new System.Drawing.Point(44, 236);
        this._sep3.Name      = "_sep3";
        this._sep3.Size      = new System.Drawing.Size(292, 1);
        this._sep3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _lblStatus
        //
        this._lblStatus.BackColor  = System.Drawing.Color.Transparent;
        this._lblStatus.Font       = new System.Drawing.Font("Segoe UI", 11F);
        this._lblStatus.ForeColor  = System.Drawing.Color.FromArgb(255, 100, 100);
        this._lblStatus.Location   = new System.Drawing.Point(0, 250);
        this._lblStatus.Name       = "_lblStatus";
        this._lblStatus.Size       = new System.Drawing.Size(380, 20);
        this._lblStatus.TextAlign  = System.Drawing.ContentAlignment.MiddleCenter;
        this._lblStatus.Visible    = false;
        this._lblStatus.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _btnUnlock
        //
        this._btnUnlock.Location   = new System.Drawing.Point(90, 274);
        this._btnUnlock.Name       = "_btnUnlock";
        this._btnUnlock.Size       = new System.Drawing.Size(200, 42);
        this._btnUnlock.TabIndex   = 1;
        this._btnUnlock.Text       = "잠금 해제";
        this._btnUnlock.Click     += new System.EventHandler(this.BtnUnlock_Click);
        this._btnUnlock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        //
        // _clockTimer
        //
        this._clockTimer.Interval = 1000;
        this._clockTimer.Tick    += new System.EventHandler(this.ClockTimer_Tick);
        //
        // _slideTimer
        //
        this._slideTimer.Interval = 5000;
        this._slideTimer.Tick    += new System.EventHandler(this.SlideTimer_Tick);
        //
        // _blankTimer
        //
        this._blankTimer.Interval = 10000;
        this._blankTimer.Tick    += new System.EventHandler(this.BlankTimer_Tick);
        //
        // LockForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor           = System.Drawing.Color.Black;
        this.ClientSize          = new System.Drawing.Size(1920, 1080);
        this.Controls.Add(this._lockPanel);
        this.Controls.Add(this._pbSlideshow);
        this.FormBorderStyle     = System.Windows.Forms.FormBorderStyle.None;
        this.KeyPreview          = true;
        this.Name                = "LockForm";
        this.ShowInTaskbar       = false;
        this.StartPosition       = System.Windows.Forms.FormStartPosition.Manual;
        this.TopMost             = true;
        this.Load               += new System.EventHandler(this.OnLoad);
        this.Shown              += new System.EventHandler(this.OnShown);
        this.FormClosed         += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
        this.KeyDown            += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
        this.MouseMove          += new System.Windows.Forms.MouseEventHandler(this.OnUserActivity);
        ((System.ComponentModel.ISupportInitialize)(this._pbSlideshow)).EndInit();
        this._lockPanel.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.PictureBox _pbSlideshow;
    private DoubleBufferedPanel             _lockPanel;
    private System.Windows.Forms.Label      _lblTitle;
    private System.Windows.Forms.Panel      _sep1;
    private System.Windows.Forms.Label      _lblTime;
    private System.Windows.Forms.Label      _lblDate;
    private System.Windows.Forms.Panel      _sep2;
    private System.Windows.Forms.Label      _lblHint;
    private System.Windows.Forms.TextBox    _txtPassword;
    private System.Windows.Forms.Panel      _sep3;
    private System.Windows.Forms.Label      _lblStatus;
    private FlatButton                      _btnUnlock;
    private System.Windows.Forms.Timer      _clockTimer;
    private System.Windows.Forms.Timer      _slideTimer;
    private System.Windows.Forms.Timer      _blankTimer;
}
