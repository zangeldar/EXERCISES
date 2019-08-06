using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _619_HiveSimulator
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
            Application.Run(new Form1());
        }

        static public string GetPathToExe()
        {
            string result = @Application.ExecutablePath;
            int posOfLastSlash = result.LastIndexOf('\\');
            posOfLastSlash = Math.Max(posOfLastSlash, result.LastIndexOf('/'));
            result = @result.Substring(0, posOfLastSlash);
            return result;
        }
    }
}
