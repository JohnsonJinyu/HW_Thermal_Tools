using OfficeOpenXml;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace HW_Thermal_Tools.Forms
{
    public partial class ReadLog : Form
    {
        //fiels
        long fileLength;


        public ReadLog()
        {
            InitializeComponent();

        }


        private void LoadTheme()
        {

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

        }

        private void BtnSelectLogFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "所有文件|.";
            //显示对话框，让用户选择文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择的文件路径
                string path = openFileDialog.FileName;
                //把文件路径显示到textbox中
                TextBoxLogFilePath.Text = path;

                //创建一个FileInfo对象
                FileInfo fileInfo = new FileInfo(path);
                //获取文件的长度
                fileLength = fileInfo.Length;
            }
        }

        private void BtnReadLogConfirm_Click(object sender, EventArgs e)
        {
            string Keyword = TextBoxLogKeyWords.Text.Trim();

            //初始化进度条的值
            ProgressBarReadLog.Value = 0;
            ProgressBarReadLog.Maximum = (int)fileLength;
            //定义一个变量来记录已经读取的字节数
            int bytesRead = 0;

            //判断用户输入是否为空
            if (string.IsNullOrEmpty(Keyword))
            {
                MessageBox.Show("请输入log关键词!");
                return;
            }

            //创建一个DataTable用于存储时间和value
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Time", typeof(String)));
            dataTable.Columns.Add(new DataColumn(Keyword, typeof(double)));

            //创建一个正则表达式用于匹配用户输入的keyword和提取数据
            Regex regex = new Regex($@"\[(\d{{2}}/\d{{2}} \d{{2}}:\d{{2}}:\d{{2}})\].*{Regex.Escape(Keyword)}: (\d+\.\d+)");

            //使用FileStream类打开log文件
            using (FileStream fileStream = new FileStream(TextBoxLogFilePath.Text, FileMode.Open, FileAccess.Read))
            {
                //使用Encoding类的GetEncoding方法检测文件的编码格式，这里假设是GB2312，您可以根据实际情况修改
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                //使用StreamReader类读取文件的内容
                using (StreamReader sr = new StreamReader(fileStream, encoding))
                {
                    //逐行读取文件内容
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //判断该行是否包含用户输入的keyword
                        Match match = regex.Match(line);
                        if (match.Success)
                        {
                            //提取时间和value
                            String time = match.Groups[1].Value;
                            double value = double.Parse(match.Groups[2].Value);
                            //将时间和value添加到DataTable中
                            dataTable.Rows.Add(time, value);
                        }

                        //更新已经读取的字节数
                        bytesRead = (int)sr.BaseStream.Position;
                        //更新进度条的值
                        ProgressBarReadLog.Value = bytesRead;
                    }
                }
            }

            //设置非商业用途的许可证
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            //创建一个新的Excel文件
            using (ExcelPackage package = new ExcelPackage(new FileInfo("logfile.xlsx")))
            {

                // 检查是否存在同名worksheet
                var existingSheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Log Data");
                if (existingSheet != null)
                {
                    // 存在就删除
                    package.Workbook.Worksheets.Delete(existingSheet);
                }

                // 添加新的工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Log Data");

                //将dataTable中的数据导入到工作表中，从A1单元格开始，并包含列名
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);


                // 显示保存文件对话框
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = saveFileDialog.FileName;

                    // 保存到用户选择路径
                    package.SaveAs(new FileInfo(savePath));

                    // 保存成功,弹窗提示
                    MessageBox.Show("文件已成功保存到:" + savePath, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void ReadLog_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
