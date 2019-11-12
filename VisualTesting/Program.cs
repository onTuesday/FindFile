using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;
using System.Reflection; //Для подключения dll

namespace VisualTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            CallGetAllFiles("C:\\Users\\User\\Desktop\\Repos\\FindFile\\Testing\\testFolder_1");
            File q = new File("qwer");


            
        }

        public static void CallGetAllFiles(string path)
        {
            MaskHandler maskH = new MaskHandler("");
            DirectoryHandler dirHandler = new DirectoryHandler(maskH);
            dirHandler.GetAllFiles(path);
            
        }
    }
}
