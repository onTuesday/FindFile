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

        public void Compare(File file)
        {
            MaskHandler.currentFile = file;

            AntlrInputStream input = new AntlrInputStream(this.mask + "\n");
            MaskLexer lexer = new MaskLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            MaskParser parser = new MaskParser(tokens);
            parser.mask();

            Console.WriteLine("\nПолучен очередной файл");
            Console.Write((string)file);
            Console.WriteLine("Тут он будет обрабатываться. Если подошёл по маске, мы его засунем в result");
            Console.WriteLine(final == true);

            if (final == true)
            {
                Client.result.Add(Path.GetFullPath(file.GetName()));
            }
        }

        /// <summary>
        /// Функция, которая преобразовывает маску в нормальный вид для последущей работы с antlr
        /// </summary>
        /// <param name="Mask"></param>
        /// <returns>Преобразованная маска</returns>
        public string ConvertMask(string mask)
        {
            mask = mask.Trim();
            //Обработаем случай Length=...
            Regex regEx = new Regex(@"^Length=(?<allVal>(?<val>\d)+(?<char>[gGkKmM]))$", RegexOptions.ExplicitCapture | RegexOptions.IgnorePatternWhitespace);
            Match match = regEx.Match(mask);
            if (match.Success)
            {
                UInt64 newVal = 0;
                string newStringVal = "";

                switch (match.Groups["char"].Value)
                {
                    case "g":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1073741824;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;

                    case "G":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1073741824;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;

                    case "m":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1048576;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;

                    case "M":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1048576;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;

                    case "k":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1024;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;

                    case "K":
                        newVal = UInt64.Parse(match.Groups["val"].Value) * 1024;
                        newStringVal = newVal.ToString();
                        mask = mask.Replace(match.Groups["allVal"].Value, newStringVal);
                        break;
                }

                return mask;
            }
            

            return mask;
        }

    }
}

