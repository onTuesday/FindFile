using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;

using System.Reflection; //Для подключения dll

namespace VisualTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Client a = new Client();
            a.Find("", "");
            
        }
    }
}
