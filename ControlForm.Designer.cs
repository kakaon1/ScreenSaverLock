namespace ScreenSaverLock;

partial class ControlForm
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
        this.components          = new System.ComponentModel.Container();
        this._headerPanel        = new System.Windows.Forms.Panel();
        this._lblSection1        = new System.Windows.Forms.Label();
        this._lblInfo1           = new System.Windows.Forms.Label();
        this._btnLock            = new System.Windows.Forms.Button();
        this._div1               = new System.Windows.Forms.Panel();
        this._lblSection2        = new System.Windows.Forms.Label();
        this._chkAutoStart       = new System.Windows.Forms.CheckBox();
        this._div2               = new System.Windows.Forms.Panel();
        this._lblSection3        = new System.Windows.Forms.Label();
        this._lblInfo2           = new System.Windows.Forms.Label();
        this._lblPwCurrentLabel  = new System.Windows.Forms.Label();
        this._txtCurrent         = new System.Windows.Forms.TextBox();
        this._lblPwNewLabel      = new System.Windows.Forms.Label();
        this._txtNew             = new System.Windows.Forms.TextBox();
        this._lblPwStatus        = new System.Windows.Forms.Label();
        this._btnChangePw        = new System.Windows.Forms.Button();
        this._div3               = new System.Windows.Forms.Panel();
        this._btnExit            = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // _headerPanel
        //
        this._headerPanel.BackColor = System.Drawing.Color.FromArgb(18, 18, 28);
        this._headerPanel.Dock      = System.Windows.Forms.DockStyle.Top;
        this._headerPanel.Name      = "_headerPanel";
        this._headerPanel.Size      = new System.Drawing.Size(430, 64);
        this._headerPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnHeaderPaint);
        //
        // _lblSection1
        //
        this._lblSection1.AutoSize  = true;
        this._lblSection1.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblSection1.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this._lblSection1.ForeColor = System.Drawing.Color.FromArgb(52, 110, 200);
        this._lblSection1.Location  = new System.Drawing.Point(22, 76);
        this._lblSection1.Name      = "_lblSection1";
        this._lblSection1.Text      = "잠금";
        //
        // _lblInfo1
        //
        this._lblInfo1.AutoSize  = true;
        this._lblInfo1.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblInfo1.ForeColor = System.Drawing.Color.FromArgb(135, 135, 160);
        this._lblInfo1.Location  = new System.Drawing.Point(22, 98);
        this._lblInfo1.Name      = "_lblInfo1";
        this._lblInfo1.Text      = "전역 단축키 :  Ctrl + M";
        //
        // _btnLock
        //
        this._btnLock.BackColor  = System.Drawing.Color.FromArgb(52, 110, 200);
        this._btnLock.Cursor     = System.Windows.Forms.Cursors.Hand;
        this._btnLock.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
        this._btnLock.FlatAppearance.BorderSize = 0;
        this._btnLock.Font       = new System.Drawing.Font("Segoe UI", 10F);
        this._btnLock.ForeColor  = System.Drawing.Color.White;
        this._btnLock.Location   = new System.Drawing.Point(22, 120);
        this._btnLock.Name       = "_btnLock";
        this._btnLock.Size       = new System.Drawing.Size(170, 36);
        this._btnLock.TabIndex   = 0;
        this._btnLock.Text       = "지금 잠금";
        this._btnLock.Click     += new System.EventHandler(this.BtnLock_Click);
        //
        // _div1
        //
        this._div1.BackColor = System.Drawing.Color.FromArgb(50, 50, 72);
        this._div1.Location  = new System.Drawing.Point(0, 168);
        this._div1.Name      = "_div1";
        this._div1.Size      = new System.Drawing.Size(430, 1);
        //
        // _lblSection2
        //
        this._lblSection2.AutoSize  = true;
        this._lblSection2.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblSection2.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this._lblSection2.ForeColor = System.Drawing.Color.FromArgb(52, 110, 200);
        this._lblSection2.Location  = new System.Drawing.Point(22, 182);
        this._lblSection2.Name      = "_lblSection2";
        this._lblSection2.Text      = "일반 설정";
        //
        // _chkAutoStart
        //
        this._chkAutoStart.AutoSize  = true;
        this._chkAutoStart.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._chkAutoStart.Cursor    = System.Windows.Forms.Cursors.Hand;
        this._chkAutoStart.ForeColor = System.Drawing.Color.FromArgb(225, 225, 238);
        this._chkAutoStart.Location  = new System.Drawing.Point(22, 206);
        this._chkAutoStart.Name      = "_chkAutoStart";
        this._chkAutoStart.TabIndex  = 1;
        this._chkAutoStart.Text      = "Windows 시작 시 자동 실행";
        this._chkAutoStart.CheckedChanged += new System.EventHandler(this.ChkAutoStart_CheckedChanged);
        //
        // _div2
        //
        this._div2.BackColor = System.Drawing.Color.FromArgb(50, 50, 72);
        this._div2.Location  = new System.Drawing.Point(0, 240);
        this._div2.Name      = "_div2";
        this._div2.Size      = new System.Drawing.Size(430, 1);
        //
        // _lblSection3
        //
        this._lblSection3.AutoSize  = true;
        this._lblSection3.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblSection3.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this._lblSection3.ForeColor = System.Drawing.Color.FromArgb(52, 110, 200);
        this._lblSection3.Location  = new System.Drawing.Point(22, 254);
        this._lblSection3.Name      = "_lblSection3";
        this._lblSection3.Text      = "비밀번호 변경";
        //
        // _lblInfo2
        //
        this._lblInfo2.AutoSize  = true;
        this._lblInfo2.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblInfo2.ForeColor = System.Drawing.Color.FromArgb(135, 135, 160);
        this._lblInfo2.Location  = new System.Drawing.Point(22, 278);
        this._lblInfo2.Name      = "_lblInfo2";
        this._lblInfo2.Text      = "※ 기본 비밀번호: 0000";
        //
        // _lblPwCurrentLabel
        //
        this._lblPwCurrentLabel.AutoSize  = true;
        this._lblPwCurrentLabel.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblPwCurrentLabel.ForeColor = System.Drawing.Color.FromArgb(135, 135, 160);
        this._lblPwCurrentLabel.Location  = new System.Drawing.Point(22, 300);
        this._lblPwCurrentLabel.Name      = "_lblPwCurrentLabel";
        this._lblPwCurrentLabel.Text      = "현재 비밀번호";
        //
        // _txtCurrent
        //
        this._txtCurrent.BackColor             = System.Drawing.Color.FromArgb(38, 38, 55);
        this._txtCurrent.BorderStyle           = System.Windows.Forms.BorderStyle.FixedSingle;
        this._txtCurrent.Font                  = new System.Drawing.Font("Segoe UI", 10F);
        this._txtCurrent.ForeColor             = System.Drawing.Color.FromArgb(225, 225, 238);
        this._txtCurrent.Location              = new System.Drawing.Point(22, 320);
        this._txtCurrent.Name                  = "_txtCurrent";
        this._txtCurrent.Size                  = new System.Drawing.Size(386, 26);
        this._txtCurrent.TabIndex              = 2;
        this._txtCurrent.UseSystemPasswordChar = true;
        //
        // _lblPwNewLabel
        //
        this._lblPwNewLabel.AutoSize  = true;
        this._lblPwNewLabel.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblPwNewLabel.ForeColor = System.Drawing.Color.FromArgb(135, 135, 160);
        this._lblPwNewLabel.Location  = new System.Drawing.Point(22, 352);
        this._lblPwNewLabel.Name      = "_lblPwNewLabel";
        this._lblPwNewLabel.Text      = "새 비밀번호";
        //
        // _txtNew
        //
        this._txtNew.BackColor             = System.Drawing.Color.FromArgb(38, 38, 55);
        this._txtNew.BorderStyle           = System.Windows.Forms.BorderStyle.FixedSingle;
        this._txtNew.Font                  = new System.Drawing.Font("Segoe UI", 10F);
        this._txtNew.ForeColor             = System.Drawing.Color.FromArgb(225, 225, 238);
        this._txtNew.Location              = new System.Drawing.Point(22, 372);
        this._txtNew.Name                  = "_txtNew";
        this._txtNew.Size                  = new System.Drawing.Size(386, 26);
        this._txtNew.TabIndex              = 3;
        this._txtNew.UseSystemPasswordChar = true;
        //
        // _lblPwStatus
        //
        this._lblPwStatus.AutoSize  = true;
        this._lblPwStatus.BackColor = System.Drawing.Color.FromArgb(28, 28, 40);
        this._lblPwStatus.ForeColor = System.Drawing.Color.FromArgb(255, 100, 100);
        this._lblPwStatus.Location  = new System.Drawing.Point(22, 404);
        this._lblPwStatus.Name      = "_lblPwStatus";
        this._lblPwStatus.Visible   = false;
        //
        // _btnChangePw
        //
        this._btnChangePw.BackColor  = System.Drawing.Color.FromArgb(52, 110, 200);
        this._btnChangePw.Cursor     = System.Windows.Forms.Cursors.Hand;
        this._btnChangePw.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
        this._btnChangePw.FlatAppearance.BorderSize = 0;
        this._btnChangePw.Font       = new System.Drawing.Font("Segoe UI", 10F);
        this._btnChangePw.ForeColor  = System.Drawing.Color.White;
        this._btnChangePw.Location   = new System.Drawing.Point(22, 426);
        this._btnChangePw.Name       = "_btnChangePw";
        this._btnChangePw.Size       = new System.Drawing.Size(160, 34);
        this._btnChangePw.TabIndex   = 4;
        this._btnChangePw.Text       = "비밀번호 변경";
        this._btnChangePw.Click     += new System.EventHandler(this.OnChangePassword);
        //
        // _div3
        //
        this._div3.BackColor = System.Drawing.Color.FromArgb(50, 50, 72);
        this._div3.Location  = new System.Drawing.Point(0, 472);
        this._div3.Name      = "_div3";
        this._div3.Size      = new System.Drawing.Size(430, 1);
        //
        // _btnExit
        //
        this._btnExit.BackColor  = System.Drawing.Color.FromArgb(155, 45, 45);
        this._btnExit.Cursor     = System.Windows.Forms.Cursors.Hand;
        this._btnExit.FlatStyle  = System.Windows.Forms.FlatStyle.Flat;
        this._btnExit.FlatAppearance.BorderSize = 0;
        this._btnExit.Font       = new System.Drawing.Font("Segoe UI", 10F);
        this._btnExit.ForeColor  = System.Drawing.Color.White;
        this._btnExit.Location   = new System.Drawing.Point(22, 486);
        this._btnExit.Name       = "_btnExit";
        this._btnExit.Size       = new System.Drawing.Size(150, 34);
        this._btnExit.TabIndex   = 5;
        this._btnExit.Text       = "프로그램 종료";
        this._btnExit.Click     += new System.EventHandler(this.BtnExit_Click);
        //
        // ControlForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor           = System.Drawing.Color.FromArgb(28, 28, 40);
        this.ClientSize          = new System.Drawing.Size(430, 530);
        this.Controls.Add(this._btnExit);
        this.Controls.Add(this._div3);
        this.Controls.Add(this._btnChangePw);
        this.Controls.Add(this._lblPwStatus);
        this.Controls.Add(this._txtNew);
        this.Controls.Add(this._lblPwNewLabel);
        this.Controls.Add(this._txtCurrent);
        this.Controls.Add(this._lblPwCurrentLabel);
        this.Controls.Add(this._lblInfo2);
        this.Controls.Add(this._lblSection3);
        this.Controls.Add(this._div2);
        this.Controls.Add(this._chkAutoStart);
        this.Controls.Add(this._lblSection2);
        this.Controls.Add(this._div1);
        this.Controls.Add(this._btnLock);
        this.Controls.Add(this._lblInfo1);
        this.Controls.Add(this._lblSection1);
        this.Controls.Add(this._headerPanel);
        this.Font            = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor       = System.Drawing.Color.FromArgb(225, 225, 238);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox     = false;
        this.Name            = "ControlForm";
        this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text            = "ScreenSaverLock 설정";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Panel    _headerPanel;
    private System.Windows.Forms.Label    _lblSection1;
    private System.Windows.Forms.Label    _lblInfo1;
    private System.Windows.Forms.Button   _btnLock;
    private System.Windows.Forms.Panel    _div1;
    private System.Windows.Forms.Label    _lblSection2;
    private System.Windows.Forms.CheckBox _chkAutoStart;
    private System.Windows.Forms.Panel    _div2;
    private System.Windows.Forms.Label    _lblSection3;
    private System.Windows.Forms.Label    _lblInfo2;
    private System.Windows.Forms.Label    _lblPwCurrentLabel;
    private System.Windows.Forms.TextBox  _txtCurrent;
    private System.Windows.Forms.Label    _lblPwNewLabel;
    private System.Windows.Forms.TextBox  _txtNew;
    private System.Windows.Forms.Label    _lblPwStatus;
    private System.Windows.Forms.Button   _btnChangePw;
    private System.Windows.Forms.Panel    _div3;
    private System.Windows.Forms.Button   _btnExit;
}
