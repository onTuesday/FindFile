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
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\qwer.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\solaraLovesFootball.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder2\\wer.txt")), true);
            Client.result.Clear(); 
        }

        [TestMethod]
        public void resultTest2()
        {
            Client client2 = new Client();

            string path2 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask2 = "Name~'pic*.jpg'\n";
            client2.Find(path2, mask2);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg")), true );
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture48.jpg")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest3()
        {
            Client client3 = new Client();

            string path3 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask3 = "Name~'pic*.jp*g'\n";
            client3.Find(path3, mask3);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\pict229.jpeg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture48.jpg")), true);

            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest4()
        {
            Client client4 = new Client();

            string path4 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask4 = "(Name~'pic*.jpg')&(10k<=Length<70K)\n";
            client4.Find(path4, mask4);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture1.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture12.jpg")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest5()
        {
            Client client5 = new Client();

            string path5 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask5 = "(Name~'*ber*.jpg')&(100k<=Length)'\n";
            client5.Find(path5, mask5);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\22ofnovember.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\decemberthe25th.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\octoberhalloween31.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\september20.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\septemberthe1.jpg")), true);
            
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest6()
        {
            Client client6 = new Client();

            string path6 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask6 = "(Name~'pic*.txt')&(^(100k<=Length))&(Content~'renown')\n";
            client6.Find(path6, mask6);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picasso.txt")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest7()
        {
            Client client7 = new Client();

            string path7 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask7 = "(Name~'*.jp*g')&(Length>440K)'\n";
            client7.Find(path7, mask7);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\JfK.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\okok.jpg")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\september20.jpg")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest8()
        {
            Client client8 = new Client();

            string path8 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask8 = "(^(Name~'*.jp*g'))&(Length>300K)'\n";
            client8.Find(path8, mask8);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\agatachas0.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\danse_agatha.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Fury_King.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King_Bleid.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\kolorado_king.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\killed.png")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\ugly.png")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest9()
        {
            Client client9 = new Client();

            string path9 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask9 = "Content~'*Goodbye*\n";
            client9.Find(path9, mask9);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Hello.txt")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest10()
        {
            Client client10 = new Client();

            string path10 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask10 = "Content~'Nixon'\n";
            client10.Find(path10, mask10);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King Shawshank.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King The Shining.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\The-Stand.txt")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest11()
        {
            Client client11 = new Client();

            string path11 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask11 = "(^(Name~'King*.txt'))&(Content~'Nixon')\n";
            client11.Find(path11, mask11);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\The-Stand.txt")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest12()
        {
            Client client12 = new Client();

            string path12 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask12 = "(Content~'Nixon')|(^(10<=Length<2M))\n";
            client12.Find(path12, mask12);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King Shawshank.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\King The Shining.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\The-Stand.txt")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest13()
        {
            Client client13 = new Client();

            string path13 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3");
            string mask13 = "((Content~'descrip?ion')&(999<=Length))|(Length<98K)\n";
            client13.Find(path13, mask13);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\pic_description.txt")), true);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder3\\picture.jpg")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest14()
        {
            Client client14 = new Client();

            string path14 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\");
            string mask14 = "Name='kennedy.jpg'\n";
            client14.Find(path14, mask14);
            Assert.AreEqual(Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\kennedy.jpg")), true);
            Client.result.Clear();
        }

        [TestMethod]
        public void resultTest15()
        {
            Client client15 = new Client();

            string path15 = System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4");
            string mask15 = "(374<=Length<=377000\n)";
            client15.Find(path15, mask15);
            Assert.AreEqual(true, Client.result.Contains(System.IO.Path.GetFullPath("..\\..\\..\\Testing\\TestFolder4\\Photos\\1.jpg")));
            Client.result.Clear();
        }
    }
}
