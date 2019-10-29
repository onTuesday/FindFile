using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFile;

namespace FindFile
{
    public class Client
    {
        public void Find(string path, string mask)
        {
            DirectoryHandler handler = new DirectoryHandler(path);
            Console.WriteLine("Hello");
            
        }
    }
}
