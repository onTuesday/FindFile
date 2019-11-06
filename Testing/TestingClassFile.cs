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
            File file = new File("test.txt");

            file.SetContent("Anime");
            file.SetLength(20);
            file.SetName("I'm File");

            Assert.AreEqual(20, file.GetLength());
            Assert.AreEqual("Anime", file.GetContent());
            Assert.AreEqual("I'm File", file.GetName());
        }

        [TestMethod]
        public void SetContentAndLenFromFileTest()
        {
            File file = new File("q.txt");

            file.SetContentAndLenFromFile();

            Assert.AreEqual("Anime", file.GetContent());
            Assert.AreEqual(5, file.GetLength());
        }
    }
}
