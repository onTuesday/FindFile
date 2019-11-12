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
        public void GetAndSetTest()
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
        public void GetAndSetNameTest()
        {
            File file = new File("test.txt");

            file.SetName("Test file");
            file.SetName("Renamed file");

            Assert.AreEqual("Renamed file", file.GetName());
        }

        [TestMethod]
        public void GetAndSetLengthTest()
        {
            File file = new File("test.txt");

            file.SetLength(100);
            file.SetLength(500);

            Assert.AreEqual(500, file.GetLength());
        }

        [TestMethod]
        public void GetAndSetContentTest()
        {
            File file = new File("test.txt");

            file.SetContent("Content maker");
            file.SetContent("Nor you, just ME");

            Assert.AreEqual("Nor you, just ME", file.GetContent());
        }


        [TestMethod]
        public void SetContentAndLenFromFileTest_1()
        {
            File file = new File("..\\..\\q.txt");

            file.SetContentAndLenFromFile();

            Assert.AreEqual("Anime", file.GetContent());
            Assert.AreEqual(5, file.GetLength());
        }

        [TestMethod]
        public void SetContentAndLenFromFileTest_2()
        {
            File file = new File("..\\..\\testFolder_1\\f_Dipth_1(first).txt");

            file.SetContentAndLenFromFile();

            Assert.AreEqual("Здравствуйте", file.GetContent());
            Assert.AreEqual(24, file.GetLength());
        }

        [TestMethod]
        public void SetContentAndLenFromFileTest_3()
        {
            File file = new File("..\\..\\testFolder_1\\f_Dipth_1(second).txt");

            file.SetContentAndLenFromFile();

            Assert.AreEqual("Мама мыла раму", file.GetContent());
            Assert.AreEqual(26, file.GetLength());
        }

        [TestMethod]
        public void SetContentAndLenFromFileTest_4()
        {
            File file = new File("..\\..\\testFolder_1\\f_Dipth_1(third).txt");

            file.SetContentAndLenFromFile();

            //Assert.AreEqual("q", file.GetContent());
            Assert.AreEqual(1, file.GetLength());
        }
    }
}
