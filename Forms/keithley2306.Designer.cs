namespace HW_Thermal_Tools.Forms
{
    partial class keithley2306
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
            components = new System.ComponentModel.Container();
            statusStrip1 = new StatusStrip();
            DeviceConnectStatusLabel = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            graphicalOverlayComponent1 = new HZH_Controls.Controls.GraphicalOverlayComponent(components);
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { DeviceConnectStatusLabel, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 586);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1005, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // DeviceConnectStatusLabel
            // 
            DeviceConnectStatusLabel.Name = "DeviceConnectStatusLabel";
            DeviceConnectStatusLabel.Size = new Size(84, 20);
            DeviceConnectStatusLabel.Text = "检测到设备";
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 18);
            // 
            // graphicalOverlayComponent1
            // 
            graphicalOverlayComponent1.Owner = null;
            graphicalOverlayComponent1.Paint += graphicalOverlayComponent1_Paint;
            // 
            // keithley2306
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 612);
            Controls.Add(statusStrip1);
            Name = "keithley2306";
            Text = "keithley2306";
            Load += keithley2306_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel DeviceConnectStatusLabel;
        private ToolStripProgressBar toolStripProgressBar1;
        private HZH_Controls.Controls.GraphicalOverlayComponent graphicalOverlayComponent1;
    }
}