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
            
            Assembly dll = Assembly.Load(@"FindFile");

            Object client = dll.CreateInstance("Client");
            Type T = dll.GetType("Client");

            MethodInfo FindInfo = T.GetMethod("Find");

            object[] FindArgs = new object[2];
            FindArgs[0] = "qqq";
            FindArgs[1] = "www";

            FindInfo.Invoke(client, FindArgs);
        }
    }
}
