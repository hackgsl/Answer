/* ===================================
 * 项目名称：小学生加减乘除出题器
 * 功能描述：Program  
 * 创 建 者：李大书
 * 创建日期：2020-04-13 22:32:40
 * CLR Ver ：4.0.30319.42000
 * =================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 小学生加减乘除出题器
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
