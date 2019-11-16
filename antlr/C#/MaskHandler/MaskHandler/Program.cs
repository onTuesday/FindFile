using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace MaskHandler
{
    class Program
    {

        public const String Name =  "abc.txt";
        public const UInt64 Length = 150000;
        public const String Content = "helloworld";
        public static bool final;

        static void Main(string[] args)
        {
            AntlrInputStream input = new AntlrInputStream("(140000<=Length<160000)\n");
            MaskLexer lexer = new MaskLexer(input);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            MaskParser parser = new MaskParser(tokens);
            parser.mask();
            Console.WriteLine(final == true);
        }
    }

    //class File
    //{
    //    public static String Name;
    //    public static UInt64 Length;
    //    public static String Content;

    //    public void SetName(String _name)
    //    {
    //        Name = _name;
    //    }

    //    public void SetLength(UInt64 _length)
    //    {
    //        Length = _length;
    //    }

    //    public void SetContent(String _content)
    //    {
    //        Content = _content;
    //    }
    //}
}