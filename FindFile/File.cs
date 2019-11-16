using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FindFile
{
    public class File
    {
        public string name;
        private UInt64 length;
        private string content;


        public File(string name)
        {
            this.name = name;
            this.length = 0;
            this.content = "";
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetLength( UInt64 length )
        {
            this.length = length;
        }

        public void SetContent(string content)
        {
            this.content = content;
        }

        public string GetContent()
        {
            return this.content;
        }

        public string GetName()
        {
            return this.name;
        }

        public UInt64 GetLength()
        {
            return this.length;
        }

        public void SetContentAndLenFromFile()
        {
            try
            {
                StreamReader file = new StreamReader(new FileStream(this.name, FileMode.Open));
                this.content = file.ReadToEnd();
                this.length = (UInt64)(new System.IO.FileInfo(name).Length);
                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot open file: {0}", this.name);
            }
        }

        public static explicit operator string(File file)
        {
            string retString = "name -> " + file.GetName() + "\n"
                             + "size -> " + file.GetLength() + "\n"
                             + "content ->" + file.GetContent() + "\n";
            return retString;
        }
    }
}
