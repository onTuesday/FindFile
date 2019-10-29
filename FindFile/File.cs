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
        private string name;
        private int length;
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

        public void SetLength( int length )
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

        public int GetLength()
        {
            return this.length;
        }

        public void SetContentAndLenFromFile()
        {
            try
            {
                StreamReader file = new StreamReader(new FileStream(this.name, FileMode.Open));
                this.content = file.ReadToEnd();
                this.length = this.content.Length;
                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cannot open file: {0}", this.name);
            }
        }
    }
}
