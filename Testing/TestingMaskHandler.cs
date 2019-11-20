using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FindFile;

namespace Testing
{
    
    [TestClass]
    public class TestingMaskHandler
    {
        [TestMethod]
        public void Test1()
        {
            File file = new File(@"C:\Users\User\Desktop\Repos\FindFile\Testing\For Testing\TestFolder1\picture.jpg");
            file.SetContentAndLenFromFile();
            MaskHandler maskH = new MaskHandler("Name~'pic*.jpg'");
            bool res = maskH.Compare(file);
            Assert.AreEqual(res, true);
        }
    }
}
