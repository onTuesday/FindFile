using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;

namespace FindFile
{
    public class Client
    {
        public int Find(string path, string mask)
        {
            //Проверка на существование директории
            if (!Directory.Exists(path))
            {
                throw new DirectotyDoesntExistsException();
                Console.WriteLine("Cannot find directory");
                return -1;
            }
            //Создаём класс, который будет рекурсивно обходить началбную директорию
            DirectoryHandler handler = new DirectoryHandler();

            return 0;   
        }
    }
}
