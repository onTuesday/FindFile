using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindFile
{
    public class File
    {
        /// <summary>
        /// Класс, содержащий имя, размер и содержимое какого-либо файла.
        /// Все три параметра можно менять.
        /// При создании файла непосредственное обращёние по имени не производится.
        /// </summary>

        public string name;
        private UInt64 length;
        private string content;


        public File(string name)
        {
            this.name = name;
            this.length = 0;
            this.content = "";
        }

        /// <summary>
        /// Устанавливает имя файла
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Устанавливает размер файла
        /// </summary>
        /// <param name="length"></param>
        public void SetLength( UInt64 length )
        {
            this.length = length;
        }

        /// <summary>
        /// Устанавливает содержимое файла
        /// </summary>
        /// <param name="content"></param>
        public void SetContent(string content)
        {
            this.content = content;
        }

        /// <summary>
        /// Получить содержимое файла
        /// </summary>
        /// <returns>Содержимое файла</returns>
        public string GetContent()
        {
            return this.content ;
        }

        /// <summary>
        /// Получить имя файла
        /// </summary>
        /// <returns>Имя файла</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// Получить размер файла
        /// 
        /// </summary>
        /// <returns>Размер файла</returns>
        public UInt64 GetLength()
        {
            return this.length;
        }

        /// <summary>
        /// Установить реальный размер и содержимое файла
        /// </summary>
        public void SetContentAndLenFromFile()
        {
            try
            {
                StreamReader file = new StreamReader(new FileStream(this.name, FileMode.Open), System.Text.Encoding.Default);
                this.content = file.ReadToEnd();
                this.length = (UInt64)(new System.IO.FileInfo(name).Length);
                file.Close();
            }
            finally 
            {
                Client.error = "Cannot open file";
            }
        }

        /// <summary>
        /// Тестовый метод
        /// В релизной версии будет удалён
        /// </summary>
        /// <param name="file"></param>
        public static explicit operator string(File file)
        {
            string retString = "name -> " + file.GetName() + "\n"
                             + "size -> " + file.GetLength() + "\n"
                             + "content ->" + file.GetContent() + "\n";
            return retString;
        }
    }
}
