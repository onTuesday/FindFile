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
        private MaskHandler maskHandler; //Класс-обработчик, в который мы посылаем файл

        public DirectoryHandler( MaskHandler maskHandler )
        {
            this.maskHandler = maskHandler;
        }

        public int GetAllFiles(string path)
        {
            int count = 0;
            string[] filesInCurrentDir = Directory.GetFiles(path);
            //Обрабатываем файлы
            foreach (var file in filesInCurrentDir)
            {
                ++count;
                //Передаём файлы в обработчик
                File fileToHandle = new File(file);
                fileToHandle.SetContentAndLenFromFile();
                this.maskHandler.Compare(fileToHandle);
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
