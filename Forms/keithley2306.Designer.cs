﻿namespace HW_Thermal_Tools.Forms
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
            tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            radioButton1 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)tablePanel1).BeginInit();
            tablePanel1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tablePanel1
            // 
            tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 37.2F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25.32F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 47.48F) });
            tablePanel1.Controls.Add(radioButton1);
            tablePanel1.Controls.Add(button3);
            tablePanel1.Controls.Add(button2);
            tablePanel1.Controls.Add(button1);
            tablePanel1.Dock = DockStyle.Right;
            tablePanel1.Location = new Point(691, 0);
            tablePanel1.Name = "tablePanel1";
            tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 42.8F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 41.1999855F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 27.600008F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F) });
            tablePanel1.Size = new Size(425, 598);
            tablePanel1.TabIndex = 0;
            tablePanel1.UseSkinIndents = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 572);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(691, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(167, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // button1
            // 
            tablePanel1.SetColumn(button1, 0);
            button1.Location = new Point(15, 19);
            button1.Name = "button1";
            tablePanel1.SetRow(button1, 0);
            button1.Size = new Size(131, 29);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            tablePanel1.SetColumn(button2, 1);
            button2.Location = new Point(150, 14);
            button2.Name = "button2";
            tablePanel1.SetRow(button2, 0);
            button2.Size = new Size(88, 39);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            tablePanel1.SetColumn(button3, 2);
            button3.Location = new Point(242, 19);
            button3.Name = "button3";
            tablePanel1.SetRow(button3, 0);
            button3.Size = new Size(168, 29);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            tablePanel1.SetColumn(radioButton1, 0);
            radioButton1.Location = new Point(15, 64);
            radioButton1.Name = "radioButton1";
            tablePanel1.SetRow(radioButton1, 1);
            radioButton1.Size = new Size(111, 22);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // keithley2306
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1116, 598);
            Controls.Add(statusStrip1);
            Controls.Add(tablePanel1);
            Name = "keithley2306";
            Text = "keithley2306";
            ((System.ComponentModel.ISupportInitialize)tablePanel1).EndInit();
            tablePanel1.ResumeLayout(false);
            tablePanel1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private RadioButton radioButton1;
        private Button button3;
        private Button button2;
        private Button button1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}