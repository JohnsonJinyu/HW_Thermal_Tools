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
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView3 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            TablePanel_Control = new DevExpress.Utils.Layout.TablePanel();
            dataGridView2 = new DataGridView();
            Charge_Voltage = new DataGridViewTextBoxColumn();
            Charge_Current = new DataGridViewTextBoxColumn();
            Charge_Time = new DataGridViewTextBoxColumn();
            Btn_Save = new Button();
            Btn_Stop = new Button();
            Btn_Pause = new Button();
            Btn_Start = new Button();
            RadioButton_ChargeTest = new RadioButton();
            ComboBox_Voltage_Select = new ComboBox();
            RadioButton_PowerTest = new RadioButton();
            Btn_ReCheckDevice = new Button();
            Btn_Power_On = new Button();
            Btn_Power_Off = new Button();
            RadioButton_PowerTest = new RadioButton();
            Btn_ReCheckDevice = new Button();
            Btn_Power_On = new Button();
            Btn_Power_Off = new Button();
            statusStrip1 = new StatusStrip();
            StatusLabel_Device = new ToolStripStatusLabel();
            chartControl1 = new DevExpress.XtraCharts.ChartControl();
            Chart_Panel = new Panel();
            TabPanel_Chart_Control = new DevExpress.Utils.Layout.TablePanel();
            TextBox_Title_Display_Select = new TextBox();
            TextBox_Title_Freq = new TextBox();
            dataGridView1 = new DataGridView();
            DataItem = new DataGridViewTextBoxColumn();
            Min_Value = new DataGridViewTextBoxColumn();
            Max_Value = new DataGridViewTextBoxColumn();
            Current_Value = new DataGridViewTextBoxColumn();
            Ave_Value = new DataGridViewTextBoxColumn();
            ComboBox_DataFrequence = new ComboBox();
            CheckBox_PowerLineDisplay = new CheckBox();
            CheckBox_VoltageLineDisplay = new CheckBox();
            CheckBox_CurrentLineDisplay = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)TablePanel_Control).BeginInit();
            TablePanel_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView3).BeginInit();
            Chart_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TabPanel_Chart_Control).BeginInit();
            TabPanel_Chart_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // TablePanel_Control
            // 
            TablePanel_Control.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 36.61F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 42.87F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 30.52F) });
            TablePanel_Control.Controls.Add(dataGridView2);
            TablePanel_Control.Controls.Add(Btn_Save);
            TablePanel_Control.Controls.Add(Btn_Stop);
            TablePanel_Control.Controls.Add(Btn_Pause);
            TablePanel_Control.Controls.Add(Btn_Start);
            TablePanel_Control.Controls.Add(RadioButton_ChargeTest);
            TablePanel_Control.Controls.Add(ComboBox_Voltage_Select);
            TablePanel_Control.Controls.Add(RadioButton_PowerTest);
            TablePanel_Control.Controls.Add(Btn_ReCheckDevice);
            TablePanel_Control.Controls.Add(Btn_Power_On);
            TablePanel_Control.Controls.Add(Btn_Power_Off);
            TablePanel_Control.Dock = DockStyle.Right;
            TablePanel_Control.Location = new Point(1075, 0);
            TablePanel_Control.Name = "TablePanel_Control";
            TablePanel_Control.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 51.59999F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 51.6000023F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50.7997971F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 62.8000946F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 198.000458F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 77.2000656F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 83.600174F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 49.2000923F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F) });
            TablePanel_Control.Size = new Size(323, 680);
            TablePanel_Control.TabIndex = 0;
            TablePanel_Control.UseSkinIndents = true;
            // 
            // dataGridView2
            // 
            TablePanel_Control.SetColumn(dataGridView2, 0);
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Charge_Voltage, Charge_Current, Charge_Time });
            TablePanel_Control.SetColumnSpan(dataGridView2, 3);
            dataGridView2.Location = new Point(15, 232);
            dataGridView2.Name = "dataGridView2";
            TablePanel_Control.SetRow(dataGridView2, 4);
            dataGridView2.RowHeadersWidth = 51;
            TablePanel_Control.SetRowSpan(dataGridView2, 2);
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(293, 271);
            dataGridView2.TabIndex = 10;
            // 
            // Charge_Voltage
            // 
            Charge_Voltage.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Charge_Voltage.HeaderText = "Voltage";
            Charge_Voltage.MinimumWidth = 6;
            Charge_Voltage.Name = "Charge_Voltage";
            Charge_Voltage.Width = 85;
            // 
            // Charge_Current
            // 
            Charge_Current.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Charge_Current.HeaderText = "Current";
            Charge_Current.MinimumWidth = 6;
            Charge_Current.Name = "Charge_Current";
            Charge_Current.Width = 85;
            // 
            // Charge_Time
            // 
            Charge_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            Charge_Time.HeaderText = "Time";
            Charge_Time.MinimumWidth = 6;
            Charge_Time.Name = "Charge_Time";
            Charge_Time.Width = 70;
            // 
            // Btn_Save
            // 
            TablePanel_Control.SetColumn(Btn_Save, 0);
            Btn_Save.Location = new Point(15, 599);
            Btn_Save.Name = "Btn_Save";
            TablePanel_Control.SetRow(Btn_Save, 7);
            Btn_Save.Size = new Size(95, 29);
            Btn_Save.TabIndex = 9;
            Btn_Save.Text = "保存";
            Btn_Save.UseVisualStyleBackColor = true;
            // 
            // Btn_Stop
            // 
            TablePanel_Control.SetColumn(Btn_Stop, 2);
            Btn_Stop.Location = new Point(230, 532);
            Btn_Stop.Name = "Btn_Stop";
            TablePanel_Control.SetRow(Btn_Stop, 6);
            Btn_Stop.Size = new Size(78, 29);
            Btn_Stop.TabIndex = 8;
            Btn_Stop.Text = "停止";
            Btn_Stop.UseVisualStyleBackColor = true;
            // 
            // Btn_Pause
            // 
            TablePanel_Control.SetColumn(Btn_Pause, 1);
            Btn_Pause.Location = new Point(114, 532);
            Btn_Pause.Name = "Btn_Pause";
            TablePanel_Control.SetRow(Btn_Pause, 6);
            Btn_Pause.Size = new Size(112, 29);
            Btn_Pause.TabIndex = 7;
            Btn_Pause.Text = "暂停 / 继续";
            Btn_Pause.UseVisualStyleBackColor = true;
            // 
            // Btn_Start
            // 
            TablePanel_Control.SetColumn(Btn_Start, 0);
            Btn_Start.Location = new Point(15, 532);
            Btn_Start.Name = "Btn_Start";
            TablePanel_Control.SetRow(Btn_Start, 6);
            Btn_Start.Size = new Size(95, 29);
            Btn_Start.TabIndex = 6;
            Btn_Start.Text = "开始";
            Btn_Start.UseVisualStyleBackColor = true;
            // 
            // RadioButton_ChargeTest
            // 
            RadioButton_ChargeTest.AutoSize = true;
            RadioButton_ChargeTest.Dock = DockStyle.Fill;
            RadioButton_ChargeTest.Location = new Point(15, 169);
            RadioButton_ChargeTest.Name = "RadioButton_ChargeTest";
            RadioButton_ChargeTest.Size = new Size(97, 59);
            RadioButton_ChargeTest.TabIndex = 5;
            RadioButton_ChargeTest.TabStop = true;
            RadioButton_ChargeTest.Text = "充电测试";
            RadioButton_ChargeTest.UseVisualStyleBackColor = true;
            // 
            // ComboBox_Voltage_Select
            // 
            ComboBox_Voltage_Select.FormattingEnabled = true;
            ComboBox_Voltage_Select.Items.AddRange(new object[] { "3.5", "3.7", "3.9", "4.0" });
            ComboBox_Voltage_Select.Location = new Point(116, 127);
            ComboBox_Voltage_Select.Name = "ComboBox_Voltage_Select";
            ComboBox_Voltage_Select.Size = new Size(94, 26);
            ComboBox_Voltage_Select.TabIndex = 4;
            ComboBox_Voltage_Select.Text = "3.7";
            // 
            // RadioButton_PowerTest
            // 
            RadioButton_PowerTest.AutoSize = true;
            RadioButton_PowerTest.Dock = DockStyle.Fill;
            RadioButton_PowerTest.Location = new Point(15, 118);
            RadioButton_PowerTest.Name = "RadioButton_PowerTest";
            RadioButton_PowerTest.Size = new Size(97, 47);
            RadioButton_PowerTest.TabIndex = 3;
            RadioButton_PowerTest.TabStop = true;
            RadioButton_PowerTest.Text = "功耗测试";
            RadioButton_PowerTest.UseVisualStyleBackColor = true;
            // 
            // Btn_ReCheckDevice
            // 
            Btn_ReCheckDevice.Location = new Point(15, 75);
            Btn_ReCheckDevice.Name = "Btn_ReCheckDevice";
            Btn_ReCheckDevice.Size = new Size(195, 29);
            Btn_ReCheckDevice.TabIndex = 2;
            Btn_ReCheckDevice.Text = "检查设备连接";
            Btn_ReCheckDevice.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_On
            // 
            TablePanel_Control.SetColumn(Btn_Power_On, 1);
            Btn_Power_On.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Power_On.Location = new Point(114, 14);
            Btn_Power_On.Name = "Btn_Power_On";
            TablePanel_Control.SetRow(Btn_Power_On, 0);
            Btn_Power_On.Size = new Size(112, 48);
            Btn_Power_On.TabIndex = 1;
            Btn_Power_On.Text = "Ponwer On";
            Btn_Power_On.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_Off
            // 
            Btn_Power_Off.Dock = DockStyle.Fill;
            Btn_Power_Off.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Power_Off.Location = new Point(15, 14);
            Btn_Power_Off.Name = "Btn_Power_Off";
            Btn_Power_Off.Size = new Size(97, 48);
            Btn_Power_Off.TabIndex = 0;
            Btn_Power_Off.Text = "Power Off";
            Btn_Power_Off.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel_Device });
            statusStrip1.Location = new Point(0, 654);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1075, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel_Device
            // 
            StatusLabel_Device.Name = "StatusLabel_Device";
            StatusLabel_Device.Size = new Size(84, 20);
            StatusLabel_Device.Text = "设备已连接";
            // 
            // chartControl1
            // 
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.EnableAxisXScrolling = true;
            swiftPlotDiagram1.EnableAxisXZooming = true;
            swiftPlotDiagram1.EnableAxisYScrolling = true;
            swiftPlotDiagram1.EnableAxisYZooming = true;
            chartControl1.Diagram = swiftPlotDiagram1;
            chartControl1.Dock = DockStyle.Fill;
            chartControl1.Legend.LegendID = -1;
            chartControl1.Location = new Point(0, 0);
            chartControl1.Name = "chartControl1";
            series1.Name = "Power";
            series1.SeriesID = 1;
            series1.View = swiftPlotSeriesView1;
            series2.Name = "Voltage";
            series2.SeriesID = 2;
            series2.View = swiftPlotSeriesView2;
            series3.Name = "Current";
            series3.SeriesID = 3;
            series3.View = swiftPlotSeriesView3;
            chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2, series3 };
            chartControl1.Size = new Size(1075, 463);
            chartControl1.TabIndex = 2;
            // 
            // Chart_Panel
            // 
            Chart_Panel.Controls.Add(chartControl1);
            Chart_Panel.Dock = DockStyle.Top;
            Chart_Panel.Location = new Point(0, 0);
            Chart_Panel.Name = "Chart_Panel";
            Chart_Panel.Size = new Size(1075, 463);
            Chart_Panel.TabIndex = 4;
            // 
            // TabPanel_Chart_Control
            // 
            TabPanel_Chart_Control.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 96.49F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 22.89F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20.62F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 20F) });
            TabPanel_Chart_Control.Controls.Add(TextBox_Title_Display_Select);
            TabPanel_Chart_Control.Controls.Add(TextBox_Title_Freq);
            TabPanel_Chart_Control.Controls.Add(dataGridView1);
            TabPanel_Chart_Control.Controls.Add(ComboBox_DataFrequence);
            TabPanel_Chart_Control.Controls.Add(CheckBox_PowerLineDisplay);
            TabPanel_Chart_Control.Controls.Add(CheckBox_VoltageLineDisplay);
            TabPanel_Chart_Control.Controls.Add(CheckBox_CurrentLineDisplay);
            TabPanel_Chart_Control.Dock = DockStyle.Fill;
            TabPanel_Chart_Control.Location = new Point(0, 463);
            TabPanel_Chart_Control.Name = "TabPanel_Chart_Control";
            TabPanel_Chart_Control.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 42.7999763F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 41.9999962F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 38.00004F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 56.3999939F) });
            TabPanel_Chart_Control.Size = new Size(1075, 191);
            TabPanel_Chart_Control.TabIndex = 5;
            TabPanel_Chart_Control.UseSkinIndents = true;
            // 
            // TextBox_Title_Display_Select
            // 
            TextBox_Title_Display_Select.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabPanel_Chart_Control.SetColumn(TextBox_Title_Display_Select, 1);
            TextBox_Title_Display_Select.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TextBox_Title_Display_Select.Location = new Point(648, 20);
            TextBox_Title_Display_Select.Name = "TextBox_Title_Display_Select";
            TabPanel_Chart_Control.SetRow(TextBox_Title_Display_Select, 0);
            TextBox_Title_Display_Select.Size = new Size(146, 26);
            TextBox_Title_Display_Select.TabIndex = 6;
            TextBox_Title_Display_Select.Text = "显示选项";
            // 
            // TextBox_Title_Freq
            // 
            TabPanel_Chart_Control.SetColumn(TextBox_Title_Freq, 2);
            TextBox_Title_Freq.Location = new Point(798, 63);
            TextBox_Title_Freq.Name = "TextBox_Title_Freq";
            TabPanel_Chart_Control.SetRow(TextBox_Title_Freq, 1);
            TextBox_Title_Freq.Size = new Size(131, 26);
            TextBox_Title_Freq.TabIndex = 5;
            TextBox_Title_Freq.Text = "采样频率";
            // 
            // dataGridView1
            // 
            TabPanel_Chart_Control.SetColumn(dataGridView1, 0);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { DataItem, Min_Value, Max_Value, Current_Value, Ave_Value });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(15, 14);
            dataGridView1.Name = "dataGridView1";
            TabPanel_Chart_Control.SetRow(dataGridView1, 0);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            TabPanel_Chart_Control.SetRowSpan(dataGridView1, 4);
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(629, 162);
            dataGridView1.TabIndex = 4;
            // 
            // DataItem
            // 
            DataItem.HeaderText = "Item";
            DataItem.MinimumWidth = 6;
            DataItem.Name = "DataItem";
            DataItem.Width = 125;
            // 
            // Min_Value
            // 
            Min_Value.HeaderText = "Min";
            Min_Value.MinimumWidth = 6;
            Min_Value.Name = "Min_Value";
            Min_Value.Width = 125;
            // 
            // Max_Value
            // 
            Max_Value.HeaderText = "Max";
            Max_Value.MinimumWidth = 6;
            Max_Value.Name = "Max_Value";
            Max_Value.Width = 125;
            // 
            // Current_Value
            // 
            Current_Value.HeaderText = "Current";
            Current_Value.MinimumWidth = 6;
            Current_Value.Name = "Current_Value";
            Current_Value.Width = 125;
            // 
            // Ave_Value
            // 
            Ave_Value.HeaderText = "Ave";
            Ave_Value.MinimumWidth = 6;
            Ave_Value.Name = "Ave_Value";
            Ave_Value.Width = 125;
            // 
            // ComboBox_DataFrequence
            // 
            TabPanel_Chart_Control.SetColumn(ComboBox_DataFrequence, 3);
            ComboBox_DataFrequence.FormattingEnabled = true;
            ComboBox_DataFrequence.Items.AddRange(new object[] { "1 S", "2 S", "5 S", "10 S", "15 S", "30 S" });
            ComboBox_DataFrequence.Location = new Point(933, 63);
            ComboBox_DataFrequence.Name = "ComboBox_DataFrequence";
            TabPanel_Chart_Control.SetRow(ComboBox_DataFrequence, 1);
            ComboBox_DataFrequence.Size = new Size(127, 26);
            ComboBox_DataFrequence.TabIndex = 3;
            // 
            // CheckBox_PowerLineDisplay
            // 
            CheckBox_PowerLineDisplay.AutoSize = true;
            TabPanel_Chart_Control.SetColumn(CheckBox_PowerLineDisplay, 1);
            CheckBox_PowerLineDisplay.Location = new Point(648, 145);
            CheckBox_PowerLineDisplay.Name = "CheckBox_PowerLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_PowerLineDisplay, 3);
            CheckBox_PowerLineDisplay.Size = new Size(90, 22);
            CheckBox_PowerLineDisplay.TabIndex = 2;
            CheckBox_PowerLineDisplay.Text = "显示功耗";
            CheckBox_PowerLineDisplay.UseVisualStyleBackColor = true;
            // 
            // CheckBox_VoltageLineDisplay
            // 
            CheckBox_VoltageLineDisplay.AutoSize = true;
            CheckBox_VoltageLineDisplay.Checked = true;
            CheckBox_VoltageLineDisplay.CheckState = CheckState.Checked;
            TabPanel_Chart_Control.SetColumn(CheckBox_VoltageLineDisplay, 1);
            CheckBox_VoltageLineDisplay.Location = new Point(648, 105);
            CheckBox_VoltageLineDisplay.Name = "CheckBox_VoltageLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_VoltageLineDisplay, 2);
            CheckBox_VoltageLineDisplay.Size = new Size(90, 22);
            CheckBox_VoltageLineDisplay.TabIndex = 1;
            CheckBox_VoltageLineDisplay.Text = "显示电压";
            CheckBox_VoltageLineDisplay.UseVisualStyleBackColor = true;
            // 
            // CheckBox_CurrentLineDisplay
            // 
            CheckBox_CurrentLineDisplay.AutoSize = true;
            CheckBox_CurrentLineDisplay.Checked = true;
            CheckBox_CurrentLineDisplay.CheckState = CheckState.Checked;
            TabPanel_Chart_Control.SetColumn(CheckBox_CurrentLineDisplay, 1);
            CheckBox_CurrentLineDisplay.Location = new Point(648, 65);
            CheckBox_CurrentLineDisplay.Name = "CheckBox_CurrentLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_CurrentLineDisplay, 1);
            CheckBox_CurrentLineDisplay.Size = new Size(90, 22);
            CheckBox_CurrentLineDisplay.TabIndex = 0;
            CheckBox_CurrentLineDisplay.Text = "显示电流";
            CheckBox_CurrentLineDisplay.UseVisualStyleBackColor = true;
            // 
            // keithley2306
            // 
            Appearance.BackColor = Color.White;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(8F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 680);
            Controls.Add(TabPanel_Chart_Control);
            Controls.Add(Chart_Panel);
            Controls.Add(statusStrip1);
            Controls.Add(TablePanel_Control);
            MinimumSize = new Size(1400, 720);
            Name = "keithley2306";
            Text = "keithley2306";
            Load += keithley2306_Load;
            ((System.ComponentModel.ISupportInitialize)TablePanel_Control).EndInit();
            TablePanel_Control.ResumeLayout(false);
            TablePanel_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)series2).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)series3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            Chart_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TabPanel_Chart_Control).EndInit();
            TabPanel_Chart_Control.ResumeLayout(false);
            TabPanel_Chart_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel TablePanel_Control;
        private RadioButton RadioButton_PowerTest;
        private Button Btn_ReCheckDevice;
        private Button Btn_Power_On;
        private Button Btn_Power_Off;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel_Device;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraGrid.Columns.GridColumn Cur_Data;
        private ComboBox ComboBox_Voltage_Select;
        private Panel Chart_Panel;
        private DevExpress.Utils.Layout.TablePanel TabPanel_Chart_Control;
        private Button Btn_Save;
        private Button Btn_Stop;
        private Button Btn_Pause;
        private Button Btn_Start;
        private RadioButton RadioButton_ChargeTest;
        private CheckBox CheckBox_CurrentLineDisplay;
        private ComboBox ComboBox_DataFrequence;
        private CheckBox CheckBox_PowerLineDisplay;
        private CheckBox CheckBox_VoltageLineDisplay;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn DataItem;
        private DataGridViewTextBoxColumn Min_Value;
        private DataGridViewTextBoxColumn Max_Value;
        private DataGridViewTextBoxColumn Current_Value;
        private DataGridViewTextBoxColumn Ave_Value;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn Charge_Voltage;
        private DataGridViewTextBoxColumn Charge_Current;
        private DataGridViewTextBoxColumn Charge_Time;
        private TextBox TextBox_Title_Freq;
        private TextBox TextBox_Title_Display_Select;
    }
}