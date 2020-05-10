namespace breadCompany
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpUP = new System.Windows.Forms.GroupBox();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.errorPLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.linkRegister = new System.Windows.Forms.LinkLabel();
            this.grpUP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(50, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(58, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifrə :";
            // 
            // grpUP
            // 
            this.grpUP.Controls.Add(this.linkForgotPassword);
            this.grpUP.Controls.Add(this.txtUserPassword);
            this.grpUP.Controls.Add(this.txtEmail);
            this.grpUP.Controls.Add(this.btnLogin);
            this.grpUP.Controls.Add(this.label2);
            this.grpUP.Controls.Add(this.label1);
            this.grpUP.Location = new System.Drawing.Point(12, 104);
            this.grpUP.Name = "grpUP";
            this.grpUP.Size = new System.Drawing.Size(275, 131);
            this.grpUP.TabIndex = 2;
            this.grpUP.TabStop = false;
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Location = new System.Drawing.Point(6, 101);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(87, 13);
            this.linkForgotPassword.TabIndex = 5;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Şifrəni Umuttum?";
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(123, 65);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.Size = new System.Drawing.Size(129, 20);
            this.txtUserPassword.TabIndex = 4;
            this.txtUserPassword.Text = "12";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(123, 26);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(129, 21);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "sureyya";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(177, 91);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Daxil Ol";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.Red;
            this.lblEmail.Location = new System.Drawing.Point(54, 37);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(196, 41);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Gəncə Təndir";
            // 
            // errorPLogin
            // 
            this.errorPLogin.ContainerControl = this;
            // 
            // errorPPassword
            // 
            this.errorPPassword.ContainerControl = this;
            // 
            // linkRegister
            // 
            this.linkRegister.AutoSize = true;
            this.linkRegister.LinkColor = System.Drawing.Color.DarkGreen;
            this.linkRegister.Location = new System.Drawing.Point(12, 242);
            this.linkRegister.Name = "linkRegister";
            this.linkRegister.Size = new System.Drawing.Size(93, 13);
            this.linkRegister.TabIndex = 4;
            this.linkRegister.TabStop = true;
            this.linkRegister.Text = "Istifadəçi Əlavə Et";
            this.linkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRegister_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(302, 277);
            this.Controls.Add(this.linkRegister);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.grpUP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daxil ol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LoginForm_FormClosed);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.grpUP.ResumeLayout(false);
            this.grpUP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorPLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpUP;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ErrorProvider errorPLogin;
        private System.Windows.Forms.ErrorProvider errorPPassword;
        private System.Windows.Forms.LinkLabel linkRegister;
    }
}