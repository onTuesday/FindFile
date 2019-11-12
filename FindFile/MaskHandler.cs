using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFile
{
    public class MaskHandler
    {
        private string mask;
        private string[] result;

        public MaskHandler(string mask)
        {
            this.mask = mask;
        }

        public void Compare(File file)
        {
            //Здесь будет происхдить обработка файлов по маске
            //Если файл подошёл, он будет помещён в result
            Console.WriteLine("\nПолучен очередной файл");
            Console.Write((string)file);
            Console.WriteLine("Тут он будет обрабатываться. Если подошёл по маске, мы его засунем в result");
        }

        public string[] GetResult()
        {
            return this.result;
        }
    }
}
