using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDefault();
            
        }
        /// <summary>
        /// 加载默认设置
        /// </summary>
        private void LoadDefault()
        {
            //程序名称
            ToolResult tRe= ToolAppConfig.getConfigForAppSettings("name");
            this.Text = tRe.IsSucess?tRe.ObjResult.ToString():"C# WinForm工具集";
            //农历日期
            ToolDate.toolChineseDateTime = new ToolChineseDateTime(DateTime.Now);
            lbl_chineseDate.Text = string.Format("{0} {1} {2} {3} {4} {5} ||{6}",
                ToolDate.toolChineseDateTime.ToChineseEraString(),
                ToolDate.toolChineseDateTime.ChineseWeek,
                ToolDate.toolChineseDateTime.ChineseZodiac,
                ToolDate.toolChineseDateTime.ToChineseString(),
                ToolDate.toolChineseDateTime.SolarTerm,
                ToolDate.toolChineseDateTime.ToDateTime(),
                ToolDate.toolChineseDateTime.ToString());
            
            
        }
    }
}
