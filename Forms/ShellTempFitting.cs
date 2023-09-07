using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Data;
using System.Globalization;

namespace HW_Thermal_Tools.Forms
{
    public partial class ShellTempFitting : Form
    {
        //files
        //创建数据预处理后得到的dataTable
        private List<DataTable> DataTablesList;

        //创建三个不同的plotModel对象，用于显示最后的对比曲线
        private PlotModel plotModel_front;
        private PlotModel plotModel_frame;
        private PlotModel plotModel_bottom;
        //创建一个plotModel的索引，用于点击切换
        private int plotModelIndex = 0;
        public ShellTempFitting()
        {
            InitializeComponent();
            LoadTheme();

            //初始化plotModel对象
            plotModel_front = new PlotModel { Title = "Front Predict VS Actual" };
            plotModel_frame = new PlotModel { Title = "Frame Predict VS Actual" };
            plotModel_bottom = new PlotModel { Title = "Bottom Predict VS Actual" };

            plotModelIndex = 0;

            //初始化DataTableList
            DataTablesList = new List<System.Data.DataTable>();


        }

        private void ShellTempFitting_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            //由于button放在panel容易中，无法通过这种方式获取button
            /*
             foreach (System.Windows.Forms.Control btns in this.Controls)
             {
                 if (btns.GetType() == typeof(System.Windows.Forms.Button))
                 {
                     System.Windows.Forms.Button btn = (System.Windows.Forms.Button)btns;
                     btn.BackColor = ThemeColor.PrimaryColor;
                     btn.ForeColor = Color.White;
                     btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                 }
             }
             */
            //通过这种方式获取
            foreach (System.Windows.Forms.Control control in TabLayoutPanel_ShellTempFit.Controls)
            {
                if (control is System.Windows.Forms.Button)
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

        }

