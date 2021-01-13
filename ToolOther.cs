using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTool
{
    /// <summary>
    /// 其他
    /// </summary>
    class ToolOther
    {
        /// <summary>
        /// 启动外部程序,此方法暂时没有写完
        /// </summary>
        /// <param name="fileName"></param>
        private static void CallOutProcess(string fileName)
        {
            System.Diagnostics.ProcessStartInfo pinfo = new System.Diagnostics.ProcessStartInfo();
            pinfo.UseShellExecute = true;
            pinfo.FileName = fileName;
            //启动进程
            System.Diagnostics.Process p = System.Diagnostics.Process.Start(pinfo);
        }
    }
}
