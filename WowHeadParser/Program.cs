using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WowHeadParser
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.SetOut(RichTextBoxWriter.Instance);
            Application.Run(new FrmMain());
            RichTextBoxWriter.Instance.Close();
        }
    }
}
