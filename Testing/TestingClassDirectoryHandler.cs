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
    public class TestingClassDirectoryHandler
    {
        [TestMethod]
        public void countOfFiles()
        {
            MaskHandler handler = new MaskHandler("");
            DirectoryHandler dHandler = new DirectoryHandler(handler);
            Assert.AreEqual(dHandler.GetAllFiles("C:\\Users\\User\\Desktop\\Repos\\FindFile\\Testing\\testFolder_1"), 6);
        }
    }
}
