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
   public class Class_Client
    {
        [TestMethod]
        public void resultTest()
        {
            Client client1 = new Client();

            string path1 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2");
            string mask1 = "";   //Content = Anime
            client1.Find(path1, mask1);
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\qwer.txt"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\solaraLovesFootball.txt"));
            Assert.AreEqual(Client.result[3], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\wer.txt"));
            Assert.AreEqual(Client.result[4], null);   //Вроде... И так далее
        }
    }
}
