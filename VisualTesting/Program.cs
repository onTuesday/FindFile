using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;
using System.Reflection; //Для подключения dll
using System.IO;

namespace VisualTesting
{
    class Program
    {
        static void Main(string[] args)
        {

            Client client9 = new Client();

            string path9 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask9 = "Content~'*Hello*'\n";
            client9.Find(path9, mask9);

            foreach (var e in Client.result)
                Console.WriteLine(e);
        }
    }
}
