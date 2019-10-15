using System;

namespace task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Hello.Print();
            //Math.mathListener();
            Array array = new Array(10, 0, 100);
            array.Print();
            array.Sort(Array.SortTo.min);
            array.Print();
        }
    }
}
