using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;
using System.Reflection; //Для подключения dll
using System.IO;

namespace VisualTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            //CallGetAllFiles(Path.GetFullPath("..\\..\\..\\Testing\\testFolder_1"));
            //Client a = new Client();
            //a.Find("..\\..\\..\\Testing\\testFolder_2", "(Content~'Anime')&(1<=Length<10)");

            MaskHandler qwer = new MaskHandler("Length=1g");
            Console.WriteLine(qwer.ConvertMask("Length=15g"));
        }

        public static void CallGetAllFiles(string path)
        {
            MaskHandler maskH = new MaskHandler("");
            DirectoryHandler dirHandler = new DirectoryHandler(maskH);
            dirHandler.GetAllFiles(path);
            
        }
    }
}
