namespace HW_Thermal_Tools.Forms
{
    partial class Keithley2306Form
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.SwiftPlotDiagramSecondaryAxisY swiftPlotDiagramSecondaryAxisy1 = new DevExpress.XtraCharts.SwiftPlotDiagramSecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView2 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView3 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            TablePanel_Control = new DevExpress.Utils.Layout.TablePanel();
            Label_Timer_Title = new Label();
            GaugeControl = new DevExpress.XtraGauges.Win.GaugeControl();
            digitalGauge1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            digitalComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            Label_Current_Lim_Select = new Label();
            Label_Voltage_Select = new Label();
            Combox_CurrentLim_Select = new ComboBox();
            Combox_Channel = new ComboBox();
            DataGridView_ChargeInput = new DataGridView();
            Btn_Save = new Button();
            Btn_Stop = new Button();
            Btn_Start = new Button();
            RadioButton_ChargeTest = new RadioButton();
            ComboBox_Voltage_Select = new ComboBox();
            RadioButton_PowerTest = new RadioButton();
            Btn_Power_On = new Button();
            Btn_Power_Off = new Button();
            ChartControl_Watchdog = new DevExpress.XtraCharts.ChartControl();
            Chart_Panel = new Panel();
            TabPanel_Chart_Control = new DevExpress.Utils.Layout.TablePanel();
            Label_ReadFrequence = new Label();
            Label_Display_Options = new Label();
            DataGridView_WhatchDog = new DataGridView();
            Min_Value = new DataGridViewTextBoxColumn();
            Max_Value = new DataGridViewTextBoxColumn();
            Current_Value = new DataGridViewTextBoxColumn();
            Ave_Value = new DataGridViewTextBoxColumn();
            ComboBox_DataFrequence = new ComboBox();
            CheckBox_PowerLineDisplay = new CheckBox();
            CheckBox_VoltageLineDisplay = new CheckBox();
            CheckBox_CurrentLineDisplay = new CheckBox();
            statusStrip1 = new StatusStrip();
            StatusLabel_DeviceStatus = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            Charge_Voltage = new DataGridViewTextBoxColumn();
            Charge_Current = new DataGridViewTextBoxColumn();
            Charge_Time = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)TablePanel_Control).BeginInit();
            TablePanel_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)digitalGauge1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)digitalComponent1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView_ChargeInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ChartControl_Watchdog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagramSecondaryAxisy1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)series3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView3).BeginInit();
            Chart_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TabPanel_Chart_Control).BeginInit();
            TabPanel_Chart_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView_WhatchDog).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // TablePanel_Control
            // 
            TablePanel_Control.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 39.64F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 37.68F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 32.68F) });
            TablePanel_Control.Controls.Add(Label_Timer_Title);
            TablePanel_Control.Controls.Add(GaugeControl);
            TablePanel_Control.Controls.Add(Label_Current_Lim_Select);
            TablePanel_Control.Controls.Add(Label_Voltage_Select);
            TablePanel_Control.Controls.Add(Combox_CurrentLim_Select);
            TablePanel_Control.Controls.Add(Combox_Channel);
            TablePanel_Control.Controls.Add(DataGridView_ChargeInput);
            TablePanel_Control.Controls.Add(Btn_Save);
            TablePanel_Control.Controls.Add(Btn_Stop);
            TablePanel_Control.Controls.Add(Btn_Start);
            TablePanel_Control.Controls.Add(RadioButton_ChargeTest);
            TablePanel_Control.Controls.Add(ComboBox_Voltage_Select);
            TablePanel_Control.Controls.Add(RadioButton_PowerTest);
            TablePanel_Control.Controls.Add(Btn_Power_On);
            TablePanel_Control.Controls.Add(Btn_Power_Off);
            TablePanel_Control.Dock = DockStyle.Right;
            TablePanel_Control.Location = new Point(794, 0);
            TablePanel_Control.Margin = new Padding(3, 2, 3, 2);
            TablePanel_Control.Name = "TablePanel_Control";
            TablePanel_Control.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45.59999F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40.6000023F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 45.7997971F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37.8000946F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 245.000458F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35.2000656F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 37.600174F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 130.200089F) });
            TablePanel_Control.Size = new Size(284, 548);
            TablePanel_Control.TabIndex = 0;
            TablePanel_Control.UseSkinIndents = true;
            // 
            // Label_Timer_Title
            // 
            Label_Timer_Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Label_Timer_Title.AutoSize = true;
            TablePanel_Control.SetColumn(Label_Timer_Title, 0);
            Label_Timer_Title.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Label_Timer_Title.Location = new Point(14, 511);
            Label_Timer_Title.Name = "Label_Timer_Title";
            TablePanel_Control.SetRow(Label_Timer_Title, 7);
            Label_Timer_Title.Size = new Size(72, 14);
            Label_Timer_Title.TabIndex = 19;
            Label_Timer_Title.Text = "已运行时间";
            Label_Timer_Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GaugeControl
            // 
            GaugeControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GaugeControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            TablePanel_Control.SetColumn(GaugeControl, 1);
            TablePanel_Control.SetColumnSpan(GaugeControl, 2);
            GaugeControl.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] { digitalGauge1 });
            GaugeControl.Location = new Point(107, 501);
            GaugeControl.Name = "GaugeControl";
            TablePanel_Control.SetRow(GaugeControl, 7);
            GaugeControl.Size = new Size(164, 34);
            GaugeControl.TabIndex = 18;
            // 
            // digitalGauge1
            // 
            digitalGauge1.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#EAECF1");
            digitalGauge1.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#7184BA");
            digitalGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] { digitalComponent1 });
            digitalGauge1.Bounds = new Rectangle(6, 6, 152, 22);
            digitalGauge1.DigitCount = 8;
            digitalGauge1.LetterSpacing = 2F;
            digitalGauge1.Name = "digitalGauge1";
            digitalGauge1.Padding = new DevExpress.XtraGauges.Core.Base.TextSpacing(2, 2, 2, 2);
            digitalGauge1.Text = "00:00:00";
            // 
            // digitalComponent1
            // 
            digitalComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(401.699982F, 63.9625F);
            digitalComponent1.Name = "digitalBackgroundLayerComponent1";
            digitalComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style16;
            digitalComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(2F, 0F);
            digitalComponent1.ZOrder = 1000;
            // 
            // Label_Current_Lim_Select
            // 
            Label_Current_Lim_Select.AutoSize = true;
            TablePanel_Control.SetColumn(Label_Current_Lim_Select, 1);
            Label_Current_Lim_Select.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Label_Current_Lim_Select.Location = new Point(108, 113);
            Label_Current_Lim_Select.Name = "Label_Current_Lim_Select";
            TablePanel_Control.SetRow(Label_Current_Lim_Select, 2);
            Label_Current_Lim_Select.Size = new Size(83, 14);
            Label_Current_Lim_Select.TabIndex = 17;
            Label_Current_Lim_Select.Text = "电流限制 / A";
            // 
            // Label_Voltage_Select
            // 
            Label_Voltage_Select.AutoSize = true;
            TablePanel_Control.SetColumn(Label_Voltage_Select, 1);
            Label_Voltage_Select.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Label_Voltage_Select.Location = new Point(108, 69);
            Label_Voltage_Select.Name = "Label_Voltage_Select";
            TablePanel_Control.SetRow(Label_Voltage_Select, 1);
            Label_Voltage_Select.Size = new Size(82, 14);
            Label_Voltage_Select.TabIndex = 16;
            Label_Voltage_Select.Text = "电压选择 / V";
            // 
            // Combox_CurrentLim_Select
            // 
            TablePanel_Control.SetColumn(Combox_CurrentLim_Select, 2);
            Combox_CurrentLim_Select.FormattingEnabled = true;
            Combox_CurrentLim_Select.Items.AddRange(new object[] { "1.0", "1.5", "2.0", "2.25", "3.0" });
            Combox_CurrentLim_Select.Location = new Point(197, 109);
            Combox_CurrentLim_Select.Name = "Combox_CurrentLim_Select";
            TablePanel_Control.SetRow(Combox_CurrentLim_Select, 2);
            Combox_CurrentLim_Select.Size = new Size(74, 22);
            Combox_CurrentLim_Select.TabIndex = 15;
            Combox_CurrentLim_Select.Text = "2.0";
            // 
            // Combox_Channel
            // 
            Combox_Channel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TablePanel_Control.SetColumn(Combox_Channel, 2);
            Combox_Channel.FormattingEnabled = true;
            Combox_Channel.Items.AddRange(new object[] { "CH1", "CH2" });
            Combox_Channel.Location = new Point(198, 20);
            Combox_Channel.Margin = new Padding(3, 2, 3, 2);
            Combox_Channel.Name = "Combox_Channel";
            TablePanel_Control.SetRow(Combox_Channel, 0);
            Combox_Channel.Size = new Size(72, 22);
            Combox_Channel.TabIndex = 11;
            Combox_Channel.Text = "CH1";
            // 
            // DataGridView_ChargeInput
            // 
            TablePanel_Control.SetColumn(DataGridView_ChargeInput, 0);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DataGridView_ChargeInput.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DataGridView_ChargeInput.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_ChargeInput.Columns.AddRange(new DataGridViewColumn[] { Charge_Voltage, Charge_Current, Charge_Time });
            TablePanel_Control.SetColumnSpan(DataGridView_ChargeInput, 3);
            DataGridView_ChargeInput.EditMode = DataGridViewEditMode.EditOnKeystroke;
            DataGridView_ChargeInput.Location = new Point(14, 183);
            DataGridView_ChargeInput.Margin = new Padding(3, 2, 3, 2);
            DataGridView_ChargeInput.Name = "DataGridView_ChargeInput";
            TablePanel_Control.SetRow(DataGridView_ChargeInput, 4);
            DataGridView_ChargeInput.RowHeadersVisible = false;
            DataGridView_ChargeInput.RowHeadersWidth = 51;
            DataGridView_ChargeInput.RowTemplate.Height = 29;
            DataGridView_ChargeInput.Size = new Size(256, 240);
            DataGridView_ChargeInput.TabIndex = 10;
            // 
            // Btn_Save
            // 
            Btn_Save.Dock = DockStyle.Fill;
            Btn_Save.Location = new Point(13, 461);
            Btn_Save.Margin = new Padding(3, 2, 3, 2);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(92, 34);
            Btn_Save.TabIndex = 9;
            Btn_Save.Text = "保存";
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // Btn_Stop
            // 
            Btn_Stop.Dock = DockStyle.Fill;
            Btn_Stop.Location = new Point(199, 426);
            Btn_Stop.Margin = new Padding(3, 2, 3, 2);
            Btn_Stop.Name = "Btn_Stop";
            Btn_Stop.Size = new Size(75, 32);
            Btn_Stop.TabIndex = 8;
            Btn_Stop.Text = "停止";
            Btn_Stop.UseVisualStyleBackColor = true;
            Btn_Stop.Click += Btn_Stop_Click;
            // 
            // Btn_Start
            // 
            Btn_Start.Dock = DockStyle.Fill;
            Btn_Start.Location = new Point(13, 426);
            Btn_Start.Margin = new Padding(3, 2, 3, 2);
            Btn_Start.Name = "Btn_Start";
            Btn_Start.Size = new Size(92, 32);
            Btn_Start.TabIndex = 6;
            Btn_Start.Text = "开始";
            Btn_Start.UseVisualStyleBackColor = true;
            Btn_Start.Click += Btn_Start_Click;
            // 
            // RadioButton_ChargeTest
            // 
            RadioButton_ChargeTest.AutoSize = true;
            TablePanel_Control.SetColumn(RadioButton_ChargeTest, 0);
            RadioButton_ChargeTest.Location = new Point(14, 153);
            RadioButton_ChargeTest.Margin = new Padding(3, 2, 3, 2);
            RadioButton_ChargeTest.Name = "RadioButton_ChargeTest";
            TablePanel_Control.SetRow(RadioButton_ChargeTest, 3);
            RadioButton_ChargeTest.Size = new Size(73, 18);
            RadioButton_ChargeTest.TabIndex = 5;
            RadioButton_ChargeTest.Text = "充电测试";
            RadioButton_ChargeTest.UseVisualStyleBackColor = true;
            // 
            // ComboBox_Voltage_Select
            // 
            TablePanel_Control.SetColumn(ComboBox_Voltage_Select, 2);
            ComboBox_Voltage_Select.FormattingEnabled = true;
            ComboBox_Voltage_Select.Items.AddRange(new object[] { "3.5", "3.7", "3.9", "4.0" });
            ComboBox_Voltage_Select.Location = new Point(198, 65);
            ComboBox_Voltage_Select.Margin = new Padding(3, 2, 3, 2);
            ComboBox_Voltage_Select.Name = "ComboBox_Voltage_Select";
            TablePanel_Control.SetRow(ComboBox_Voltage_Select, 1);
            ComboBox_Voltage_Select.Size = new Size(72, 22);
            ComboBox_Voltage_Select.TabIndex = 4;
            ComboBox_Voltage_Select.Text = "3.7";
            // 
            // RadioButton_PowerTest
            // 
            RadioButton_PowerTest.AutoSize = true;
            RadioButton_PowerTest.Checked = true;
            TablePanel_Control.SetColumn(RadioButton_PowerTest, 0);
            RadioButton_PowerTest.Location = new Point(14, 67);
            RadioButton_PowerTest.Margin = new Padding(3, 2, 3, 2);
            RadioButton_PowerTest.Name = "RadioButton_PowerTest";
            TablePanel_Control.SetRow(RadioButton_PowerTest, 1);
            RadioButton_PowerTest.Size = new Size(73, 18);
            RadioButton_PowerTest.TabIndex = 3;
            RadioButton_PowerTest.TabStop = true;
            RadioButton_PowerTest.Text = "功耗测试";
            RadioButton_PowerTest.UseVisualStyleBackColor = true;
            // 
            // Btn_Power_On
            // 
            TablePanel_Control.SetColumn(Btn_Power_On, 1);
            Btn_Power_On.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Power_On.Location = new Point(108, 17);
            Btn_Power_On.Margin = new Padding(3, 2, 3, 2);
            Btn_Power_On.Name = "Btn_Power_On";
            TablePanel_Control.SetRow(Btn_Power_On, 0);
            Btn_Power_On.Size = new Size(84, 31);
            Btn_Power_On.TabIndex = 1;
            Btn_Power_On.Text = "Ponwer On";
            Btn_Power_On.UseVisualStyleBackColor = true;
            Btn_Power_On.Click += Btn_Power_On_Click;
            // 
            // Btn_Power_Off
            // 
            TablePanel_Control.SetColumn(Btn_Power_Off, 0);
            Btn_Power_Off.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Btn_Power_Off.Location = new Point(14, 17);
            Btn_Power_Off.Margin = new Padding(3, 2, 3, 2);
            Btn_Power_Off.Name = "Btn_Power_Off";
            TablePanel_Control.SetRow(Btn_Power_Off, 0);
            Btn_Power_Off.Size = new Size(88, 31);
            Btn_Power_Off.TabIndex = 0;
            Btn_Power_Off.Text = "Power Off";
            Btn_Power_Off.UseVisualStyleBackColor = true;
            Btn_Power_Off.Click += Btn_Power_Off_Click;
            // 
            // ChartControl_Watchdog
            // 
            ChartControl_Watchdog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.EnableAxisXScrolling = true;
            swiftPlotDiagram1.EnableAxisXZooming = true;
            swiftPlotDiagram1.EnableAxisYScrolling = true;
            swiftPlotDiagram1.EnableAxisYZooming = true;
            swiftPlotDiagramSecondaryAxisy1.AxisID = 0;
            swiftPlotDiagramSecondaryAxisy1.Name = "Secondary AxisY 1";
            swiftPlotDiagramSecondaryAxisy1.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SwiftPlotDiagramSecondaryAxisY[] { swiftPlotDiagramSecondaryAxisy1 });
            ChartControl_Watchdog.Diagram = swiftPlotDiagram1;
            ChartControl_Watchdog.Legend.LegendID = -1;
            ChartControl_Watchdog.Location = new Point(0, 0);
            ChartControl_Watchdog.Margin = new Padding(3, 2, 3, 2);
            ChartControl_Watchdog.Name = "ChartControl_Watchdog";
            series1.Name = "Power(mW)";
            series1.SeriesID = 1;
            swiftPlotSeriesView1.Color = Color.Lime;
            series1.View = swiftPlotSeriesView1;
            series2.Name = "Voltage(V)";
            series2.SeriesID = 2;
            swiftPlotSeriesView2.AxisYName = "Secondary AxisY 1";
            swiftPlotSeriesView2.Color = Color.Blue;
            series2.View = swiftPlotSeriesView2;
            series3.Name = "Current(mA)";
            series3.SeriesID = 3;
            swiftPlotSeriesView3.Color = Color.Red;
            series3.View = swiftPlotSeriesView3;
            ChartControl_Watchdog.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2, series3 };
            ChartControl_Watchdog.Size = new Size(788, 370);
            ChartControl_Watchdog.TabIndex = 2;
            // 
            // Chart_Panel
            // 
            Chart_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Chart_Panel.Controls.Add(ChartControl_Watchdog);
            Chart_Panel.Location = new Point(0, 0);
            Chart_Panel.Margin = new Padding(3, 2, 3, 2);
            Chart_Panel.Name = "Chart_Panel";
            Chart_Panel.Size = new Size(788, 384);
            Chart_Panel.TabIndex = 4;
            // 
            // TabPanel_Chart_Control
            // 
            TabPanel_Chart_Control.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] { new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 450F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 12.1F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 86F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 79F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 25.54F), new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 12.06F) });
            TabPanel_Chart_Control.Controls.Add(Label_ReadFrequence);
            TabPanel_Chart_Control.Controls.Add(Label_Display_Options);
            TabPanel_Chart_Control.Controls.Add(DataGridView_WhatchDog);
            TabPanel_Chart_Control.Controls.Add(ComboBox_DataFrequence);
            TabPanel_Chart_Control.Controls.Add(CheckBox_PowerLineDisplay);
            TabPanel_Chart_Control.Controls.Add(CheckBox_VoltageLineDisplay);
            TabPanel_Chart_Control.Controls.Add(CheckBox_CurrentLineDisplay);
            TabPanel_Chart_Control.Dock = DockStyle.Bottom;
            TabPanel_Chart_Control.Location = new Point(0, 388);
            TabPanel_Chart_Control.Margin = new Padding(3, 2, 3, 2);
            TabPanel_Chart_Control.Name = "TabPanel_Chart_Control";
            TabPanel_Chart_Control.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] { new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 35.7999763F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 25.9999962F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 27.0000381F), new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 56.3999939F) });
            TabPanel_Chart_Control.Size = new Size(794, 136);
            TabPanel_Chart_Control.TabIndex = 5;
            TabPanel_Chart_Control.UseSkinIndents = true;
            // 
            // Label_ReadFrequence
            // 
            Label_ReadFrequence.AutoSize = true;
            TabPanel_Chart_Control.SetColumn(Label_ReadFrequence, 3);
            Label_ReadFrequence.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Label_ReadFrequence.Location = new Point(588, 21);
            Label_ReadFrequence.Name = "Label_ReadFrequence";
            TabPanel_Chart_Control.SetRow(Label_ReadFrequence, 0);
            Label_ReadFrequence.Size = new Size(59, 14);
            Label_ReadFrequence.TabIndex = 7;
            Label_ReadFrequence.Text = "采样频率";
            // 
            // Label_Display_Options
            // 
            Label_Display_Options.AutoSize = true;
            TabPanel_Chart_Control.SetColumn(Label_Display_Options, 2);
            Label_Display_Options.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Label_Display_Options.Location = new Point(502, 21);
            Label_Display_Options.Name = "Label_Display_Options";
            TabPanel_Chart_Control.SetRow(Label_Display_Options, 0);
            Label_Display_Options.Size = new Size(59, 14);
            Label_Display_Options.TabIndex = 6;
            Label_Display_Options.Text = "显示选项";
            // 
            // DataGridView_WhatchDog
            // 
            DataGridView_WhatchDog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            TabPanel_Chart_Control.SetColumn(DataGridView_WhatchDog, 0);
            DataGridView_WhatchDog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridView_WhatchDog.Columns.AddRange(new DataGridViewColumn[] { Min_Value, Max_Value, Current_Value, Ave_Value });
            DataGridView_WhatchDog.Dock = DockStyle.Fill;
            DataGridView_WhatchDog.Location = new Point(14, 12);
            DataGridView_WhatchDog.Margin = new Padding(3, 2, 3, 2);
            DataGridView_WhatchDog.Name = "DataGridView_WhatchDog";
            DataGridView_WhatchDog.ReadOnly = true;
            TabPanel_Chart_Control.SetRow(DataGridView_WhatchDog, 0);
            DataGridView_WhatchDog.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DataGridView_WhatchDog.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DataGridView_WhatchDog.RowHeadersWidth = 120;
            TabPanel_Chart_Control.SetRowSpan(DataGridView_WhatchDog, 4);
            DataGridView_WhatchDog.RowTemplate.Height = 29;
            DataGridView_WhatchDog.Size = new Size(444, 111);
            DataGridView_WhatchDog.TabIndex = 4;
            // 
            // Min_Value
            // 
            Min_Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Min_Value.HeaderText = "Min";
            Min_Value.MinimumWidth = 6;
            Min_Value.Name = "Min_Value";
            Min_Value.ReadOnly = true;
            Min_Value.Width = 80;
            // 
            // Max_Value
            // 
            Max_Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Max_Value.HeaderText = "Max";
            Max_Value.MinimumWidth = 6;
            Max_Value.Name = "Max_Value";
            Max_Value.ReadOnly = true;
            Max_Value.Width = 80;
            // 
            // Current_Value
            // 
            Current_Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Current_Value.HeaderText = "Current";
            Current_Value.MinimumWidth = 6;
            Current_Value.Name = "Current_Value";
            Current_Value.ReadOnly = true;
            Current_Value.Width = 80;
            // 
            // Ave_Value
            // 
            Ave_Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Ave_Value.HeaderText = "Ave";
            Ave_Value.MinimumWidth = 6;
            Ave_Value.Name = "Ave_Value";
            Ave_Value.ReadOnly = true;
            Ave_Value.Width = 80;
            // 
            // ComboBox_DataFrequence
            // 
            TabPanel_Chart_Control.SetColumn(ComboBox_DataFrequence, 3);
            ComboBox_DataFrequence.FormattingEnabled = true;
            ComboBox_DataFrequence.Items.AddRange(new object[] { "100 ms / 次", "250 ms / 次", "500 ms / 次", "1 S / 次", "2 S / 次", "5 S / 次", "10 S / 次" });
            ComboBox_DataFrequence.Location = new Point(588, 48);
            ComboBox_DataFrequence.Margin = new Padding(3, 2, 3, 2);
            ComboBox_DataFrequence.Name = "ComboBox_DataFrequence";
            TabPanel_Chart_Control.SetRow(ComboBox_DataFrequence, 1);
            ComboBox_DataFrequence.Size = new Size(73, 22);
            ComboBox_DataFrequence.TabIndex = 3;
            ComboBox_DataFrequence.Text = "1 S / 次";
            // 
            // CheckBox_PowerLineDisplay
            // 
            CheckBox_PowerLineDisplay.AutoSize = true;
            CheckBox_PowerLineDisplay.Checked = true;
            CheckBox_PowerLineDisplay.CheckState = CheckState.Checked;
            TabPanel_Chart_Control.SetColumn(CheckBox_PowerLineDisplay, 2);
            CheckBox_PowerLineDisplay.Location = new Point(502, 103);
            CheckBox_PowerLineDisplay.Margin = new Padding(3, 2, 3, 2);
            CheckBox_PowerLineDisplay.Name = "CheckBox_PowerLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_PowerLineDisplay, 3);
            CheckBox_PowerLineDisplay.Size = new Size(74, 18);
            CheckBox_PowerLineDisplay.TabIndex = 2;
            CheckBox_PowerLineDisplay.Text = "显示功耗";
            CheckBox_PowerLineDisplay.UseVisualStyleBackColor = true;
            CheckBox_PowerLineDisplay.CheckedChanged += CheckBox_PowerLineDisplay_CheckedChanged;
            // 
            // CheckBox_VoltageLineDisplay
            // 
            CheckBox_VoltageLineDisplay.AutoSize = true;
            CheckBox_VoltageLineDisplay.Checked = true;
            CheckBox_VoltageLineDisplay.CheckState = CheckState.Checked;
            TabPanel_Chart_Control.SetColumn(CheckBox_VoltageLineDisplay, 2);
            CheckBox_VoltageLineDisplay.Location = new Point(502, 76);
            CheckBox_VoltageLineDisplay.Margin = new Padding(3, 2, 3, 2);
            CheckBox_VoltageLineDisplay.Name = "CheckBox_VoltageLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_VoltageLineDisplay, 2);
            CheckBox_VoltageLineDisplay.Size = new Size(74, 18);
            CheckBox_VoltageLineDisplay.TabIndex = 1;
            CheckBox_VoltageLineDisplay.Text = "显示电压";
            CheckBox_VoltageLineDisplay.UseVisualStyleBackColor = true;
            CheckBox_VoltageLineDisplay.CheckedChanged += CheckBox_VoltageLineDisplay_CheckedChanged;
            // 
            // CheckBox_CurrentLineDisplay
            // 
            CheckBox_CurrentLineDisplay.AutoSize = true;
            CheckBox_CurrentLineDisplay.Checked = true;
            CheckBox_CurrentLineDisplay.CheckState = CheckState.Checked;
            TabPanel_Chart_Control.SetColumn(CheckBox_CurrentLineDisplay, 2);
            CheckBox_CurrentLineDisplay.Location = new Point(502, 50);
            CheckBox_CurrentLineDisplay.Margin = new Padding(3, 2, 3, 2);
            CheckBox_CurrentLineDisplay.Name = "CheckBox_CurrentLineDisplay";
            TabPanel_Chart_Control.SetRow(CheckBox_CurrentLineDisplay, 1);
            CheckBox_CurrentLineDisplay.Size = new Size(74, 18);
            CheckBox_CurrentLineDisplay.TabIndex = 0;
            CheckBox_CurrentLineDisplay.Text = "显示电流";
            CheckBox_CurrentLineDisplay.UseVisualStyleBackColor = true;
            CheckBox_CurrentLineDisplay.CheckedChanged += CheckBox_CurrentLineDisplay_CheckedChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { StatusLabel_DeviceStatus });
            statusStrip1.Location = new Point(0, 524);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(794, 24);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel_DeviceStatus
            // 
            StatusLabel_DeviceStatus.Font = new Font("Microsoft YaHei UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            StatusLabel_DeviceStatus.Name = "StatusLabel_DeviceStatus";
            StatusLabel_DeviceStatus.Size = new Size(79, 19);
            StatusLabel_DeviceStatus.Text = "设备未连接";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Charge_Voltage
            // 
            Charge_Voltage.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Charge_Voltage.DefaultCellStyle = dataGridViewCellStyle2;
            Charge_Voltage.HeaderText = "Voltage(V)";
            Charge_Voltage.MinimumWidth = 6;
            Charge_Voltage.Name = "Charge_Voltage";
            Charge_Voltage.Width = 92;
            // 
            // Charge_Current
            // 
            Charge_Current.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Charge_Current.DefaultCellStyle = dataGridViewCellStyle3;
            Charge_Current.HeaderText = "Current(A)";
            Charge_Current.MinimumWidth = 6;
            Charge_Current.Name = "Charge_Current";
            Charge_Current.Width = 91;
            // 
            // Charge_Time
            // 
            Charge_Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Charge_Time.DefaultCellStyle = dataGridViewCellStyle4;
            Charge_Time.HeaderText = "Time(S)";
            Charge_Time.MinimumWidth = 6;
            Charge_Time.Name = "Charge_Time";
            Charge_Time.Width = 76;
            // 
            // Keithley2306Form
            // 
            Appearance.BackColor = Color.White;
            Appearance.Options.UseBackColor = true;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 548);
            Controls.Add(TabPanel_Chart_Control);
            Controls.Add(statusStrip1);
            Controls.Add(Chart_Panel);
            Controls.Add(TablePanel_Control);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(1080, 580);
            Name = "Keithley2306Form";
            Text = "keithley2306";
            FormClosing += Keithley2306Form_FormClosing;
            FormClosed += Keithley2306Form_FormClosed;
            Load += keithley2306_Load;
            ((System.ComponentModel.ISupportInitialize)TablePanel_Control).EndInit();
            TablePanel_Control.ResumeLayout(false);
            TablePanel_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)digitalGauge1).EndInit();
            ((System.ComponentModel.ISupportInitialize)digitalComponent1).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataGridView_ChargeInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagramSecondaryAxisy1).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotDiagram1).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)series1).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)series2).EndInit();
            ((System.ComponentModel.ISupportInitialize)swiftPlotSeriesView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)series3).EndInit();
            ((System.ComponentModel.ISupportInitialize)ChartControl_Watchdog).EndInit();
            Chart_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TabPanel_Chart_Control).EndInit();
            TabPanel_Chart_Control.ResumeLayout(false);
            TabPanel_Chart_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridView_WhatchDog).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel TablePanel_Control;
        private RadioButton RadioButton_PowerTest;
        private Button Btn_Power_On;
        private Button Btn_Power_Off;
        private DevExpress.XtraCharts.ChartControl ChartControl_Watchdog;
        private DevExpress.XtraGrid.Columns.GridColumn Cur_Data;
        private ComboBox ComboBox_Voltage_Select;
        private Panel Chart_Panel;
        private DevExpress.Utils.Layout.TablePanel TabPanel_Chart_Control;
        private Button Btn_Save;
        private Button Btn_Stop;
        private Button Btn_Start;
        private RadioButton RadioButton_ChargeTest;
        private CheckBox CheckBox_CurrentLineDisplay;
        private ComboBox ComboBox_DataFrequence;
        private CheckBox CheckBox_PowerLineDisplay;
        private CheckBox CheckBox_VoltageLineDisplay;
        private DataGridView DataGridView_WhatchDog;
        private DataGridView DataGridView_ChargeInput;
        private ComboBox Combox_Channel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel_DeviceStatus;
        private ComboBox Combox_CurrentLim_Select;
        private DataGridViewTextBoxColumn Min_Value;
        private DataGridViewTextBoxColumn Max_Value;
        private DataGridViewTextBoxColumn Current_Value;
        private DataGridViewTextBoxColumn Ave_Value;
        private Label Label_Current_Lim_Select;
        private Label Label_Voltage_Select;
        private Label Label_Display_Options;
        private Label Label_ReadFrequence;
        private DevExpress.XtraGauges.Win.GaugeControl GaugeControl;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalComponent1;
        private System.Windows.Forms.Timer timer1;
        private Label Label_Timer_Title;
        private DataGridViewTextBoxColumn Charge_Voltage;
        private DataGridViewTextBoxColumn Charge_Current;
        private DataGridViewTextBoxColumn Charge_Time;
    }
}