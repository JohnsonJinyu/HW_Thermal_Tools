namespace HW_Thermal_Tools.Forms
{
    partial class ReadLog
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
            TextBoxLogFilePath = new TextBox();
            TextBoxLogKeyWords = new TextBox();
            BtnSelectLogFiles = new Button();
            BtnReadLogConfirm = new Button();
            ProgressBarReadLog = new ProgressBar();
            SuspendLayout();
            // 
            // TextBoxLogFilePath
            // 
            TextBoxLogFilePath.Location = new Point(74, 43);
            TextBoxLogFilePath.Margin = new Padding(2, 3, 2, 3);
            TextBoxLogFilePath.Multiline = true;
            TextBoxLogFilePath.Name = "TextBoxLogFilePath";
            TextBoxLogFilePath.Size = new Size(604, 45);
            TextBoxLogFilePath.TabIndex = 0;
            // 
            // TextBoxLogKeyWords
            // 
            TextBoxLogKeyWords.Location = new Point(74, 115);
            TextBoxLogKeyWords.Margin = new Padding(2, 3, 2, 3);
            TextBoxLogKeyWords.Multiline = true;
            TextBoxLogKeyWords.Name = "TextBoxLogKeyWords";
            TextBoxLogKeyWords.PlaceholderText = "请输入需要的关键词";
            TextBoxLogKeyWords.Size = new Size(604, 39);
            TextBoxLogKeyWords.TabIndex = 1;
            // 
            // BtnSelectLogFiles
            // 
            BtnSelectLogFiles.Location = new Point(751, 43);
            BtnSelectLogFiles.Margin = new Padding(2, 3, 2, 3);
            BtnSelectLogFiles.Name = "BtnSelectLogFiles";
            BtnSelectLogFiles.Size = new Size(135, 44);
            BtnSelectLogFiles.TabIndex = 2;
            BtnSelectLogFiles.Text = "选择Log文件";
            BtnSelectLogFiles.UseVisualStyleBackColor = true;
            BtnSelectLogFiles.Click += BtnSelectLogFiles_Click;
            // 
            // BtnReadLogConfirm
            // 
            BtnReadLogConfirm.Location = new Point(751, 115);
            BtnReadLogConfirm.Margin = new Padding(2, 3, 2, 3);
            BtnReadLogConfirm.Name = "BtnReadLogConfirm";
            BtnReadLogConfirm.Size = new Size(135, 38);
            BtnReadLogConfirm.TabIndex = 3;
            BtnReadLogConfirm.Text = "确认";
            BtnReadLogConfirm.UseVisualStyleBackColor = true;
            BtnReadLogConfirm.Click += BtnReadLogConfirm_Click;
            // 
            // ProgressBarReadLog
            // 
            ProgressBarReadLog.Location = new Point(74, 222);
            ProgressBarReadLog.Name = "ProgressBarReadLog";
            ProgressBarReadLog.Size = new Size(604, 23);
            ProgressBarReadLog.TabIndex = 5;
            // 
            // ReadLog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 563);
            Controls.Add(ProgressBarReadLog);
            Controls.Add(BtnReadLogConfirm);
            Controls.Add(BtnSelectLogFiles);
            Controls.Add(TextBoxLogKeyWords);
            Controls.Add(TextBoxLogFilePath);
            Margin = new Padding(2, 3, 2, 3);
            Name = "ReadLog";
            Text = "ReadLog";
            Load += ReadLog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxLogFilePath;
        private TextBox TextBoxLogKeyWords;
        private Button BtnSelectLogFiles;
        private Button BtnReadLogConfirm;
        private ProgressBar ProgressBarReadLog;
    }
}