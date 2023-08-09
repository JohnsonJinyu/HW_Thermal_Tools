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
            dataGridViewResult = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            SuspendLayout();
            // 
            // TextBoxLogFilePath
            // 
            TextBoxLogFilePath.Location = new Point(95, 38);
            TextBoxLogFilePath.Multiline = true;
            TextBoxLogFilePath.Name = "TextBoxLogFilePath";
            TextBoxLogFilePath.Size = new Size(776, 52);
            TextBoxLogFilePath.TabIndex = 0;
            // 
            // TextBoxLogKeyWords
            // 
            TextBoxLogKeyWords.Location = new Point(95, 131);
            TextBoxLogKeyWords.Multiline = true;
            TextBoxLogKeyWords.Name = "TextBoxLogKeyWords";
            TextBoxLogKeyWords.PlaceholderText = "请输入需要的关键词";
            TextBoxLogKeyWords.Size = new Size(776, 45);
            TextBoxLogKeyWords.TabIndex = 1;
            // 
            // BtnSelectLogFiles
            // 
            BtnSelectLogFiles.Location = new Point(965, 38);
            BtnSelectLogFiles.Name = "BtnSelectLogFiles";
            BtnSelectLogFiles.Size = new Size(174, 52);
            BtnSelectLogFiles.TabIndex = 2;
            BtnSelectLogFiles.Text = "选择Log文件";
            BtnSelectLogFiles.UseVisualStyleBackColor = true;
            BtnSelectLogFiles.Click += BtnSelectLogFiles_Click;
            // 
            // BtnReadLogConfirm
            // 
            BtnReadLogConfirm.Location = new Point(965, 131);
            BtnReadLogConfirm.Name = "BtnReadLogConfirm";
            BtnReadLogConfirm.Size = new Size(174, 45);
            BtnReadLogConfirm.TabIndex = 3;
            BtnReadLogConfirm.Text = "确认";
            BtnReadLogConfirm.UseVisualStyleBackColor = true;
            BtnReadLogConfirm.Click += BtnReadLogConfirm_Click;
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Location = new Point(95, 210);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.RowHeadersWidth = 51;
            dataGridViewResult.RowTemplate.Height = 29;
            dataGridViewResult.Size = new Size(776, 421);
            dataGridViewResult.TabIndex = 4;
            // 
            // ReadLog
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1222, 712);
            Controls.Add(dataGridViewResult);
            Controls.Add(BtnReadLogConfirm);
            Controls.Add(BtnSelectLogFiles);
            Controls.Add(TextBoxLogKeyWords);
            Controls.Add(TextBoxLogFilePath);
            Name = "ReadLog";
            Text = "ReadLog";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TextBoxLogFilePath;
        private TextBox TextBoxLogKeyWords;
        private Button BtnSelectLogFiles;
        private Button BtnReadLogConfirm;
        private DataGridView dataGridViewResult;
    }
}