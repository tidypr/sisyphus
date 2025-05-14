using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using sisyphus.Models;
using sisyphus.Services;

namespace sisyphus
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
            //Application.Run(new MainForm());


            //Application.Run(new ProductListForm());
            //Application.Run(new ReceiptForm(items));
        }
    }
}
