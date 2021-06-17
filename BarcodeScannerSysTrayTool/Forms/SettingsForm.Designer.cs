namespace BarcodeScannerSysTrayTool
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxAskedClosing = new System.Windows.Forms.CheckBox();
            this.textBoxDelay1 = new System.Windows.Forms.TextBox();
            this.textBoxDelay3 = new System.Windows.Forms.TextBox();
            this.labelDelay1 = new System.Windows.Forms.Label();
            this.labelDelay2 = new System.Windows.Forms.Label();
            this.textBoxDelay2 = new System.Windows.Forms.TextBox();
            this.labelDelay3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonPatternUpdate = new System.Windows.Forms.Button();
            this.buttonPatternRemove = new System.Windows.Forms.Button();
            this.buttonPatternAdd = new System.Windows.Forms.Button();
            this.listViewPatterns = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBoxDefineTheSequence = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSettings = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.checkBoxPassword = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSaveSettings);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Settings ";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(482, 16);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(91, 22);
            this.buttonSaveSettings.TabIndex = 36;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 364);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBoxPassword);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBoxPassword);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.checkBoxAskedClosing);
            this.tabPage1.Controls.Add(this.textBoxDelay1);
            this.tabPage1.Controls.Add(this.textBoxDelay3);
            this.tabPage1.Controls.Add(this.labelDelay1);
            this.tabPage1.Controls.Add(this.labelDelay2);
            this.tabPage1.Controls.Add(this.textBoxDelay2);
            this.tabPage1.Controls.Add(this.labelDelay3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 338);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(26, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 28);
            this.label6.TabIndex = 27;
            this.label6.Text = "Application\r\nPassword :";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.White;
            this.textBoxPassword.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxPassword.Location = new System.Drawing.Point(130, 226);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(135, 22);
            this.textBoxPassword.TabIndex = 26;
            this.textBoxPassword.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPassword_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(271, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(271, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "sec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(271, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 14);
            this.label3.TabIndex = 23;
            this.label3.Text = "sec";
            // 
            // checkBoxAskedClosing
            // 
            this.checkBoxAskedClosing.AutoSize = true;
            this.checkBoxAskedClosing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAskedClosing.Location = new System.Drawing.Point(29, 160);
            this.checkBoxAskedClosing.Name = "checkBoxAskedClosing";
            this.checkBoxAskedClosing.Size = new System.Drawing.Size(178, 17);
            this.checkBoxAskedClosing.TabIndex = 20;
            this.checkBoxAskedClosing.Text = "Asked when closing application ";
            this.checkBoxAskedClosing.UseVisualStyleBackColor = true;
            // 
            // textBoxDelay1
            // 
            this.textBoxDelay1.BackColor = System.Drawing.Color.White;
            this.textBoxDelay1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDelay1.Location = new System.Drawing.Point(130, 26);
            this.textBoxDelay1.Name = "textBoxDelay1";
            this.textBoxDelay1.Size = new System.Drawing.Size(135, 22);
            this.textBoxDelay1.TabIndex = 17;
            this.textBoxDelay1.Text = "0,1";
            this.textBoxDelay1.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDelay1_Validating);
            // 
            // textBoxDelay3
            // 
            this.textBoxDelay3.BackColor = System.Drawing.Color.White;
            this.textBoxDelay3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDelay3.Location = new System.Drawing.Point(130, 107);
            this.textBoxDelay3.Name = "textBoxDelay3";
            this.textBoxDelay3.Size = new System.Drawing.Size(135, 22);
            this.textBoxDelay3.TabIndex = 21;
            this.textBoxDelay3.Text = "2,0";
            this.textBoxDelay3.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDelay3_Validating);
            // 
            // labelDelay1
            // 
            this.labelDelay1.AutoSize = true;
            this.labelDelay1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDelay1.Location = new System.Drawing.Point(26, 29);
            this.labelDelay1.Name = "labelDelay1";
            this.labelDelay1.Size = new System.Drawing.Size(56, 14);
            this.labelDelay1.TabIndex = 18;
            this.labelDelay1.Text = "Delay 1  :";
            // 
            // labelDelay2
            // 
            this.labelDelay2.AutoSize = true;
            this.labelDelay2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDelay2.Location = new System.Drawing.Point(26, 72);
            this.labelDelay2.Name = "labelDelay2";
            this.labelDelay2.Size = new System.Drawing.Size(56, 14);
            this.labelDelay2.TabIndex = 20;
            this.labelDelay2.Text = "Delay 2  :";
            // 
            // textBoxDelay2
            // 
            this.textBoxDelay2.BackColor = System.Drawing.Color.White;
            this.textBoxDelay2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxDelay2.Location = new System.Drawing.Point(130, 69);
            this.textBoxDelay2.Name = "textBoxDelay2";
            this.textBoxDelay2.Size = new System.Drawing.Size(135, 22);
            this.textBoxDelay2.TabIndex = 19;
            this.textBoxDelay2.Text = "0,3";
            this.textBoxDelay2.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDelay2_Validating);
            // 
            // labelDelay3
            // 
            this.labelDelay3.AutoSize = true;
            this.labelDelay3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDelay3.Location = new System.Drawing.Point(26, 110);
            this.labelDelay3.Name = "labelDelay3";
            this.labelDelay3.Size = new System.Drawing.Size(56, 14);
            this.labelDelay3.TabIndex = 22;
            this.labelDelay3.Text = "Delay 3  :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonPatternUpdate);
            this.tabPage2.Controls.Add(this.buttonPatternRemove);
            this.tabPage2.Controls.Add(this.buttonPatternAdd);
            this.tabPage2.Controls.Add(this.listViewPatterns);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 338);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Additional barcodes patterns";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonPatternUpdate
            // 
            this.buttonPatternUpdate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPatternUpdate.Location = new System.Drawing.Point(123, 292);
            this.buttonPatternUpdate.Name = "buttonPatternUpdate";
            this.buttonPatternUpdate.Size = new System.Drawing.Size(91, 22);
            this.buttonPatternUpdate.TabIndex = 36;
            this.buttonPatternUpdate.Text = "Update";
            this.buttonPatternUpdate.UseVisualStyleBackColor = true;
            this.buttonPatternUpdate.Click += new System.EventHandler(this.buttonPatternUpdate_Click);
            // 
            // buttonPatternRemove
            // 
            this.buttonPatternRemove.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPatternRemove.Location = new System.Drawing.Point(238, 292);
            this.buttonPatternRemove.Name = "buttonPatternRemove";
            this.buttonPatternRemove.Size = new System.Drawing.Size(91, 22);
            this.buttonPatternRemove.TabIndex = 35;
            this.buttonPatternRemove.Text = "Remove";
            this.buttonPatternRemove.UseVisualStyleBackColor = true;
            this.buttonPatternRemove.Click += new System.EventHandler(this.buttonPatternRemove_Click);
            // 
            // buttonPatternAdd
            // 
            this.buttonPatternAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPatternAdd.Location = new System.Drawing.Point(13, 292);
            this.buttonPatternAdd.Name = "buttonPatternAdd";
            this.buttonPatternAdd.Size = new System.Drawing.Size(91, 22);
            this.buttonPatternAdd.TabIndex = 34;
            this.buttonPatternAdd.Text = "Add";
            this.buttonPatternAdd.UseVisualStyleBackColor = true;
            this.buttonPatternAdd.Click += new System.EventHandler(this.buttonPatternAdd_Click);
            // 
            // listViewPatterns
            // 
            this.listViewPatterns.BackColor = System.Drawing.Color.White;
            this.listViewPatterns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewPatterns.FullRowSelect = true;
            this.listViewPatterns.GridLines = true;
            this.listViewPatterns.HideSelection = false;
            this.listViewPatterns.Location = new System.Drawing.Point(2, 6);
            this.listViewPatterns.Name = "listViewPatterns";
            this.listViewPatterns.Size = new System.Drawing.Size(560, 267);
            this.listViewPatterns.TabIndex = 29;
            this.listViewPatterns.UseCompatibleStateImageBehavior = false;
            this.listViewPatterns.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name pattern";
            this.columnHeader1.Width = 131;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pattern value";
            this.columnHeader2.Width = 163;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Define the sequence (send string) ";
            this.columnHeader3.Width = 246;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.richTextBoxDefineTheSequence);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(568, 338);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Default the sequence (send string) ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // richTextBoxDefineTheSequence
            // 
            this.richTextBoxDefineTheSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDefineTheSequence.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxDefineTheSequence.Name = "richTextBoxDefineTheSequence";
            this.richTextBoxDefineTheSequence.Size = new System.Drawing.Size(568, 338);
            this.richTextBoxDefineTheSequence.TabIndex = 0;
            this.richTextBoxDefineTheSequence.Text = resources.GetString("richTextBoxDefineTheSequence.Text");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSettings});
            this.statusStrip1.Location = new System.Drawing.Point(3, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(579, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSettings
            // 
            this.toolStripStatusLabelSettings.Name = "toolStripStatusLabelSettings";
            this.toolStripStatusLabelSettings.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // checkBoxPassword
            // 
            this.checkBoxPassword.AutoSize = true;
            this.checkBoxPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxPassword.Location = new System.Drawing.Point(29, 200);
            this.checkBoxPassword.Name = "checkBoxPassword";
            this.checkBoxPassword.Size = new System.Drawing.Size(154, 17);
            this.checkBoxPassword.TabIndex = 28;
            this.checkBoxPassword.Text = "Is password on application ";
            this.checkBoxPassword.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 439);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSettings;
        private System.Windows.Forms.TextBox textBoxDelay3;
        private System.Windows.Forms.Label labelDelay3;
        private System.Windows.Forms.TextBox textBoxDelay2;
        private System.Windows.Forms.Label labelDelay2;
        private System.Windows.Forms.TextBox textBoxDelay1;
        private System.Windows.Forms.Label labelDelay1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox checkBoxAskedClosing;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listViewPatterns;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button buttonPatternRemove;
        private System.Windows.Forms.Button buttonPatternAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonPatternUpdate;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox richTextBoxDefineTheSequence;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox checkBoxPassword;
    }
}

