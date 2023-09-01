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
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { DevicesConnetStatuLabel });
            statusStrip1.Location = new Point(0, 429);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(974, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // DevicesConnetStatuLabel
            // 
            DevicesConnetStatuLabel.Name = "DevicesConnetStatuLabel";
            DevicesConnetStatuLabel.Size = new Size(68, 17);
            DevicesConnetStatuLabel.Text = "设备已连接";
            // 
            // RadioButton_PowerText_Model
            // 
            RadioButton_PowerText_Model.AutoSize = true;
            RadioButton_PowerText_Model.Dock = DockStyle.Fill;
            RadioButton_PowerText_Model.Location = new Point(3, 44);
            RadioButton_PowerText_Model.Name = "RadioButton_PowerText_Model";
            RadioButton_PowerText_Model.Size = new Size(97, 23);
            RadioButton_PowerText_Model.TabIndex = 2;
            RadioButton_PowerText_Model.TabStop = true;
            RadioButton_PowerText_Model.Text = "功耗测试";
            RadioButton_PowerText_Model.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Charge_Model
            // 
            RadioButton_Charge_Model.AutoSize = true;
            RadioButton_Charge_Model.Dock = DockStyle.Fill;
            RadioButton_Charge_Model.Location = new Point(3, 166);
            RadioButton_Charge_Model.Name = "RadioButton_Charge_Model";
            RadioButton_Charge_Model.Size = new Size(97, 24);
            RadioButton_Charge_Model.TabIndex = 3;
            RadioButton_Charge_Model.TabStop = true;
            RadioButton_Charge_Model.Text = "充电测试";
            RadioButton_Charge_Model.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_Off
            // 
            Btn_Power_Off.Dock = DockStyle.Fill;
            Btn_Power_Off.Location = new Point(3, 3);
            Btn_Power_Off.Name = "Btn_Power_Off";
            Btn_Power_Off.Size = new Size(97, 35);
            Btn_Power_Off.TabIndex = 4;
            Btn_Power_Off.Text = "Power_Off";
            Btn_Power_Off.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_On
            // 
            Btn_Power_On.Dock = DockStyle.Fill;
            Btn_Power_On.Location = new Point(106, 3);
            Btn_Power_On.Name = "Btn_Power_On";
            Btn_Power_On.Size = new Size(95, 35);
            Btn_Power_On.TabIndex = 5;
            Btn_Power_On.Text = "Power On";
            Btn_Power_On.UseVisualStyleBackColor = true;
            // 
            // DataGridView_CurrentInput
            // 
            DataGridView_CurrentInput.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridView_CurrentInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridView_CurrentInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_CurrentInput.Columns.AddRange(new DataGridViewColumn[] { Current, Voltage, Time });
            tableLayoutPanel_Control.SetColumnSpan(DataGridView_CurrentInput, 3);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft YaHei UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridView_CurrentInput.DefaultCellStyle = dataGridViewCellStyle2;
            DataGridView_CurrentInput.Location = new Point(3, 196);
            DataGridView_CurrentInput.Name = "DataGridView_CurrentInput";
            DataGridView_CurrentInput.RowTemplate.Height = 25;
            DataGridView_CurrentInput.Size = new Size(295, 163);
            DataGridView_CurrentInput.TabIndex = 7;
            DataGridView_CurrentInput.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Current
            // 
            Current.HeaderText = "Current（A）";
            Current.Name = "Current";
            // 
            // Voltage
            // 
            Voltage.HeaderText = "Voltage（V）";
            Voltage.Name = "Voltage";
            // 
            // Time
            // 
            Time.HeaderText = "Time(s)";
            Time.Name = "Time";
            // 
            // Btn_Check_Device
            // 
            Btn_Check_Device.Dock = DockStyle.Fill;
            Btn_Check_Device.Location = new Point(207, 3);
            Btn_Check_Device.Name = "Btn_Check_Device";
            Btn_Check_Device.Size = new Size(91, 35);
            Btn_Check_Device.TabIndex = 9;
            Btn_Check_Device.Text = "检查设备连接状态";
            Btn_Check_Device.UseVisualStyleBackColor = true;
            // 
            // Btn_Save
            // 
            Btn_Save.Dock = DockStyle.Fill;
            Btn_Save.Location = new Point(3, 400);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(97, 26);
            Btn_Save.TabIndex = 10;
            Btn_Save.Text = "保存";
            Btn_Save.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_Control
            // 
            tableLayoutPanel_Control.ColumnCount = 3;
            tableLayoutPanel_Control.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.4901962F));
            tableLayoutPanel_Control.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.5098038F));
            tableLayoutPanel_Control.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 97F));
            tableLayoutPanel_Control.Controls.Add(Btn_Power_Off, 0, 0);
            tableLayoutPanel_Control.Controls.Add(Btn_Power_On, 1, 0);
            tableLayoutPanel_Control.Controls.Add(Btn_Save, 0, 6);
            tableLayoutPanel_Control.Controls.Add(Btn_Check_Device, 2, 0);
            tableLayoutPanel_Control.Controls.Add(RadioButton_PowerText_Model, 0, 1);
            tableLayoutPanel_Control.Controls.Add(comboBox1, 1, 1);
            tableLayoutPanel_Control.Controls.Add(TextBox_PowerText_Result, 0, 2);
            tableLayoutPanel_Control.Controls.Add(RadioButton_Charge_Model, 0, 3);
            tableLayoutPanel_Control.Controls.Add(DataGridView_CurrentInput, 0, 4);
            tableLayoutPanel_Control.Controls.Add(Btn_Start_Text, 0, 5);
            tableLayoutPanel_Control.Controls.Add(Btn_Stop_Text, 2, 5);
            tableLayoutPanel_Control.Controls.Add(Btn_Pause_Continue, 1, 5);
            tableLayoutPanel_Control.Dock = DockStyle.Right;
            tableLayoutPanel_Control.Location = new Point(673, 0);
            tableLayoutPanel_Control.Name = "tableLayoutPanel_Control";
            tableLayoutPanel_Control.RowCount = 7;
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Percent, 58.3333321F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Percent, 41.6666679F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 93F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 169F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel_Control.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel_Control.Size = new Size(301, 429);
            tableLayoutPanel_Control.TabIndex = 11;
            // 
            // comboBox1
            // 
            tableLayoutPanel_Control.SetColumnSpan(comboBox1, 2);
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "3.5 V", "3.7 V", "4.0 V", "4.2 V" });
            comboBox1.Location = new Point(106, 44);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 25);
            comboBox1.TabIndex = 11;
            // 
            // TextBox_PowerText_Result
            // 
            tableLayoutPanel_Control.SetColumnSpan(TextBox_PowerText_Result, 3);
            TextBox_PowerText_Result.Dock = DockStyle.Fill;
            TextBox_PowerText_Result.Location = new Point(3, 73);
            TextBox_PowerText_Result.Multiline = true;
            TextBox_PowerText_Result.Name = "TextBox_PowerText_Result";
            TextBox_PowerText_Result.Size = new Size(295, 87);
            TextBox_PowerText_Result.TabIndex = 12;
            // 
            // Btn_Start_Text
            // 
            Btn_Start_Text.Dock = DockStyle.Fill;
            Btn_Start_Text.Location = new Point(3, 365);
            Btn_Start_Text.Name = "Btn_Start_Text";
            Btn_Start_Text.Size = new Size(97, 29);
            Btn_Start_Text.TabIndex = 13;
            Btn_Start_Text.Text = "开始";
            Btn_Start_Text.UseVisualStyleBackColor = true;
            // 
            // Btn_Stop_Text
            // 
            Btn_Stop_Text.Dock = DockStyle.Fill;
            Btn_Stop_Text.Location = new Point(207, 365);
            Btn_Stop_Text.Name = "Btn_Stop_Text";
            Btn_Stop_Text.Size = new Size(91, 29);
            Btn_Stop_Text.TabIndex = 14;
            Btn_Stop_Text.Text = "停止";
            Btn_Stop_Text.UseVisualStyleBackColor = true;
            // 
            // Btn_Pause_Continue
            // 
            Btn_Pause_Continue.Dock = DockStyle.Fill;
            Btn_Pause_Continue.Location = new Point(106, 365);
            Btn_Pause_Continue.Name = "Btn_Pause_Continue";
            Btn_Pause_Continue.Size = new Size(95, 29);
            Btn_Pause_Continue.TabIndex = 15;
            Btn_Pause_Continue.Text = "暂停 / 继续";
            Btn_Pause_Continue.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(673, 429);
            panel1.TabIndex = 12;
            // 
            // keithley2306
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 451);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel_Control);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { DeviceConnectStatusLabel, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 586);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1005, 26);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // Btn_Power_On
            // 
            TabPanel_Control.SetColumn(Btn_Power_On, 1);
            Btn_Power_On.Dock = DockStyle.Fill;
            Btn_Power_On.Location = new Point(150, 14);
            Btn_Power_On.Name = "Btn_Power_On";
            TabPanel_Control.SetRow(Btn_Power_On, 0);
            Btn_Power_On.Size = new Size(112, 39);
            Btn_Power_On.TabIndex = 1;
            Btn_Power_On.Text = "Power On";
            Btn_Power_On.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_Off
            // 
            TabPanel_Control.SetColumn(Btn_Power_Off, 0);
            Btn_Power_Off.Dock = DockStyle.Fill;
            Btn_Power_Off.Location = new Point(15, 14);
            Btn_Power_Off.Name = "Btn_Power_Off";
            TabPanel_Control.SetRow(Btn_Power_Off, 0);
            Btn_Power_Off.Size = new Size(131, 39);
            Btn_Power_Off.TabIndex = 0;
            Btn_Power_Off.Text = "Power Off";
            Btn_Power_Off.UseVisualStyleBackColor = true;
            // 
            // chartControl1
            // 
            swiftPlotDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram2.AxisY.MinorCount = 25;
            swiftPlotDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram2.EnableAxisXScrolling = true;
            swiftPlotDiagram2.EnableAxisXZooming = true;
            swiftPlotDiagram2.EnableAxisYScrolling = true;
            swiftPlotDiagram2.EnableAxisYZooming = true;
            swiftPlotDiagram2.RuntimePaneResize = true;
            chartControl1.Diagram = swiftPlotDiagram2;
            chartControl1.Dock = DockStyle.Fill;
            chartControl1.Legend.LegendID = -1;
            chartControl1.Location = new Point(0, 0);
            chartControl1.Name = "chartControl1";
            series4.Name = "Voltage";
            series4.SeriesID = 0;
            series4.View = swiftPlotSeriesView4;
            series5.Name = "Power";
            series5.SeriesID = 1;
            series5.View = swiftPlotSeriesView5;
            series6.Name = "Current";
            series6.SeriesID = 2;
            series6.View = swiftPlotSeriesView6;
            chartControl1.SeriesSerializable = new Series[] { series4, series5, series6 };
            chartControl1.Size = new Size(834, 721);
            chartControl1.TabIndex = 4;
            // 

            // keithley2306
            // 
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(1175, 698);
            Name = "keithley2306";
            Text = "keithley2306";

            ClientSize = new Size(1005, 612);
            Controls.Add(statusStrip1);
            Name = "keithley2306";
            Text = "keithley2306";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView_CurrentInput).EndInit();
            tableLayoutPanel_Control.ResumeLayout(false);
            tableLayoutPanel_Control.PerformLayout();

            ResumeLayout(false);
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel DevicesConnetStatuLabel;
        private RadioButton RadioButton_PowerText_Model;
        private RadioButton RadioButton_Charge_Model;
        private Button Btn_Power_Off;
        private Button Btn_Power_On;
        private DataGridView DataGridView_CurrentInput;
        private Button Btn_Check_Device;
        private Button Btn_Save;
        private DataGridViewTextBoxColumn Current;
        private DataGridViewTextBoxColumn Voltage;
        private DataGridViewTextBoxColumn Time;
        private TableLayoutPanel tableLayoutPanel_Control;
        private ComboBox comboBox1;
        private TextBox TextBox_PowerText_Result;
        private Button Btn_Start_Text;
        private Button Btn_Stop_Text;
        private Button Btn_Pause_Continue;
        private Panel panel1;
        private ToolStripStatusLabel DeviceConnectStatusLabel;
        private ToolStripProgressBar toolStripProgressBar1;
        private HZH_Controls.Controls.GraphicalOverlayComponent graphicalOverlayComponent1;

    }
}