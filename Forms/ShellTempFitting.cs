using CsvHelper;
using MathNet.Numerics.LinearAlgebra;
using NPOI.SS.UserModel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SixLabors.ImageSharp.ColorSpaces;
using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace HW_Thermal_Tools.Forms
{
    public partial class ShellTempFitting : Form
    {
        //files


        public ShellTempFitting()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void ShellTempFitting_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
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
            DataPreProcess();
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
            List<DataTable> DataTablesList = new List<DataTable>();
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
            Calculator(DataTablesList);

        }



        private List<DataTable> MatchData(List<string> csvFilesList, List<string> excelFilesList)
        {
            //创建一个dataTable的list,用于返回最后的两个结果的dataTable
            List<DataTable> resultDataTablesList = new List<DataTable>();

            //创建两个dataTable,分别名为CsvDataTable和ExcelDataTable
            DataTable CsvDataTable = new DataTable();
            DataTable ExcelDataTable = new DataTable();

            //创建两个dataTable，用于临时存储数据后去对齐时间，分别名为csvTempDataTable和excelTempDataTable
            DataTable csvTempDataTable = new DataTable();
            DataTable excelTempDataTable = new DataTable();

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
                        //再定义一个属于，用于存储对比过后的数据的数组
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
                        //将preValues添加到临时表
                        csvTempDataTable.Rows.Add(preValues);



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

        private void TxtboxNtcnames_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Calculator(List<DataTable> dataTablesList)
        {
            //获取用户输入的点位名称、NTC名称，保存为字符串数组
            string[] FrontPoint = txtFrontPoint.Text.Split(" ");
            string[] FramePoint = txtFramePoint.Text.Split(" ");
            string[] BottomPoint = txtBottomPoint.Text.Split(" ");
            string[] NtcName = txtNtcNames.Text.Split(" ");

            //获取csvDateTable 和 ExcelDataTable
            DataTable csvDataTable = dataTablesList[0];
            DataTable ExcelDataTable = dataTablesList[1];

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
                        FrontPoint[i] = "CH001";
                        break;
                    case "2":
                        FrontPoint[i] = "CH002";
                        break;
                    case "3":
                        FrontPoint[i] = "CH003";
                        break;
                    case "4":
                        FrontPoint[i] = "CH004";
                        break;
                    case "5":
                        FrontPoint[i] = "CH005";
                        break;
                    case "6":
                        FrontPoint[i] = "CH006";
                        break;
                    case "7":
                        FrontPoint[i] = "CH007";
                        break;
                    case "8":
                        FrontPoint[i] = "CH008";
                        break;
                    case "9":
                        FrontPoint[i] = "CH009";
                        break;
                    case "10":
                        FrontPoint[i] = "CH010";
                        break;
                }
            }
            //侧面点位
            for (int i = 0; i < FramePoint.Length; i++)
            {
                switch (FramePoint[i])
                {
                    case "1":
                        FramePoint[i] = "CH001";
                        break;
                    case "2":
                        FramePoint[i] = "CH002";
                        break;
                    case "3":
                        FramePoint[i] = "CH003";
                        break;
                    case "4":
                        FramePoint[i] = "CH004";
                        break;
                    case "5":
                        FramePoint[i] = "CH005";
                        break;
                    case "6":
                        FramePoint[i] = "CH006";
                        break;
                    case "7":
                        FramePoint[i] = "CH007";
                        break;
                    case "8":
                        FramePoint[i] = "CH008";
                        break;
                    case "9":
                        FramePoint[i] = "CH009";
                        break;
                    case "10":
                        FramePoint[i] = "CH010";
                        break;
                }
            }
            //背面点位
            for (int i = 0; i < BottomPoint.Length; i++)
            {
                switch (BottomPoint[i])
                {
                    case "1":
                        BottomPoint[i] = "CH001";
                        break;
                    case "2":
                        BottomPoint[i] = "CH002";
                        break;
                    case "3":
                        BottomPoint[i] = "CH003";
                        break;
                    case "4":
                        BottomPoint[i] = "CH004";
                        break;
                    case "5":
                        BottomPoint[i] = "CH005";
                        break;
                    case "6":
                        BottomPoint[i] = "CH006";
                        break;
                    case "7":
                        BottomPoint[i] = "CH007";
                        break;
                    case "8":
                        BottomPoint[i] = "CH008";
                        break;
                    case "9":
                        BottomPoint[i] = "CH009";
                        break;
                    case "10":
                        BottomPoint[i] = "CH010";
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
            foreach (DataRow row in csvDataTable.Rows)
            {
                for (int i = 0; i < NtcName.Length; i++)
                {
                    double value = double.Parse(row[NtcName[i]].ToString()) / 1000;
                    X.Add(value);
                }
            }


            

        }
    }

}
