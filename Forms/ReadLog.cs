using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Thermal_Tools.Forms
{
    public partial class ReadLog : Form
    {
        public ReadLog()
        {
            InitializeComponent();
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
            }
        }

        private void BtnReadLogConfirm_Click(object sender, EventArgs e)
        {
            string Keyword = TextBoxLogKeyWords.Text.Trim();

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
                    }
                }
            }

            //将DataTable赋值给DataGridView
            dataGridViewResult.DataSource = dataTable;
            //调整DataGridView的样式和布局
            dataGridViewResult.AutoResizeColumns();
        }
    }
}
