namespace WowHeadParser
{
    partial class FrmMain
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.cbParser = new System.Windows.Forms.ComboBox();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.clbSubParsers = new System.Windows.Forms.CheckedListBox();
            this.nudThreads = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbLocale = new System.Windows.Forms.ComboBox();
            this.tbListEntrys = new System.Windows.Forms.TextBox();
            this.bShowOpenFileDialog = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbConsole);
            this.groupBox1.Location = new System.Drawing.Point(2, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Console";
            // 
            // rtbConsole
            // 
            this.rtbConsole.BackColor = System.Drawing.Color.Black;
            this.rtbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbConsole.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbConsole.ForeColor = System.Drawing.Color.Cyan;
            this.rtbConsole.Location = new System.Drawing.Point(3, 16);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(549, 210);
            this.rtbConsole.TabIndex = 0;
            this.rtbConsole.Text = "";
            // 
            // cbParser
            // 
            this.cbParser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbParser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParser.FormattingEnabled = true;
            this.cbParser.Location = new System.Drawing.Point(52, 19);
            this.cbParser.Name = "cbParser";
            this.cbParser.Size = new System.Drawing.Size(217, 21);
            this.cbParser.TabIndex = 1;
            this.cbParser.SelectedIndexChanged += new System.EventHandler(this.cbParser_SelectedIndexChanged);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(496, 48);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(60, 23);
            this.bStop.TabIndex = 4;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(496, 19);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(60, 23);
            this.bStart.TabIndex = 6;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 125);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(552, 19);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProgress.ForeColor = System.Drawing.Color.Blue;
            this.labelProgress.Location = new System.Drawing.Point(9, 109);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(41, 13);
            this.labelProgress.TabIndex = 8;
            this.labelProgress.Text = "label1";
            this.labelProgress.Visible = false;
            // 
            // clbSubParsers
            // 
            this.clbSubParsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.clbSubParsers.CheckOnClick = true;
            this.clbSubParsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbSubParsers.FormattingEnabled = true;
            this.clbSubParsers.Location = new System.Drawing.Point(3, 16);
            this.clbSubParsers.Name = "clbSubParsers";
            this.clbSubParsers.Size = new System.Drawing.Size(198, 81);
            this.clbSubParsers.TabIndex = 9;
            // 
            // nudThreads
            // 
            this.nudThreads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nudThreads.Location = new System.Drawing.Point(86, 73);
            this.nudThreads.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.Name = "nudThreads";
            this.nudThreads.Size = new System.Drawing.Size(53, 20);
            this.nudThreads.TabIndex = 10;
            this.nudThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThreads.ValueChanged += new System.EventHandler(this.nudThreads_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLocale);
            this.groupBox2.Controls.Add(this.tbListEntrys);
            this.groupBox2.Controls.Add(this.bShowOpenFileDialog);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudDelay);
            this.groupBox2.Controls.Add(this.cbParser);
            this.groupBox2.Controls.Add(this.nudThreads);
            this.groupBox2.Location = new System.Drawing.Point(4, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 100);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parsed Settings";
            // 
            // cbLocale
            // 
            this.cbLocale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocale.FormattingEnabled = true;
            this.cbLocale.Items.AddRange(new object[] {
            "",
            "ru.",
            "de.",
            "fr."});
            this.cbLocale.Location = new System.Drawing.Point(8, 19);
            this.cbLocale.Name = "cbLocale";
            this.cbLocale.Size = new System.Drawing.Size(38, 21);
            this.cbLocale.TabIndex = 14;
            // 
            // tbListEntrys
            // 
            this.tbListEntrys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tbListEntrys.Location = new System.Drawing.Point(8, 46);
            this.tbListEntrys.Name = "tbListEntrys";
            this.tbListEntrys.Size = new System.Drawing.Size(238, 20);
            this.tbListEntrys.TabIndex = 13;
            // 
            // bShowOpenFileDialog
            // 
            this.bShowOpenFileDialog.Location = new System.Drawing.Point(244, 45);
            this.bShowOpenFileDialog.Name = "bShowOpenFileDialog";
            this.bShowOpenFileDialog.Size = new System.Drawing.Size(26, 22);
            this.bShowOpenFileDialog.TabIndex = 12;
            this.bShowOpenFileDialog.Text = "...";
            this.bShowOpenFileDialog.UseVisualStyleBackColor = true;
            this.bShowOpenFileDialog.Click += new System.EventHandler(this.bShowOpenFileDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Thread Count:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clbSubParsers);
            this.groupBox3.Location = new System.Drawing.Point(286, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 100);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sub Parsers";
            // 
            // nudDelay
            // 
            this.nudDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.nudDelay.Location = new System.Drawing.Point(215, 73);
            this.nudDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(54, 20);
            this.nudDelay.TabIndex = 10;
            this.nudDelay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Delay:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(560, 378);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WowHead Parser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudThreads)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.ComboBox cbParser;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.CheckedListBox clbSubParsers;
        private System.Windows.Forms.NumericUpDown nudThreads;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbListEntrys;
        private System.Windows.Forms.Button bShowOpenFileDialog;
        private System.Windows.Forms.ComboBox cbLocale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDelay;
    }
}

