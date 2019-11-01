using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_Book_shop_.Models
{
    class IdException : Exception
    {
        public IdException()
        : base("An element with that id already exists, try again")
        { }
    }
}
