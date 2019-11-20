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
        /// <summary>
        /// Класс, обслуживающий рекурсивный обход заданной директории.
        /// Для каждого найденного файла вызывает функцию обработчика маски
        /// </summary>

        private MaskHandler maskHandler; 

        public DirectoryHandler( MaskHandler maskHandler )
        {
            this.maskHandler = maskHandler;
        }

        /// <summary>
        /// Рекурсивный обход файлов.
        /// Для каждого найденного файла вызывается Compare для сопоставления файла маске
        /// </summary>
        /// <param name="path">Начальная директория</param>
        /// <returns>Количество найденных файлов</returns>
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
