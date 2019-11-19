using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindFile;

namespace Testing
{
    [TestClass]
    public class Class_File
    {
        [TestMethod]
        public void GetAndSetMethods()
        {
            File file = new File("qwer.txt");
            file.SetContent("www");
            file.SetLength((ulong)123);
            Assert.AreEqual(file.GetName(), "qwer.txt");
            Assert.AreEqual(file.GetLength(), (ulong)123);
            Assert.AreEqual(file.GetContent(), "www");
        }

        [TestMethod]
        public void SetContentAndLenFromFile()
        {
            File file = new File(@"C:\Users\User\Desktop\Repos\FindFile\Testing\For Testing\TestFolder2\Hello.txt");
            file.SetContentAndLenFromFile();
            Assert.AreEqual(file.GetLength(), (ulong)7);
            Assert.AreEqual(file.GetContent(), "Goodbye");
        }
    }
}
