using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoardTest
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

            Welcome w1 = new Welcome();
            w1.ShowDialog();
            if (w1.DialogResult == DialogResult.OK)
            {
                Application.Run(new Form1(w1.off));
            }
        }
    }
}
