using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;
using System.Collections;

namespace FindFile
{
    public class Client
    {
        public static List<string> result = new List<string>(2);

        public int Find(string path, string mask)
        {
            MaskHandler maskHandler = new MaskHandler(mask);
            DirectoryHandler dirHandler = new DirectoryHandler( maskHandler );

            //Проверка на существование директории
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Cannot find directory");
                throw new DirectotyDoesntExistsException();
            }

            dirHandler.GetAllFiles(path);

            return 0;   
        }
    }
}
