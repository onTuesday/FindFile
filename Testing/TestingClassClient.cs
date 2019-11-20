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
        public void resultTest1()
        {
            Client client1 = new Client();

            string path1 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2");
            string mask1 = "Content~'Anime'\n";
            client1.Find(path1, mask1);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\qwer.txt"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\solaraLovesFootball.txt"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\wer.txt"));
            Client.result.Clear(); 
        }

        [TestMethod]
        public void resultTest2()
        {
            Client client2 = new Client();

            string path2 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask2 = "Name~'pic*.jpg'\n";
            client2.Find(path2, mask2);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg"));
            Assert.AreEqual(Client.result[3], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture48.jpg"));
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest3()
        {
            Client client3 = new Client();

            string path3 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask3 = "Name~'pic*.jp*g'\n";
            client3.Find(path3, mask3);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\pict229.jpeg"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg"));
            Assert.AreEqual(Client.result[3], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg"));
            Assert.AreEqual(Client.result[4], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture48.jpg"));

            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest4()
        {
            Client client4 = new Client();

            string path4 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask4 = "(Name~'pic*.jpg')&(10k<=Length<70K)\n";
            client4.Find(path4, mask4);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg"));
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest5()
        {
            Client client5 = new Client();

            string path5 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask5 = "(Name~'*ber*.jpg')&(100k<=Length)'\n";
            client5.Find(path5, mask5);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\22ofnovember.jpg"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\decemberthe25th.jpg"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\octoberhalloween31.jpg"));
            Assert.AreEqual(Client.result[3], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\september20.jpg"));
            Assert.AreEqual(Client.result[4], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\septemberthe1.jpg"));
            
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest6()
        {
            Client client6 = new Client();

            string path6 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask6 = "(Name~'pic*.txt')&(^(100k<=Length))&(Content~'renown')\n";
            client6.Find(path6, mask6);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picasso.txt"));
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest7()
        {
            Client client7 = new Client();

            string path7 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask7 = "(Name~'*.jp*g')&(Length>440K)'\n";
            client7.Find(path7, mask7);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\JfK.jpg"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\okok.jpg"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\september20.jpg"));
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest8()
        {
            Client client8 = new Client();

            string path8 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask8 = "(^(Name~'*.jp*g'))&(Length>300K)'\n";
            client8.Find(path8, mask8);
            Assert.AreEqual(Client.result[0], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\agatachas0.txt"));
            Assert.AreEqual(Client.result[1], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\danse_agatha.txt"));
            Assert.AreEqual(Client.result[2], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Fury_King.txt"));
            Assert.AreEqual(Client.result[3], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King_Bleid.txt"));
            Assert.AreEqual(Client.result[4], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\kolorado_king.txt"));
            Assert.AreEqual(Client.result[5], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\killed.png"));
            Assert.AreEqual(Client.result[6], System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\ugly.png"));
            Client.result.Clear();
        }
    }
}
