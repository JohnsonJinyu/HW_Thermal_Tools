namespace HW_Thermal_Tools.Forms
{
    partial class ShellTempFitting
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
            TxtboxNtcnames = new TableLayoutPanel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            TxtboxStfResult = new TextBox();
            TxtboxStfFilesPath = new TextBox();
            textBox2 = new TextBox();
            BtnStfSelectFiles = new Button();
            BtnStfConfirm = new Button();
            pictureBox1 = new PictureBox();
            TxtboxNtcnames.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TxtboxNtcnames
            // 
            TxtboxNtcnames.ColumnCount = 6;
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67334F));
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.67334F));
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            TxtboxNtcnames.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66333F));
            TxtboxNtcnames.Controls.Add(pictureBox3, 4, 5);
            TxtboxNtcnames.Controls.Add(pictureBox2, 2, 5);
            TxtboxNtcnames.Controls.Add(TxtboxStfResult, 1, 3);
            TxtboxNtcnames.Controls.Add(TxtboxStfFilesPath, 1, 0);
            TxtboxNtcnames.Controls.Add(textBox2, 1, 2);
            TxtboxNtcnames.Controls.Add(BtnStfSelectFiles, 5, 1);
            TxtboxNtcnames.Controls.Add(BtnStfConfirm, 5, 2);
            TxtboxNtcnames.Controls.Add(pictureBox1, 0, 5);
            TxtboxNtcnames.Dock = DockStyle.Fill;
            TxtboxNtcnames.Location = new Point(0, 0);
            TxtboxNtcnames.Name = "TxtboxNtcnames";
            TxtboxNtcnames.RowCount = 8;
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TxtboxNtcnames.Size = new Size(800, 450);
            TxtboxNtcnames.TabIndex = 0;
            // 
            // pictureBox3
            // 
            TxtboxNtcnames.SetColumnSpan(pictureBox3, 2);
            pictureBox3.Dock = DockStyle.Fill;
            pictureBox3.Location = new Point(535, 283);
            pictureBox3.Name = "pictureBox3";
            TxtboxNtcnames.SetRowSpan(pictureBox3, 3);
            pictureBox3.Size = new Size(262, 164);
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            TxtboxNtcnames.SetColumnSpan(pictureBox2, 2);
            pictureBox2.Dock = DockStyle.Fill;
            pictureBox2.Location = new Point(269, 283);
            pictureBox2.Name = "pictureBox2";
            TxtboxNtcnames.SetRowSpan(pictureBox2, 3);
            pictureBox2.Size = new Size(260, 164);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // TxtboxStfResult
            // 
            TxtboxNtcnames.SetColumnSpan(TxtboxStfResult, 4);
            TxtboxStfResult.Dock = DockStyle.Fill;
            TxtboxStfResult.Location = new Point(136, 171);
            TxtboxStfResult.Multiline = true;
            TxtboxStfResult.Name = "TxtboxStfResult";
            TxtboxNtcnames.SetRowSpan(TxtboxStfResult, 2);
            TxtboxStfResult.Size = new Size(526, 106);
            TxtboxStfResult.TabIndex = 2;
            // 
            // TxtboxStfFilesPath
            // 
            TxtboxNtcnames.SetColumnSpan(TxtboxStfFilesPath, 4);
            TxtboxStfFilesPath.Dock = DockStyle.Fill;
            TxtboxStfFilesPath.Location = new Point(136, 3);
            TxtboxStfFilesPath.Multiline = true;
            TxtboxStfFilesPath.Name = "TxtboxStfFilesPath";
            TxtboxNtcnames.SetRowSpan(TxtboxStfFilesPath, 2);
            TxtboxStfFilesPath.Size = new Size(526, 106);
            TxtboxStfFilesPath.TabIndex = 0;
            // 
            // textBox2
            // 
            TxtboxNtcnames.SetColumnSpan(textBox2, 4);
            textBox2.Dock = DockStyle.Fill;
            textBox2.Location = new Point(136, 115);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(526, 50);
            textBox2.TabIndex = 1;
            // 
            // BtnStfSelectFiles
            // 
            BtnStfSelectFiles.Dock = DockStyle.Fill;
            BtnStfSelectFiles.FlatStyle = FlatStyle.Flat;
            BtnStfSelectFiles.Location = new Point(668, 59);
            BtnStfSelectFiles.Name = "BtnStfSelectFiles";
            BtnStfSelectFiles.Size = new Size(129, 50);
            BtnStfSelectFiles.TabIndex = 3;
            BtnStfSelectFiles.Text = "选择文件";
            BtnStfSelectFiles.UseVisualStyleBackColor = false;
            // 
            // BtnStfConfirm
            // 
            BtnStfConfirm.Dock = DockStyle.Fill;
            BtnStfConfirm.FlatStyle = FlatStyle.Flat;
            BtnStfConfirm.Location = new Point(668, 115);
            BtnStfConfirm.Name = "BtnStfConfirm";
            BtnStfConfirm.Size = new Size(129, 50);
            BtnStfConfirm.TabIndex = 4;
            BtnStfConfirm.Text = "确认";
            BtnStfConfirm.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            TxtboxNtcnames.SetColumnSpan(pictureBox1, 2);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(3, 283);
            pictureBox1.Name = "pictureBox1";
            TxtboxNtcnames.SetRowSpan(pictureBox1, 3);
            pictureBox1.Size = new Size(260, 164);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // ShellTempFitting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TxtboxNtcnames);
            Name = "ShellTempFitting";
            Text = "ShellTempFitting";
            Load += ShellTempFitting_Load;
            TxtboxNtcnames.ResumeLayout(false);
            TxtboxNtcnames.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TxtboxNtcnames;
        private TextBox TxtboxStfResult;
        private TextBox TxtboxStfFilesPath;
        private TextBox textBox2;
        private Button BtnStfSelectFiles;
        private Button BtnStfConfirm;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
    }
}