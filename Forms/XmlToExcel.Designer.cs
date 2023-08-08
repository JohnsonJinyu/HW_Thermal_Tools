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
            TabLayoutPanel_XmlToExcel = new TableLayoutPanel();
            BtnXmlToExcelFile = new Button();
            BtnSelectConfigFile = new Button();
            TxtXmlFilePath = new TextBox();
            TxtConfigFile = new TextBox();
            BtnSelectXmlFile = new Button();
            TabLayoutPanel_XmlToExcel.SuspendLayout();
            SuspendLayout();
            // 
            // TabLayoutPanel_XmlToExcel
            // 
            TabLayoutPanel_XmlToExcel.ColumnCount = 8;
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.Controls.Add(BtnXmlToExcelFile, 3, 5);
            TabLayoutPanel_XmlToExcel.Controls.Add(BtnSelectConfigFile, 6, 3);
            TabLayoutPanel_XmlToExcel.Controls.Add(TxtXmlFilePath, 0, 1);
            TabLayoutPanel_XmlToExcel.Controls.Add(TxtConfigFile, 0, 3);
            TabLayoutPanel_XmlToExcel.Controls.Add(BtnSelectXmlFile, 6, 1);
            TabLayoutPanel_XmlToExcel.Dock = DockStyle.Fill;
            TabLayoutPanel_XmlToExcel.Location = new Point(0, 0);
            TabLayoutPanel_XmlToExcel.Name = "TabLayoutPanel_XmlToExcel";
            TabLayoutPanel_XmlToExcel.RowCount = 8;
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            TabLayoutPanel_XmlToExcel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TabLayoutPanel_XmlToExcel.Size = new Size(800, 450);
            TabLayoutPanel_XmlToExcel.TabIndex = 0;
            // 
            // BtnXmlToExcelFile
            // 
            BtnXmlToExcelFile.BackColor = SystemColors.ControlLight;
            TabLayoutPanel_XmlToExcel.SetColumnSpan(BtnXmlToExcelFile, 2);
            BtnXmlToExcelFile.Dock = DockStyle.Fill;
            BtnXmlToExcelFile.FlatStyle = FlatStyle.Flat;
            BtnXmlToExcelFile.Location = new Point(303, 283);
            BtnXmlToExcelFile.Name = "BtnXmlToExcelFile";
            BtnXmlToExcelFile.Size = new Size(194, 50);
            BtnXmlToExcelFile.TabIndex = 4;
            BtnXmlToExcelFile.Text = "确认";
            BtnXmlToExcelFile.UseVisualStyleBackColor = false;
            BtnXmlToExcelFile.Click += BtnXmlToExcelFile_Click;
            // 
            // BtnSelectConfigFile
            // 
            BtnSelectConfigFile.BackColor = SystemColors.ControlLight;
            TabLayoutPanel_XmlToExcel.SetColumnSpan(BtnSelectConfigFile, 2);
            BtnSelectConfigFile.Dock = DockStyle.Fill;
            BtnSelectConfigFile.FlatStyle = FlatStyle.Flat;
            BtnSelectConfigFile.Location = new Point(603, 171);
            BtnSelectConfigFile.Name = "BtnSelectConfigFile";
            BtnSelectConfigFile.Size = new Size(194, 50);
            BtnSelectConfigFile.TabIndex = 3;
            BtnSelectConfigFile.Text = "选择配置文件";
            BtnSelectConfigFile.UseVisualStyleBackColor = false;
            BtnSelectConfigFile.Click += BtnSelectConfigFile_Click;
            // 
            // TxtXmlFilePath
            // 
            TabLayoutPanel_XmlToExcel.SetColumnSpan(TxtXmlFilePath, 6);
            TxtXmlFilePath.Dock = DockStyle.Fill;
            TxtXmlFilePath.Location = new Point(3, 59);
            TxtXmlFilePath.Multiline = true;
            TxtXmlFilePath.Name = "TxtXmlFilePath";
            TxtXmlFilePath.Size = new Size(594, 50);
            TxtXmlFilePath.TabIndex = 0;
            // 
            // TxtConfigFile
            // 
            TabLayoutPanel_XmlToExcel.SetColumnSpan(TxtConfigFile, 6);
            TxtConfigFile.Dock = DockStyle.Fill;
            TxtConfigFile.Location = new Point(3, 171);
            TxtConfigFile.Multiline = true;
            TxtConfigFile.Name = "TxtConfigFile";
            TxtConfigFile.Size = new Size(594, 50);
            TxtConfigFile.TabIndex = 1;
            // 
            // BtnSelectXmlFile
            // 
            BtnSelectXmlFile.BackColor = SystemColors.ControlLight;
            TabLayoutPanel_XmlToExcel.SetColumnSpan(BtnSelectXmlFile, 2);
            BtnSelectXmlFile.Dock = DockStyle.Fill;
            BtnSelectXmlFile.FlatStyle = FlatStyle.Flat;
            BtnSelectXmlFile.Location = new Point(603, 59);
            BtnSelectXmlFile.Name = "BtnSelectXmlFile";
            BtnSelectXmlFile.Size = new Size(194, 50);
            BtnSelectXmlFile.TabIndex = 2;
            BtnSelectXmlFile.Text = "选择XML文件";
            BtnSelectXmlFile.UseVisualStyleBackColor = false;
            BtnSelectXmlFile.Click += BtnSelectXmlFile_Click;
            // 
            // XmlToExcel
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TabLayoutPanel_XmlToExcel);
            Name = "XmlToExcel";
            Text = "XmlToExcel";
            Load += XmlToExcel_Load;
            TabLayoutPanel_XmlToExcel.ResumeLayout(false);
            TabLayoutPanel_XmlToExcel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel TabLayoutPanel_XmlToExcel;
        private TextBox TxtXmlFilePath;
        private Button BtnXmlToExcelFile;
        private Button BtnSelectConfigFile;
        private TextBox TxtConfigFile;
        private Button BtnSelectXmlFile;
    }
}