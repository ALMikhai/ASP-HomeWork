using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace task_1
{
    public class CopmToMin : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((int)y - (int)x);
        }
    }

    class Array
    {
        public int[] Data;
        private Random rand = new Random();
        public enum SortTo { min, max }

        public Array(int len, int min, int max)
        {
            Data = new int[len];

            for(var i = 0; i < len; i++)
            {
                Data[i] = rand.Next(min, max);
            }
        }

        public void Print()
        {
            for (var i = 0; i < Data.Length; i++)
            {
                Console.Write("[" + i + "]" + " = " + Data[i] + " ,");
            }
            Console.WriteLine();
        }

        public void Sort(SortTo sight)
        {
            switch (sight)
            {
                case SortTo.max:
                    {
                        System.Array.Sort(Data);
                        break;
                    }
                case SortTo.min:
                    {
                        System.Array.Sort(Data, new CopmToMin());
                        break;
                    }
            }
        }
    }
}
