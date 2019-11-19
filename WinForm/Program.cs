using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindFile;

namespace WinForm
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void CallGetAllFiles(string path)
        {
            
            MaskHandler maskH = new MaskHandler("");
            DirectoryHandler dirHandler = new DirectoryHandler(maskH);
            dirHandler.GetAllFiles(path);
        }
    }
}
