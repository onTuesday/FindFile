using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFile
{
    public class DirectotyDoesntExistsException : Exception
    {
        public DirectotyDoesntExistsException()
            : base("Cannot find Directory")
        { }
    }
}