        private void BtnStfSelectFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有需要的文件(*.xlsx;*.xls;*.csv)|*.xlsx;*.xls;*.csv";
            openFileDialog.Multiselect = true;
            //将用户选择的多个文件的路径显示到TxtboxStfFilesPath这个textbox上，每个路径需要换行
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] fileNames = openFileDialog.FileNames;
                foreach (string fileName in fileNames)
                {
                    TxtboxStfFilesPath.Text += fileName + "\r\n";
                }
            }

        }


        private void BtnStfConfirm_Click(object sender, EventArgs e)
        {
            //数据前处理
            DataPreProcess();

            //用户输入内容检查
            if (CheckUserInput() == false)
            {
                return;
            }

            //计算
            Calculator(DataTablesList);

            //保存数据
            if (checkBoxSaveStfData.CheckState == CheckState.Checked)
            {
                SaveDataToExcel(DataTablesList);
            }

            //保存图片
            if (checkBox_SaveCurvePicture.CheckState == CheckState.Checked)
            {
                string dir = "";
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                //设置diaglog的title
                dialog.Description = "请选择保存图片的路径";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dir = dialog.SelectedPath;
                }
                ExportPng(plotModel_front, "Front", dir);
                ExportPng(plotModel_frame, "Frame", dir);
                ExportPng(plotModel_bottom, "Bottom", dir);
            }

        }

        private void SaveDataToExcel(List<System.Data.DataTable> dataTablesList)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            //设置保存文件的title
            saveDialog.Title = "请选择保存数据的路径";
            saveDialog.Filter = "Excel Files|*.xlsx";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    string[] worksheetName = new string[] { "NTC数据", "热电偶数据" };
                    int i = 0;
                    foreach (System.Data.DataTable table in dataTablesList)
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(worksheetName[i]);
                        worksheet.Cells["A1"].LoadFromDataTable(table, true);

                        // 设置标题行字体加粗
                        worksheet.Row(1).Style.Font.Bold = true;

                        // 设置标题行背景色 
                        worksheet.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Row(1).Style.Fill.BackgroundColor.SetColor(Color.LightBlue);

                        // 设置数据行居中
                        worksheet.Cells[2, 1, table.Rows.Count + 1, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        //设置数据行 单元格格式为常规
                        worksheet.Cells[2, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].Style.Numberformat.Format = "General";
                        i++;
                    }

                    FileStream stream = File.Create(fileName);
                    excelPackage.SaveAs(stream);
                    stream.Close();
                }
                MessageBox.Show("保存成功");
            }
        }

        //封装一个将PlotModel导出图片的方法
        public void ExportPng(PlotModel plotModel, string filename, string dir)
        {
            string path = Path.Combine(dir, filename + ".png");

            // 导出逻辑...
            var pngExporter = new PngExporter { Width = 3840, Height = 2160 };
            using (Stream stream = File.Create(path))
            {
                pngExporter.Export(plotModel, stream);
            }

        }

        private bool CheckUserInput()
        {
            if (txtNtcNames.Text == "")
            {
                MessageBox.Show("请输入NTC的名称!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFrontPoint.Text == "" || txtFramePoint.Text == "" || txtBottomPoint.Text == "")
            {
                MessageBox.Show("请输入用到的点位", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            string[] front_p = txtFrontPoint.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] frame_p = txtFramePoint.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] bottom_p = txtBottomPoint.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] ponit = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

            //使用any方法判断用户输入的点位是否在1-10之间
            if (front_p.Any(x => !ponit.Contains(x)) || frame_p.Any(x => !ponit.Contains(x)) || bottom_p.Any(x => !ponit.Contains(x)))
            {
                MessageBox.Show("请输入1-10之间的点位", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string[] ntcNames = DataTablesList[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
            /*
             DataTablesList[0] 取出一个DataTable类型的列表中的第一个DataTable
            1.Columns 获得这个DataTable的列集合(DataColumnCollection类型)
            2.Cast<DataColumn>() 将列集合强制转换为DataColumn类型的可枚举对象
            3.Select(x => x.ColumnName) 对每个DataColumn选出其列名(ColumnName属性)
            4.ToArray() 将选择出的列名转换为字符串数组
            最后把这个字符串数组赋值给ntcNames变量
            所以这句代码使用了LINQ的方法,将一个DataTable的列名称提取出来存到一个字符串数组中,便于后续使用和处理。
             */
            if (txtNtcNames.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Any(x => !ntcNames.Contains(x)))
            {
                MessageBox.Show("请输入正确的NTC名称", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }


        /*
         对获取到的数据进行预处理，统一格式之后再进行下一步的操作
         */
        private void DataPreProcess()
        {
            //遍历textbox中的filenames，根据文件名的后缀，将文件名分别保存到两个list中，list分别名为CsvFilesList和ExcelFilesList
            string[] fileNames = TxtboxStfFilesPath.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> CsvFilesList = new List<string>();
            List<string> ExcelFilesList = new List<string>();
            //定义一个用于接收预处理csv文件和excel文件结果DataTable的lsit
            //List<System.Data.DataTable> DataTablesList = new List<System.Data.DataTable>();
            foreach (string fileName in fileNames)
            {
                if (fileName.EndsWith(".csv"))
                {
                    CsvFilesList.Add(fileName);
                }
                else if (fileName.EndsWith(".xls") || fileName.EndsWith(".xlsx"))
                {
                    ExcelFilesList.Add(fileName);
                }
            }

            DataTablesList = MatchData(CsvFilesList, ExcelFilesList);


        }



        private List<System.Data.DataTable> MatchData(List<string> csvFilesList, List<string> excelFilesList)
        {
            //创建一个dataTable的list,用于返回最后的两个结果的dataTable
            List<System.Data.DataTable> resultDataTablesList = new List<System.Data.DataTable>();

            //创建两个dataTable,分别名为CsvDataTable和ExcelDataTable
            System.Data.DataTable CsvDataTable = new System.Data.DataTable();
            System.Data.DataTable ExcelDataTable = new System.Data.DataTable();

            //创建两个dataTable，用于临时存储数据后去对齐时间，分别名为csvTempDataTable和excelTempDataTable
            System.Data.DataTable csvTempDataTable = new System.Data.DataTable();
            System.Data.DataTable excelTempDataTable = new System.Data.DataTable();

            //csv时间格式
            string csvTimeFormat = "HH-mm-ss.fff";


            /*
             获取并设置csv文件的dataTable的列名
             */
            //遍历所有的csv文件的，对比csv文件的列数，将列数最多的csv文件的第一行设置为表的列名
            var csvTableHeaders = new string[0];
            var headers = new string[0];
            foreach (string csvFile in csvFilesList)
            {
                int titleCount = 0, titleTempCount;


                //读取csv文件的第一行
                using (StreamReader reader = new StreamReader(csvFile))
                {
                    string headerLine = reader.ReadLine();
                    headers = headerLine.Split(',');
                    //获取headerde元素个数
                    titleTempCount = headers.Length;

                }
                //如果标题数量更多，则更新headers
                if (titleTempCount > titleCount)
                {
                    titleCount = titleTempCount;
                    csvTableHeaders = headers;

                }
            }
            //设置表的列名以及时间列的数据类型
            foreach (string header in csvTableHeaders)
            {
                CsvDataTable.Columns.Add(header);
                csvTempDataTable.Columns.Add(header);
            }
            CsvDataTable.Columns[0].ColumnName = "Time";
            CsvDataTable.Columns[0].DataType = typeof(DateTime);
            csvTempDataTable.Columns[0].ColumnName = "Time";
            csvTempDataTable.Columns[0].DataType = typeof(DateTime);

            /*
             由于excel文件都是手动设置的GP10,所以内容格式上会完全一致，直接获取第一个文件 读取标题
             */
            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilesList[0])))
            {
                //设置非商业用途的许可证
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets.First();

                //读取标题
                for (int i = 1; i <= worksheet.Dimension.End.Column; i++)
                {
                    ExcelDataTable.Columns.Add(worksheet.Cells[1, i].Value.ToString());
                    excelTempDataTable.Columns.Add(worksheet.Cells[1, i].Value.ToString());
                }
                //设置两个表的第一列为时间列，设置表的格式
                ExcelDataTable.Columns[0].DataType = typeof(DateTime);
                excelTempDataTable.Columns[0].DataType = typeof(DateTime);
            }


            /*
             遍历读取csv文件和excel文件
             */
            foreach (string csvFile in csvFilesList)
            {
                string csvName = Path.GetFileNameWithoutExtension(csvFile);

                //在Excel列表中查找同名文件
                string excelFile = excelFilesList.FirstOrDefault(e => Path.GetFileNameWithoutExtension(e) == csvName);

                if (excelFile != null)
                {

                    // 读取CSV 
                    using (StreamReader reader = new StreamReader(csvFile))
                    {


                        //读取csv文件第一行，与dataTable对比
                        string header = reader.ReadLine(); //将标题行获取为字符串
                        string[] headerValues = header.Split(','); //将包含标题的字符串拆分为数组
                                                                   //遍历标题数组，同时与列名逐个对比
                                                                   //使用LINQ的Where和Select方法来筛选出不包含在headerValues中的列，并获取它们的索引
                        var skipTitleList = CsvDataTable.Columns.Cast<DataColumn>().Where(column => !headerValues.Contains(column.ColumnName)).Select(column => CsvDataTable.Columns.IndexOf(column)).ToList();
                        //删除第一个时间列的索引，因为时间列原本的标题就是时间，无法与dataTable的时间列标题“Time”对比
                        skipTitleList.RemoveAt(0);



                        //再单独读取csv文件的第二行，定义preDateTime以及PreValues并获取值；
                        //根据skipTitleList读取数据与DataTable的列数保持一致，同步将preValues添加到表；
                        string preLine = reader.ReadLine();
                        string[] preValues = preLine.Split(',');
                        DateTime preDateTime = DateTime.ParseExact(preValues[0], csvTimeFormat, CultureInfo.InvariantCulture);
                        //将dateTime转为字符串给到preValues[0]
                        string preTimeString = preDateTime.ToString("HH:mm:ss");
                        preValues[0] = preTimeString;

                        //这个动作是为了跳过不存在的标题
                        //拆分为字段数组,临时存储逐行读取的数据的数组
                        string[] tempValues = preLine.Split(',');
                        //再定义一个数组，用于存储对比过后的数据的数组
                        string[] values = new string[csvTempDataTable.Columns.Count];

                        for (int i = 0, j = 0; i < csvTempDataTable.Columns.Count; i++)
                        {
                            //如果skipTitleList中包含i，则跳过这一列
                            if (skipTitleList.Contains(i))
                            {
                                values[i] = "None";
                            }
                            else
                            {
                                values[i] = tempValues[j];
                                j++;
                            }
                        }
                        values[0] = preTimeString;

                        //将preValues添加到临时表
                        csvTempDataTable.Rows.Add(values);

                        //将values的值同步给preValues
                        preValues = values;



                        // 从第三开始逐行遍历
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            //拆分为字段数组,临时存储逐行读取的数据的数组
                            tempValues = line.Split(',');
                            //再定义一个属于，用于存储对比过后的数据的数组
                            string[] currentValues = new string[csvTempDataTable.Columns.Count];
                            /*
                             为了在读取到最后一行csv非时间的数据时，能退出while循环，
                            使用TryParseExact方法将时间列的数据转换为DateTime类型，如果转换失败，
                             */
                            DateTime CurrentDateTime;
                            if (!DateTime.TryParseExact(tempValues[0], csvTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out CurrentDateTime))
                            {
                                break;
                            }

                            // 解析为 DateTime
                            CurrentDateTime = DateTime.ParseExact(tempValues[0], csvTimeFormat, CultureInfo.InvariantCulture);

                            // 转换为字符串
                            string currentDateTimeToString = CurrentDateTime.ToString("HH:mm:ss");
                            //赋值给字符串数组
                            tempValues[0] = currentDateTimeToString;

                            /*
                             这里添加对获取的数组的内容的判断，主要是为了解决两种抓取的数据中存在的问题：
                            1、某个时刻抓取的数据存在空值，即csv文件中有空值
                            2、抓取的数据在时间上不连续的问题
                             */
                            //为了忽略毫秒带来的影响,使用dateTime的take方法取整到秒
                            string preDateTimeToString = preDateTime.ToString("HH:mm:ss");
                            DateTime curDateTimeWithoutMs = DateTime.Parse(currentDateTimeToString);
                            DateTime preDateTimeWithoutMs = DateTime.Parse(preDateTimeToString);
                            TimeSpan timeSpan = curDateTimeWithoutMs - preDateTimeWithoutMs;

                            if (timeSpan.TotalSeconds > 1) //如果时差大于1s，说明时间上不连续
                            {
                                //将preDateTime加1s
                                preDateTime = preDateTime.AddSeconds(1);
                                //将preDateTime转为字符串给到preValues[0]
                                preTimeString = preDateTime.ToString("HH:mm:ss");
                                preValues[0] = preTimeString;
                                //将preValues添加到临时表
                                csvTempDataTable.Rows.Add(preValues);
                            }

                            //如果tempValues中存在空值
                            else if (tempValues.Any(string.IsNullOrEmpty))
                            {
                                //将preDateTime加1s
                                preDateTime = preDateTime.AddSeconds(1);
                                //将preDateTime转为字符串给到preValues[0]
                                preTimeString = preDateTime.ToString("HH:mm:ss");
                                preValues[0] = preTimeString;
                                //将preValues添加到临时表
                                csvTempDataTable.Rows.Add(preValues);
                            }

                            //添加这一行的数据到表，根据表的列数与skipTitleList来判断是否需要跳过某些列
                            for (int i = 0, j = 0; i < csvTempDataTable.Columns.Count; i++)
                            {
                                //如果skipTitleList中包含i，则跳过这一列
                                if (skipTitleList.Contains(i))
                                {
                                    currentValues[i] = "None";

                                }
                                else
                                {
                                    currentValues[i] = tempValues[j];
                                    j++;
                                }
                            }

                            //添加这行数据到表
                            csvTempDataTable.Rows.Add(currentValues);
                            preValues = currentValues;
                            preDateTime = CurrentDateTime;



                        }



                        // 读取对应的Excel
                        using (var package = new ExcelPackage(excelFile))
                        {
                            var worksheet = package.Workbook.Worksheets.First();

                            //循环读取每个单元格
                            for (int r = 2; r <= worksheet.Dimension.End.Row; r++)
                            {
                                //存储一行的数据
                                object[] row = new object[worksheet.Dimension.End.Column];
                                for (int c = 1; c <= worksheet.Dimension.End.Column; c++)
                                {
                                    //读取单元格
                                    object cell = worksheet.Cells[r, c].Value;
                                    //如果是时间所在的列
                                    if (c == 1)
                                    {
                                        // Excel用数字序列表示时间
                                        double timeNumber = (double)cell;

                                        // 转换为DateTime
                                        DateTime dateTime = DateTime.FromOADate(timeNumber);

                                        // 格式化时间字符串
                                        cell = dateTime.ToString("HH:mm:ss");
                                    }
                                    row[c - 1] = cell;
                                }
                                //添加这行数据到临时表
                                excelTempDataTable.Rows.Add(row);
                            }


                        }


                        /*
                         根据csv文件和excel文件起始时间和停止时间对齐数据
                         */
                        //获取csv起始和结束时间
                        DateTime csvStartTime = (DateTime)csvTempDataTable.Rows[0][0];
                        DateTime csvEndTime = (DateTime)csvTempDataTable.Rows[csvTempDataTable.Rows.Count - 1][0];

                        //获取excel起始和结束时间
                        DateTime excelStartTime = (DateTime)excelTempDataTable.Rows[0][0];
                        DateTime excelEndTime = (DateTime)excelTempDataTable.Rows[excelTempDataTable.Rows.Count - 1][0];

                        //时间对齐、截取范围内的数据
                        // 对齐时间范围
                        DateTime startTime = csvStartTime > excelStartTime ? csvStartTime : excelStartTime;
                        DateTime endTime = csvEndTime < excelEndTime ? csvEndTime : excelEndTime;

                        //截取对齐后的数据范围
                        csvTempDataTable = csvTempDataTable.AsEnumerable().Where(r => (DateTime)r[0] >= startTime && (DateTime)r[0] <= endTime).CopyToDataTable();
                        excelTempDataTable = excelTempDataTable.AsEnumerable().Where(r => (DateTime)r[0] >= startTime && (DateTime)r[0] <= endTime).CopyToDataTable();

                        //判断确认临时表不为空，保存临时表的数据到最终表
                        if (csvTempDataTable.Rows.Count > 0 && excelTempDataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in csvTempDataTable.Rows)
                            {
                                CsvDataTable.ImportRow(row);
                            }
                            foreach (DataRow row in excelTempDataTable.Rows)
                            {
                                ExcelDataTable.ImportRow(row);
                            }

                            //清除临时表的数据
                            csvTempDataTable.Rows.Clear();
                            excelTempDataTable.Rows.Clear();
                        }
                        else
                        {
                            //提示用户
                            MessageBox.Show("文件" + "没有对齐的数据");
                        }
                    }
                }

            }

            //将最终的表添加到结果的list中
            resultDataTablesList.Add(CsvDataTable);
            resultDataTablesList.Add(ExcelDataTable);

            return resultDataTablesList;


        }



        private void Calculator(List<System.Data.DataTable> dataTablesList)
        {
            //获取用户输入的点位名称、NTC名称，保存为字符串数组
            string[] FrontPoint = txtFrontPoint.Text.Split(" ");
            string[] FramePoint = txtFramePoint.Text.Split(" ");
            string[] BottomPoint = txtBottomPoint.Text.Split(" ");
            string[] NtcName = txtNtcNames.Text.Split(" ");

            //获取csvDateTable 和 ExcelDataTable
            System.Data.DataTable csvDataTable = dataTablesList[0];
            System.Data.DataTable ExcelDataTable = dataTablesList[1];

            //初始化自变量X的矩阵
            Matrix<double> X = Matrix<double>.Build.Dense(csvDataTable.Rows.Count, NtcName.Length);

            //初始化因变量Y的向量
            Vector<double> Y_Front_Vector = Vector<double>.Build.Dense(ExcelDataTable.Rows.Count);
            Vector<double> Y_FrameVector = Vector<double>.Build.Dense(ExcelDataTable.Rows.Count);
            Vector<double> Y_Bottom_Vector = Vector<double>.Build.Dense(ExcelDataTable.Rows.Count);

            //有个要注意的地方，hypermonitor的数据是35600,GP10数据是35.6

            //先根据用户输入的正面 侧面 背面的点位，获取dateTable中对应列表的最大值，然后保存为各自的向量
            //正面点位
            for (int i = 0; i < FrontPoint.Length; i++)
            {
                switch (FrontPoint[i])
                {
                    case "1":
                        FrontPoint[i] = "CH0001";
                        break;
                    case "2":
                        FrontPoint[i] = "CH0002";
                        break;
                    case "3":
                        FrontPoint[i] = "CH0003";
                        break;
                    case "4":
                        FrontPoint[i] = "CH0004";
                        break;
                    case "5":
                        FrontPoint[i] = "CH0005";
                        break;
                    case "6":
                        FrontPoint[i] = "CH0006";
                        break;
                    case "7":
                        FrontPoint[i] = "CH0007";
                        break;
                    case "8":
                        FrontPoint[i] = "CH0008";
                        break;
                    case "9":
                        FrontPoint[i] = "CH0009";
                        break;
                    case "10":
                        FrontPoint[i] = "CH0010";
                        break;
                }
            }
            //侧面点位
            for (int i = 0; i < FramePoint.Length; i++)
            {
                switch (FramePoint[i])
                {
                    case "1":
                        FramePoint[i] = "CH0001";
                        break;
                    case "2":
                        FramePoint[i] = "CH0002";
                        break;
                    case "3":
                        FramePoint[i] = "CH0003";
                        break;
                    case "4":
                        FramePoint[i] = "CH0004";
                        break;
                    case "5":
                        FramePoint[i] = "CH0005";
                        break;
                    case "6":
                        FramePoint[i] = "CH0006";
                        break;
                    case "7":
                        FramePoint[i] = "CH0007";
                        break;
                    case "8":
                        FramePoint[i] = "CH0008";
                        break;
                    case "9":
                        FramePoint[i] = "CH0009";
                        break;
                    case "10":
                        FramePoint[i] = "CH0010";
                        break;
                }
            }
            //背面点位
            for (int i = 0; i < BottomPoint.Length; i++)
            {
                switch (BottomPoint[i])
                {
                    case "1":
                        BottomPoint[i] = "CH0001";
                        break;
                    case "2":
                        BottomPoint[i] = "CH0002";
                        break;
                    case "3":
                        BottomPoint[i] = "CH0003";
                        break;
                    case "4":
                        BottomPoint[i] = "CH0004";
                        break;
                    case "5":
                        BottomPoint[i] = "CH0005";
                        break;
                    case "6":
                        BottomPoint[i] = "CH0006";
                        break;
                    case "7":
                        BottomPoint[i] = "CH0007";
                        break;
                    case "8":
                        BottomPoint[i] = "CH0008";
                        break;
                    case "9":
                        BottomPoint[i] = "CH0009";
                        break;
                    case "10":
                        BottomPoint[i] = "CH0010";
                        break;
                }
            }

            double[] Y_Front_Max = new double[ExcelDataTable.Rows.Count];
            double[] Y_Frame_Max = new double[ExcelDataTable.Rows.Count];
            double[] Y_Bottom_Max = new double[ExcelDataTable.Rows.Count];

            for (int i = 0; i < ExcelDataTable.Rows.Count; i++)
            {
                DataRow row = ExcelDataTable.Rows[i];

                // 计算Front部分最大值
                double maxFront = double.MinValue;
                for (int col = 0; col < FrontPoint.Length; col++)
                {
                    double value = double.Parse(row[FrontPoint[col]].ToString());
                    if (value > maxFront)
                        maxFront = value;
                }
                Y_Front_Max[i] = maxFront;

                // 计算Frame部分最大值
                double maxFrame = double.MinValue;
                for (int col = 0; col < FramePoint.Length; col++)
                {
                    double value = double.Parse(row[FramePoint[col]].ToString());
                    if (value > maxFrame)
                        maxFrame = value;
                }
                Y_Frame_Max[i] = maxFrame;


                // 计算Bottom部分最大值
                double maxBottom = double.MinValue;
                for (int col = 0; col < BottomPoint.Length; col++)
                {
                    double value = double.Parse(row[BottomPoint[col]].ToString());
                    if (value > maxBottom)
                        maxBottom = value;
                }
                Y_Bottom_Max[i] = maxBottom;

            }

            //构建因变量的向量
            Y_Front_Vector = Vector<double>.Build.DenseOfArray(Y_Front_Max);
            Y_FrameVector = Vector<double>.Build.DenseOfArray(Y_Frame_Max);
            Y_Bottom_Vector = Vector<double>.Build.DenseOfArray(Y_Bottom_Max);


            //根据用户输入的ntcName，遍历dateTable中对应的列名，并添加到矩阵x中
            //foreach (DataRow row in csvDataTable.Rows)
            //{
            //    for (int i = 0; i < NtcName.Length; i++)
            //    {
            //        double value = double.Parse(row[NtcName[i]].ToString()) / 1000;
            //        X.Add(value);
            //    }
            //}

            //根据用户输入的ntcName，遍历dateTable中对应的列名，并添加到矩阵x中
            for (int i = 0; i < NtcName.Length; i++)
            {
                for (int j = 0; j < csvDataTable.Rows.Count; j++)
                {
                    double value = double.Parse(csvDataTable.Rows[j][NtcName[i]].ToString()) / 1000;
                    X[j, i] = value; // 设置矩阵X指定位置的元素
                }
            }




            //查询LinearRegression这个静态类，发现如果需要获取截距，那么自变量和因变量需要为数组

            //将自变量X转为二维数组
            double[][] X_List = X.ToRowArrays();
            //将二维数组X_List的行和列做转置


            //将因变量Y转为一维数组
            double[] Y_Front_List = Y_Front_Vector.ToArray();
            double[] Y_Frame_List = Y_FrameVector.ToArray();
            double[] Y_Bottom_List = Y_Bottom_Vector.ToArray();




            //使用NormalEquations方法，添加截距拟合模型，返回模型参数
            double[] front_coefficients = MultipleRegression.DirectMethod<double>(X_List, Y_Front_List, true, DirectRegressionMethod.NormalEquations);
            double[] frame_coefficients = MultipleRegression.DirectMethod<double>(X_List, Y_Frame_List, true, DirectRegressionMethod.NormalEquations);
            double[] bottom_coefficients = MultipleRegression.DirectMethod<double>(X_List, Y_Bottom_List, true, DirectRegressionMethod.NormalEquations);

            //获取回归方程的截距
            double front_intercept = front_coefficients[0];
            double frame_intercept = frame_coefficients[0];
            double bottom_intercept = bottom_coefficients[0];

            //获取回归方程的斜率
            double[] front_slope = front_coefficients.Skip(1).ToArray(); //意思是跳过第一个元素组成新的数组
            double[] frame_slope = frame_coefficients.Skip(1).ToArray();
            double[] bottom_slope = bottom_coefficients.Skip(1).ToArray();

            //构建回归方程
            string front_equation = front_intercept.ToString("f4");
            string frame_equation = frame_intercept.ToString("f4");
            string bottom_equation = bottom_intercept.ToString("f4");
            for (int i = 0; i < front_slope.Length; i++)
            {
                front_equation += (front_slope[i] > 0 ? "+" : "") + (front_slope[i]).ToString("f4") + "*" + NtcName[i];
            }
            for (int i = 0; i < frame_slope.Length; i++)
            {
                frame_equation += (frame_slope[i] > 0 ? "+" : "") + (frame_slope[i]).ToString("f4") + "*" + NtcName[i];
            }
            for (int i = 0; i < bottom_slope.Length; i++)
            {
                bottom_equation += (bottom_slope[i] > 0 ? "+" : "") + (bottom_slope[i]).ToString("f4") + "*" + NtcName[i];
            }

            //计算预测值
            double[] front_predict = new double[Y_Front_List.Length];
            double[] frame_predict = new double[Y_Frame_List.Length];
            double[] bottom_predict = new double[Y_Bottom_List.Length];
            for (int i = 0; i < front_predict.Length; i++)
            {
                front_predict[i] = front_intercept;
                frame_predict[i] = frame_intercept;
                bottom_predict[i] = bottom_intercept;
                for (int j = 0; j < front_slope.Length; j++)
                {
                    front_predict[i] += front_slope[j] * X_List[i][j];
                    frame_predict[i] += frame_slope[j] * X_List[i][j];
                    bottom_predict[i] += bottom_slope[j] * X_List[i][j];
                }
            }

            //计算R2
            double front_r2 = GoodnessOfFit.RSquared(Y_Front_List, front_predict);
            double frame_r2 = GoodnessOfFit.RSquared(Y_Frame_List, frame_predict);
            double bottom_r2 = GoodnessOfFit.RSquared(Y_Bottom_List, bottom_predict);

            //在TxtboxStfResult依次显示截距、斜率、回归方程、R2
            TxtboxStfResult.Text = "正面:\r\n";
            TxtboxStfResult.Text += "截距:" + front_intercept.ToString("f4") + "\r\n";
            for (int i = 0; i < front_slope.Length; i++)
            {
                TxtboxStfResult.Text += "系数" + (i + 1).ToString() + ":" + front_slope[i].ToString("f4") + "\r\n";
            }
            TxtboxStfResult.Text += "预测值计算公式:" + front_equation + "\r\n";
            TxtboxStfResult.Text += "R²:" + front_r2.ToString("f4") + "\r\n";
            TxtboxStfResult.Text += "\r\n";

            TxtboxStfResult.Text += "侧面:\r\n";
            TxtboxStfResult.Text += "截距:" + frame_intercept.ToString("f4") + "\r\n";
            for (int i = 0; i < frame_slope.Length; i++)
            {
                TxtboxStfResult.Text += "系数" + (i + 1).ToString() + ":" + frame_slope[i].ToString("f4") + "\r\n";
            }
            TxtboxStfResult.Text += "预测值计算公式:" + frame_equation + "\r\n";
            TxtboxStfResult.Text += "R²:" + frame_r2.ToString("f4") + "\r\n";
            TxtboxStfResult.Text += "\r\n";

            TxtboxStfResult.Text += "背面:\r\n";
            TxtboxStfResult.Text += "截距:" + bottom_intercept.ToString("f4") + "\r\n";
            for (int i = 0; i < bottom_slope.Length; i++)
            {
                TxtboxStfResult.Text += "系数" + (i + 1).ToString() + ":" + bottom_slope[i].ToString("f4") + "\r\n";
            }
            TxtboxStfResult.Text += "预测值计算公式:" + bottom_equation + "\r\n";
            TxtboxStfResult.Text += "R²:" + bottom_r2.ToString("f4") + "\r\n";


            //创建 Chart 对象,设置类型为曲线图
            //PlotModel plotModel_front = new PlotModel() { Title = "Front" };
            //PlotModel plotModel_frame = new PlotModel() { Title = "Frame" };
            //PlotModel plotModel_bottom = new PlotModel() { Title = "Bottom" };

            //Front
            // 创建一个LineSeries对象，用于表示预测值的曲线
            var Front_predictedSeries = new LineSeries
            {
                Title = "预测值",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Blue,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };
            // 创建一个LineSeries对象，用于表示实际值的曲线
            var Front_actualSeries = new LineSeries
            {
                Title = "实际值",
                Color = OxyColors.Red,
                MarkerType = MarkerType.Square,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Red,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };

            // 将一维数组的数据添加到LineSeries对象中
            for (int i = 0; i < front_predict.Length; i++)
            {
                Front_predictedSeries.Points.Add(new DataPoint(i + 1, front_predict[i]));
                Front_actualSeries.Points.Add(new DataPoint(i + 1, Y_Front_List[i]));
            }

            // 将LineSeries对象添加到PlotModel对象中
            plotModel_front.Series.Add(Front_predictedSeries);
            plotModel_front.Series.Add(Front_actualSeries);
            plotModel_front.PlotAreaBackground = OxyColors.LightGray;
            plotModel_front.PlotAreaBorderColor = OxyColors.Black;

            //Frame
            // 创建一个LineSeries对象，用于表示预测值的曲线
            var Frame_predictedSeries = new LineSeries
            {
                Title = "预测值",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Blue,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };
            // 创建一个LineSeries对象，用于表示实际值的曲线
            var Frame_actualSeries = new LineSeries
            {
                Title = "实际值",
                Color = OxyColors.Red,
                MarkerType = MarkerType.Square,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Red,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };

            // 将一维数组的数据添加到LineSeries对象中
            for (int i = 0; i < frame_predict.Length; i++)
            {
                Frame_predictedSeries.Points.Add(new DataPoint(i + 1, frame_predict[i]));
                Frame_actualSeries.Points.Add(new DataPoint(i + 1, Y_Frame_List[i]));
            }

            // 将LineSeries对象添加到PlotModel对象中
            plotModel_frame.Series.Add(Frame_predictedSeries);
            plotModel_frame.Series.Add(Frame_actualSeries);
            plotModel_frame.PlotAreaBackground = OxyColors.LightGray;
            plotModel_frame.PlotAreaBorderColor = OxyColors.Black;


            //Frame
            // 创建一个LineSeries对象，用于表示预测值的曲线
            var Bottom_predictedSeries = new LineSeries
            {
                Title = "预测值",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Blue,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };
            // 创建一个LineSeries对象，用于表示实际值的曲线
            var Bottom_actualSeries = new LineSeries
            {
                Title = "实际值",
                Color = OxyColors.Red,
                MarkerType = MarkerType.Square,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.Red,
                StrokeThickness = 2,
                InterpolationAlgorithm = InterpolationAlgorithms.CanonicalSpline //设置曲线的插值算法
            };

            // 将一维数组的数据添加到LineSeries对象中
            for (int i = 0; i < bottom_predict.Length; i++)
            {
                Bottom_predictedSeries.Points.Add(new DataPoint(i + 1, bottom_predict[i]));
                Bottom_actualSeries.Points.Add(new DataPoint(i + 1, Y_Bottom_List[i]));
            }

            // 将LineSeries对象添加到PlotModel对象中
            plotModel_bottom.Series.Add(Bottom_predictedSeries);
            plotModel_bottom.Series.Add(Bottom_actualSeries);
            plotModel_bottom.PlotAreaBackground = OxyColors.LightGray;
            plotModel_bottom.PlotAreaBorderColor = OxyColors.Black;






            // 将PlotModel对象赋值给plotview控件的Model属性
            PlotViewResult.Model = plotModel_front;
            plotModelIndex = 1;


        }

        private void BtnPictureFront_Click(object sender, EventArgs e)
        {
            if (plotModelIndex == 2 || plotModelIndex == 3)
            {
                PlotViewResult.Model = plotModel_front;
                plotModelIndex = 1;

            }

        }

        private void BtnPictureFrame_Click(object sender, EventArgs e)
        {
            if (plotModelIndex == 1 || plotModelIndex == 3)
            {
                PlotViewResult.Model = plotModel_frame;
                plotModelIndex = 2;
            }
        }

        private void BtnPictureBottom_Click(object sender, EventArgs e)
        {
            if (plotModelIndex == 2 || plotModelIndex == 1)
            {
                PlotViewResult.Model = plotModel_bottom;
                plotModelIndex = 3;
            }
        }

        private void TxtboxStfFilesPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            string allFilesPath = "";

            foreach (string file in files)
            {
                allFilesPath += file + "\r\n";
            }

            TxtboxStfFilesPath.Text = allFilesPath;
        }

        private void TxtboxStfFilesPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }

}
