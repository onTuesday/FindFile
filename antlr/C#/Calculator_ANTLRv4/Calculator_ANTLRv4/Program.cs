using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Antlr4.Runtime;

namespace Calculator_ANTLRv4
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AntlrInputStream input = new AntlrInputStream(Console.In);
                CalcLexer lexer = new CalcLexer(input);
                CommonTokenStream tokens = new CommonTokenStream(lexer);
                CalcParser parser = new CalcParser(tokens);
                parser.calc();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}