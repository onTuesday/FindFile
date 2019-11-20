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
            File file1 = new File("qwer.txt");
            file1.SetContent("www");
            file1.SetLength((UInt64)123);
            Assert.AreEqual(file1.GetName(), "qwer.txt");
            Assert.AreEqual(file1.GetLength(), (UInt64)123);
            Assert.AreEqual(file1.GetContent(), "www");

            File file2 = new File("MP.txt");
            file2.SetContent("Love 1 2 3");
            file2.SetLength((UInt64)0);
            Assert.AreEqual(file2.GetName(), "MP.txt");
            Assert.AreEqual(file2.GetLength(), (UInt64)0);
            Assert.AreEqual(file2.GetContent(), "Love 1 2 3");

            File file3 = new File("DreamTeam.txt");
            file3.SetContent("Sun and moon");
            file3.SetLength((UInt64)100000);
            Assert.AreEqual(file3.GetName(), "DreamTeam.txt");
            Assert.AreEqual(file3.GetLength(), (UInt64)100000);
            Assert.AreEqual(file3.GetContent(), "Sun and moon");

            File file4 = new File("Wrong name.txt");
            file4.SetName("GoodName.txt");
            file4.SetLength((UInt64)322);

            Assert.AreEqual("GoodName.txt", file4.GetName());
            Assert.AreEqual((UInt64)322, file4.GetLength());
        }

        [TestMethod]
        public void SetContentAndLenFromFile()
        {
            File file1 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\qwer.txt"));

            file1.SetContentAndLenFromFile();
            Assert.AreEqual(file1.GetLength(), (UInt64)5);
            Assert.AreEqual(file1.GetContent(), "Anime");


            File file2 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder5\\From_SOL9RA.txt"));

            file2.SetContentAndLenFromFile();
            Assert.AreEqual(file2.GetLength(), (UInt64)57);
            Assert.AreEqual(file2.GetContent(), "ДОБРОЕ УТРО РИЧАРД! ПРОЧТИ КОММЕНТЫ К ТЕСТАМ И К КЛИЕНТУ!");


            File file3 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder5\\Path.txt"));

            file3.SetContentAndLenFromFile();
            Assert.AreEqual(file3.GetLength(), (UInt64)79);
            Assert.AreEqual(file3.GetContent(), "КАКОЙ АБСОЛЮТНЫЙ ПУТЬ, ИЛИ ТЫ ДУМАЕШЬ У ПОЛЬЗОВАТЕЛЕЙ ТАКАЯ ЖЕ СТРУКТУРА ПАПОК?");


            File file4 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder5\\The sun.txt"));

            file4.SetContentAndLenFromFile();
            Assert.AreEqual(file4.GetLength(), (UInt64)22);
            Assert.AreEqual(file4.GetContent(), "Надеюсь ты выспался)))");


            File file5 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder5\\UInt64.txt"));

            file5.SetContentAndLenFromFile();
            Assert.AreEqual(file5.GetLength(), (UInt64)28);
            Assert.AreEqual(file5.GetContent(), "У нас UInt64, какой ulong???");


            File file6 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder1\\f_Dipth_1(first).txt"));

            file6.SetContentAndLenFromFile();
            Assert.AreEqual(file6.GetLength(), (UInt64)27);
            Assert.AreEqual(file6.GetContent(), "Здравствуйте");


            File file7 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder1\\d_Dipth_1(second)\\f_Dipth_2(first).txt"));

            file7.SetContentAndLenFromFile();
            Assert.AreEqual(file7.GetLength(), (UInt64)42);
            Assert.AreEqual(file7.GetContent(), "Ехал грека через реку");


            File file8 = new File(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\solaraLovesFootball.txt"));

            file8.SetContentAndLenFromFile();
            Assert.AreEqual(file8.GetLength(), (UInt64)5);
            Assert.AreEqual(file8.GetContent(), "Anime");
        }
    }
}
