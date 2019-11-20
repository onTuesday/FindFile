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
        private string mask;
        public static File currentFile;
        public static bool final = false;

        public MaskHandler(string mask)
        {
            this.mask = mask;
        }

        public bool Compare(File file)
        {
            MaskHandler.currentFile = file;

            AntlrInputStream input = new AntlrInputStream(this.mask + "\n");
            MaskLexer lexer = new MaskLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            MaskParser parser = new MaskParser(tokens);
            parser.mask();

            //Console.WriteLine("\nПолучен очередной файл");
            //Console.Write((string)file);
            //Console.WriteLine("Тут он будет обрабатываться. Если подошёл по маске, мы его засунем в result");
            //Console.WriteLine(final == true);

            if (final == true)
            {
                Client.result.Add(Path.GetFullPath(file.GetName()));
                return true;
            }
            return false;
        }
    }
}

