using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FindFile
{
    public class DirectoryHandler
    {

        public int GetAllFiles(string path)
        {
            int count = 0;
            string[] filesInCurrentDir = Directory.GetFiles(path);
            //Обрабатываем файлы
            foreach (var file in filesInCurrentDir)
            {
                //Передаём файлы в обработчик
                ++count;
                Console.WriteLine(file);
            }

            //Рекурсивно вызываем данную функцию для каталогов
            string[] directoriesInCurrentDir = Directory.GetDirectories(path);
            foreach (var dir in directoriesInCurrentDir)
            {
                count += GetAllFiles(dir);
            }

            return count;
        }

    }
}
