using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindFile;
using System.IO;

namespace Testing
{
    [TestClass]
    public class Class_DirectoryHandler
    {
        [TestMethod]
        public void countOfFiles()
        {
            MaskHandler handler = new MaskHandler("");
            DirectoryHandler dHandler = new DirectoryHandler(handler);
            Assert.AreEqual(dHandler.GetAllFiles(Path.GetFullPath("..\\..\\..\\Testing\\testFolder_1")), 6);
        }
    }
}