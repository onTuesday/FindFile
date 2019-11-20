using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using Antlr4.Runtime;
using System.Text.RegularExpressions;

namespace FindFile
{
    public class MaskHandler
    {
        /// <summary>
        /// Класс, который сопоставляет файлы нашей маске и в случае успеха добавляет их в Client.result
        /// </summary>

        private string mask;
        public static File currentFile;
        public static bool final = false;

        public MaskHandler(string mask)
        {
            this.mask = mask;
        }

        /// <summary>
        /// Сопоставить файл с маской
        /// </summary>
        /// <param name="file">Файл для проверки</param>
        /// <returns>Возвращает true если файл подошёл по маске, false в противном случае.</returns>
        public bool Compare(File file)
        {
            MaskHandler.currentFile = file;

            AntlrInputStream input = new AntlrInputStream(this.mask + "\n");
            MaskLexer lexer = new MaskLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            MaskParser parser = new MaskParser(tokens);
            parser.mask();

            if (final == true)
            {
                Client.result.Add(Path.GetFullPath(file.GetName()));
                return true;
            }
            return false;
        }
    }
}

