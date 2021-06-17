namespace BarcodeScannerSysTrayTool.Forms
{
    partial class AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAuthenticationCancel = new System.Windows.Forms.Button();
            this.buttonAuthenticationLogin = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSettings = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDelay1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAuthenticationCancel);
            this.groupBox1.Controls.Add(this.buttonAuthenticationLogin);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.labelDelay1);
            this.groupBox1.Controls.Add(this.textBoxPassword);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 220);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Enter password to acces application settings";
            // 
            // buttonAuthenticationCancel
            // 
            this.buttonAuthenticationCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAuthenticationCancel.Location = new System.Drawing.Point(163, 147);
            this.buttonAuthenticationCancel.Name = "buttonAuthenticationCancel";
            this.buttonAuthenticationCancel.Size = new System.Drawing.Size(91, 22);
            this.buttonAuthenticationCancel.TabIndex = 3;
            this.buttonAuthenticationCancel.Text = "Cancel";
            this.buttonAuthenticationCancel.UseVisualStyleBackColor = true;
            this.buttonAuthenticationCancel.Click += new System.EventHandler(this.buttonAuthenticationCancel_Click);
            // 
            // buttonAuthenticationLogin
            // 
            this.buttonAuthenticationLogin.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAuthenticationLogin.Location = new System.Drawing.Point(37, 147);
            this.buttonAuthenticationLogin.Name = "buttonAuthenticationLogin";
            this.buttonAuthenticationLogin.Size = new System.Drawing.Size(91, 22);
            this.buttonAuthenticationLogin.TabIndex = 2;
            this.buttonAuthenticationLogin.Text = "Login";
            this.buttonAuthenticationLogin.UseVisualStyleBackColor = true;
            this.buttonAuthenticationLogin.Click += new System.EventHandler(this.buttonAuthenticationLogin_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSettings});
            this.statusStrip1.Location = new System.Drawing.Point(3, 195);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(336, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSettings
            // 
            this.toolStripStatusLabelSettings.Name = "toolStripStatusLabelSettings";
            this.toolStripStatusLabelSettings.Size = new System.Drawing.Size(0, 17);
            // 
            // labelDelay1
            // 
            this.labelDelay1.AutoSize = true;
            this.labelDelay1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDelay1.Location = new System.Drawing.Point(37, 71);
            this.labelDelay1.Name = "labelDelay1";
            this.labelDelay1.Size = new System.Drawing.Size(68, 14);
            this.labelDelay1.TabIndex = 18;
            this.labelDelay1.Text = "Password  :";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPassword.Location = new System.Drawing.Point(110, 68);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(135, 22);
            this.textBoxPassword.TabIndex = 17;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 232);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Authentication";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAuthenticationCancel;
        private System.Windows.Forms.Button buttonAuthenticationLogin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSettings;
        private System.Windows.Forms.Label labelDelay1;
        private System.Windows.Forms.TextBox textBoxPassword;
    }
}