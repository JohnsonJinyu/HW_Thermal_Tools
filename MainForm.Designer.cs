namespace HW_Thermal_Tools
{
    partial class MainForm
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
            panelMenu = new Panel();
            BtnForm2 = new Button();
            BtnForm1 = new Button();
            panelLogo = new Panel();
            label1 = new Label();
            panelTitleBar = new Panel();
            lblTitle = new Label();
            panelDeskTopPanel = new Panel();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(BtnForm2);
            panelMenu.Controls.Add(BtnForm1);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 4, 4, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(193, 626);
            panelMenu.TabIndex = 0;
            // 
            // BtnForm2
            // 
            BtnForm2.Dock = DockStyle.Top;
            BtnForm2.FlatStyle = FlatStyle.Flat;
            BtnForm2.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnForm2.Location = new Point(0, 135);
            BtnForm2.Margin = new Padding(4, 4, 4, 4);
            BtnForm2.Name = "BtnForm2";
            BtnForm2.Size = new Size(193, 41);
            BtnForm2.TabIndex = 2;
            BtnForm2.Text = "壳温拟合";
            BtnForm2.UseVisualStyleBackColor = true;
            BtnForm2.Click += BtnForm2_Click;
            // 
            // BtnForm1
            // 
            BtnForm1.Dock = DockStyle.Top;
            BtnForm1.FlatStyle = FlatStyle.Flat;
            BtnForm1.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BtnForm1.Location = new Point(0, 94);
            BtnForm1.Margin = new Padding(4, 4, 4, 4);
            BtnForm1.Name = "BtnForm1";
            BtnForm1.Size = new Size(193, 41);
            BtnForm1.TabIndex = 1;
            BtnForm1.Text = "XML To Excel";
            BtnForm1.UseVisualStyleBackColor = true;
            BtnForm1.Click += BtnForm1_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 4, 4, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(193, 94);
            panelLogo.TabIndex = 0;
            panelLogo.Paint += panelLogo_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.LightGray;
            label1.Location = new Point(15, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 19);
            label1.TabIndex = 0;
            label1.Text = "HW_Thermal_Tools";
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelTitleBar.Controls.Add(lblTitle);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(193, 0);
            panelTitleBar.Margin = new Padding(4, 4, 4, 4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1224, 94);
            panelTitleBar.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(546, 28);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(96, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "HOME";
            // 
            // panelDeskTopPanel
            // 
            panelDeskTopPanel.Dock = DockStyle.Fill;
            panelDeskTopPanel.Location = new Point(193, 94);
            panelDeskTopPanel.Margin = new Padding(4, 4, 4, 4);
            panelDeskTopPanel.Name = "panelDeskTopPanel";
            panelDeskTopPanel.Size = new Size(1224, 532);
            panelDeskTopPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1417, 626);
            Controls.Add(panelDeskTopPanel);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Button BtnForm2;
        private Button BtnForm1;
        private Panel panelLogo;
        private Panel panelTitleBar;
        private Label lblTitle;
        private Label label1;
        private Panel panelDeskTopPanel;
    }
}