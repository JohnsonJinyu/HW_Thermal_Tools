namespace HW_Thermal_Tools.Forms
{
    partial class XmlToExcel
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
            tableLayoutPanel1 = new TableLayoutPanel();
            BtnXmlToExcelFile = new Button();
            BtnSelectConfigFile = new Button();
            TxtXmlFilePath = new TextBox();
            TxtConfigFile = new TextBox();
            BtnSelectXmlFile = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Controls.Add(BtnXmlToExcelFile, 3, 5);
            tableLayoutPanel1.Controls.Add(BtnSelectConfigFile, 6, 3);
            tableLayoutPanel1.Controls.Add(TxtXmlFilePath, 0, 1);
            tableLayoutPanel1.Controls.Add(TxtConfigFile, 0, 3);
            tableLayoutPanel1.Controls.Add(BtnSelectXmlFile, 6, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // BtnXmlToExcelFile
            // 
            tableLayoutPanel1.SetColumnSpan(BtnXmlToExcelFile, 2);
            BtnXmlToExcelFile.Dock = DockStyle.Fill;
            BtnXmlToExcelFile.FlatStyle = FlatStyle.Flat;
            BtnXmlToExcelFile.Location = new Point(303, 283);
            BtnXmlToExcelFile.Name = "BtnXmlToExcelFile";
            BtnXmlToExcelFile.Size = new Size(194, 50);
            BtnXmlToExcelFile.TabIndex = 4;
            BtnXmlToExcelFile.Text = "确认";
            BtnXmlToExcelFile.UseVisualStyleBackColor = false;
            // 
            // BtnSelectConfigFile
            // 
            tableLayoutPanel1.SetColumnSpan(BtnSelectConfigFile, 2);
            BtnSelectConfigFile.Dock = DockStyle.Fill;
            BtnSelectConfigFile.FlatStyle = FlatStyle.Flat;
            BtnSelectConfigFile.Location = new Point(603, 171);
            BtnSelectConfigFile.Name = "BtnSelectConfigFile";
            BtnSelectConfigFile.Size = new Size(194, 50);
            BtnSelectConfigFile.TabIndex = 3;
            BtnSelectConfigFile.Text = "选择配置文件";
            BtnSelectConfigFile.UseVisualStyleBackColor = false;
            // 
            // TxtXmlFilePath
            // 
            tableLayoutPanel1.SetColumnSpan(TxtXmlFilePath, 6);
            TxtXmlFilePath.Dock = DockStyle.Fill;
            TxtXmlFilePath.Location = new Point(3, 59);
            TxtXmlFilePath.Multiline = true;
            TxtXmlFilePath.Name = "TxtXmlFilePath";
            TxtXmlFilePath.Size = new Size(594, 50);
            TxtXmlFilePath.TabIndex = 0;
            // 
            // TxtConfigFile
            // 
            tableLayoutPanel1.SetColumnSpan(TxtConfigFile, 6);
            TxtConfigFile.Dock = DockStyle.Fill;
            TxtConfigFile.Location = new Point(3, 171);
            TxtConfigFile.Multiline = true;
            TxtConfigFile.Name = "TxtConfigFile";
            TxtConfigFile.Size = new Size(594, 50);
            TxtConfigFile.TabIndex = 1;
            // 
            // BtnSelectXmlFile
            // 
            tableLayoutPanel1.SetColumnSpan(BtnSelectXmlFile, 2);
            BtnSelectXmlFile.Dock = DockStyle.Fill;
            BtnSelectXmlFile.FlatStyle = FlatStyle.Flat;
            BtnSelectXmlFile.Location = new Point(603, 59);
            BtnSelectXmlFile.Name = "BtnSelectXmlFile";
            BtnSelectXmlFile.Size = new Size(194, 50);
            BtnSelectXmlFile.TabIndex = 2;
            BtnSelectXmlFile.Text = "选择XML文件";
            BtnSelectXmlFile.UseVisualStyleBackColor = false;
            // 
            // XmlToExcel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "XmlToExcel";
            Text = "XmlToExcel";
            Load += XmlToExcel_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox TxtXmlFilePath;
        private Button BtnXmlToExcelFile;
        private Button BtnSelectConfigFile;
        private TextBox TxtConfigFile;
        private Button BtnSelectXmlFile;
    }
}