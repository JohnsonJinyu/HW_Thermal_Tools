using DevExpress.XtraCharts;

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
            SwiftPlotDiagram swiftPlotDiagram2 = new SwiftPlotDiagram();
            Series series4 = new Series();
            SwiftPlotSeriesView swiftPlotSeriesView4 = new SwiftPlotSeriesView();
            Series series5 = new Series();
            SwiftPlotSeriesView swiftPlotSeriesView5 = new SwiftPlotSeriesView();
            Series series6 = new Series();
            SwiftPlotSeriesView swiftPlotSeriesView6 = new SwiftPlotSeriesView();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            TabPanel_Control = new DevExpress.Utils.Layout.TablePanel();
            Btn_Clear = new Button();
            Btn_Save = new Button();
            Btn_Stop = new Button();
            Btn_Pause = new Button();
            Btn_Start = new Button();
            DataUpdate_GridView = new DataGridView();
            Item_Data = new DataGridViewTextBoxColumn();
            CurrentData = new DataGridViewTextBoxColumn();
            Max_Data = new DataGridViewTextBoxColumn();
            Min_Data = new DataGridViewTextBoxColumn();
            Ave_Data = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            RadioButton_Charge_Test = new RadioButton();
            RadioButton_Power_Test = new RadioButton();
            Btn_RecheckDevice = new Button();
            Btn_Power_On = new Button();
            Btn_Power_Off = new Button();
            chartControl1 = new ChartControl();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TabPanel_Control).BeginInit();
            TabPanel_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataUpdate_GridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView6).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 721);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1259, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(167, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // TabPanel_Control
            // 
            TabPanel_Control.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            TabPanel_Control.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 37.2F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.04F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 40.76F) });
            TabPanel_Control.Controls.Add(Btn_Clear);
            TabPanel_Control.Controls.Add(Btn_Save);
            TabPanel_Control.Controls.Add(Btn_Stop);
            TabPanel_Control.Controls.Add(Btn_Pause);
            TabPanel_Control.Controls.Add(Btn_Start);
            TabPanel_Control.Controls.Add(DataUpdate_GridView);
            TabPanel_Control.Controls.Add(comboBox1);
            TabPanel_Control.Controls.Add(RadioButton_Charge_Test);
            TabPanel_Control.Controls.Add(RadioButton_Power_Test);
            TabPanel_Control.Controls.Add(Btn_RecheckDevice);
            TabPanel_Control.Controls.Add(Btn_Power_On);
            TabPanel_Control.Controls.Add(Btn_Power_Off);
            TabPanel_Control.Dock = DockStyle.Right;
            TabPanel_Control.Location = new Point(834, 0);
            TabPanel_Control.Name = "TabPanel_Control";
            TabPanel_Control.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 42.7999878F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45.9999924F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 209.2003F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 85.99994F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 186.000259F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 76.40002F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 26F) });
            TabPanel_Control.Size = new Size(425, 721);
            TabPanel_Control.TabIndex = 3;
            TabPanel_Control.UseSkinIndents = true;
            // 
            // Btn_Clear
            // 
            TabPanel_Control.SetColumn(Btn_Clear, 1);
            Btn_Clear.Dock = DockStyle.Fill;
            Btn_Clear.Location = new Point(150, 660);
            Btn_Clear.Name = "Btn_Clear";
            TabPanel_Control.SetRow(Btn_Clear, 6);
            Btn_Clear.Size = new Size(112, 46);
            Btn_Clear.TabIndex = 11;
            Btn_Clear.Text = "清除数据";
            Btn_Clear.UseVisualStyleBackColor = true;
            // 
            // Btn_Save
            // 
            TabPanel_Control.SetColumn(Btn_Save, 0);
            Btn_Save.Dock = DockStyle.Fill;
            Btn_Save.Location = new Point(15, 660);
            Btn_Save.Name = "Btn_Save";
            TabPanel_Control.SetRow(Btn_Save, 6);
            Btn_Save.Size = new Size(131, 46);
            Btn_Save.TabIndex = 10;
            Btn_Save.Text = "保存";
            Btn_Save.UseVisualStyleBackColor = true;
            // 
            // Btn_Stop
            // 
            TabPanel_Control.SetColumn(Btn_Stop, 2);
            Btn_Stop.Dock = DockStyle.Fill;
            Btn_Stop.Location = new Point(266, 584);
            Btn_Stop.Name = "Btn_Stop";
            TabPanel_Control.SetRow(Btn_Stop, 5);
            Btn_Stop.Size = new Size(144, 72);
            Btn_Stop.TabIndex = 9;
            Btn_Stop.Text = "停止";
            Btn_Stop.UseVisualStyleBackColor = true;
            // 
            // Btn_Pause
            // 
            TabPanel_Control.SetColumn(Btn_Pause, 1);
            Btn_Pause.Dock = DockStyle.Fill;
            Btn_Pause.Location = new Point(150, 584);
            Btn_Pause.Name = "Btn_Pause";
            TabPanel_Control.SetRow(Btn_Pause, 5);
            Btn_Pause.Size = new Size(112, 72);
            Btn_Pause.TabIndex = 8;
            Btn_Pause.Text = "暂停 / 继续";
            Btn_Pause.UseVisualStyleBackColor = true;
            // 
            // Btn_Start
            // 
            TabPanel_Control.SetColumn(Btn_Start, 0);
            Btn_Start.Dock = DockStyle.Fill;
            Btn_Start.Location = new Point(15, 584);
            Btn_Start.Name = "Btn_Start";
            TabPanel_Control.SetRow(Btn_Start, 5);
            Btn_Start.Size = new Size(131, 72);
            Btn_Start.TabIndex = 7;
            Btn_Start.Text = "开始";
            Btn_Start.UseVisualStyleBackColor = true;
            // 
            // DataUpdate_GridView
            // 
            TabPanel_Control.SetColumn(DataUpdate_GridView, 0);
            DataUpdate_GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataUpdate_GridView.Columns.AddRange(new DataGridViewColumn[] { Item_Data, CurrentData, Max_Data, Min_Data, Ave_Data });
            TabPanel_Control.SetColumnSpan(DataUpdate_GridView, 3);
            DataUpdate_GridView.Dock = DockStyle.Fill;
            DataUpdate_GridView.Location = new Point(15, 103);
            DataUpdate_GridView.Name = "DataUpdate_GridView";
            DataUpdate_GridView.ReadOnly = true;
            DataUpdate_GridView.RightToLeft = RightToLeft.No;
            TabPanel_Control.SetRow(DataUpdate_GridView, 2);
            DataUpdate_GridView.RowHeadersVisible = false;
            DataUpdate_GridView.RowHeadersWidth = 35;
            DataUpdate_GridView.RowTemplate.Height = 29;
            DataUpdate_GridView.RowTemplate.ReadOnly = true;
            DataUpdate_GridView.Size = new Size(395, 205);
            DataUpdate_GridView.TabIndex = 6;
            DataUpdate_GridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Item_Data
            // 
            Item_Data.HeaderText = "Item";
            Item_Data.MinimumWidth = 6;
            Item_Data.Name = "Item_Data";
            Item_Data.ReadOnly = true;
            Item_Data.Width = 80;
            // 
            // CurrentData
            // 
            CurrentData.HeaderText = "实时";
            CurrentData.MinimumWidth = 6;
            CurrentData.Name = "CurrentData";
            CurrentData.ReadOnly = true;
            CurrentData.Width = 80;
            // 
            // Max_Data
            // 
            Max_Data.HeaderText = "最大";
            Max_Data.MinimumWidth = 6;
            Max_Data.Name = "Max_Data";
            Max_Data.ReadOnly = true;
            Max_Data.Width = 80;
            // 
            // Min_Data
            // 
            Min_Data.HeaderText = "最小";
            Min_Data.MinimumWidth = 6;
            Min_Data.Name = "Min_Data";
            Min_Data.ReadOnly = true;
            Min_Data.Width = 80;
            // 
            // Ave_Data
            // 
            Ave_Data.HeaderText = "平均";
            Ave_Data.MinimumWidth = 6;
            Ave_Data.Name = "Ave_Data";
            Ave_Data.ReadOnly = true;
            Ave_Data.Width = 80;
            // 
            // comboBox1
            // 
            TabPanel_Control.SetColumn(comboBox1, 1);
            comboBox1.FormattingEnabled = true;
            comboBox1.ItemHeight = 18;
            comboBox1.Items.AddRange(new object[] { "3.5", "3.7", "3.9", "4.0", "4.2" });
            comboBox1.Location = new Point(150, 64);
            comboBox1.Name = "comboBox1";
            TabPanel_Control.SetRow(comboBox1, 1);
            comboBox1.Size = new Size(112, 26);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "4.0";
            // 
            // RadioButton_Charge_Test
            // 
            RadioButton_Charge_Test.AutoSize = true;
            TabPanel_Control.SetColumn(RadioButton_Charge_Test, 0);
            TabPanel_Control.SetColumnSpan(RadioButton_Charge_Test, 2);
            RadioButton_Charge_Test.Location = new Point(15, 342);
            RadioButton_Charge_Test.Name = "RadioButton_Charge_Test";
            TabPanel_Control.SetRow(RadioButton_Charge_Test, 3);
            RadioButton_Charge_Test.Size = new Size(89, 22);
            RadioButton_Charge_Test.TabIndex = 4;
            RadioButton_Charge_Test.TabStop = true;
            RadioButton_Charge_Test.Text = "充电测试";
            RadioButton_Charge_Test.UseVisualStyleBackColor = true;
            // 
            // RadioButton_Power_Test
            // 
            RadioButton_Power_Test.AutoSize = true;
            TabPanel_Control.SetColumn(RadioButton_Power_Test, 0);
            RadioButton_Power_Test.Dock = DockStyle.Fill;
            RadioButton_Power_Test.Location = new Point(15, 57);
            RadioButton_Power_Test.Name = "RadioButton_Power_Test";
            TabPanel_Control.SetRow(RadioButton_Power_Test, 1);
            RadioButton_Power_Test.Size = new Size(131, 42);
            RadioButton_Power_Test.TabIndex = 3;
            RadioButton_Power_Test.TabStop = true;
            RadioButton_Power_Test.Text = "功耗测试";
            RadioButton_Power_Test.UseVisualStyleBackColor = true;
            // 
            // Btn_RecheckDevice
            // 
            TabPanel_Control.SetColumn(Btn_RecheckDevice, 2);
            Btn_RecheckDevice.Dock = DockStyle.Fill;
            Btn_RecheckDevice.Location = new Point(266, 14);
            Btn_RecheckDevice.Name = "Btn_RecheckDevice";
            TabPanel_Control.SetRow(Btn_RecheckDevice, 0);
            Btn_RecheckDevice.Size = new Size(144, 39);
            Btn_RecheckDevice.TabIndex = 2;
            Btn_RecheckDevice.Text = "检查设备连接";
            Btn_RecheckDevice.UseVisualStyleBackColor = true;
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
            ClientSize = new Size(1259, 747);
            Controls.Add(chartControl1);
            Controls.Add(TabPanel_Control);
            Controls.Add(statusStrip1);
            Name = "keithley2306";
            Text = "keithley2306";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TabPanel_Control).EndInit();
            TabPanel_Control.ResumeLayout(false);
            TabPanel_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataUpdate_GridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram2).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)series4).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView5).EndInit();
            ((System.ComponentModel.ISupportInitialize)series5).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView6).EndInit();
            ((System.ComponentModel.ISupportInitialize)series6).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartControl1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.Utils.Layout.TablePanel TabPanel_Control;
        private Button Btn_RecheckDevice;
        private Button Btn_Power_On;
        private Button Btn_Power_Off;
        private RadioButton RadioButton_Charge_Test;
        private RadioButton RadioButton_Power_Test;
        private ComboBox comboBox1;
        private ChartControl chartControl1;
        private DataGridView DataUpdate_GridView;
        private DataGridViewTextBoxColumn Item_Data;
        private DataGridViewTextBoxColumn CurrentData;
        private DataGridViewTextBoxColumn Max_Data;
        private DataGridViewTextBoxColumn Min_Data;
        private DataGridViewTextBoxColumn Ave_Data;
        private Button Btn_Clear;
        private Button Btn_Save;
        private Button Btn_Stop;
        private Button Btn_Pause;
        private Button Btn_Start;
    }
}