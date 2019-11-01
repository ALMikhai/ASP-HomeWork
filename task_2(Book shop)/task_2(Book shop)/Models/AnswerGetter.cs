using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_Book_shop_
{
    public static class AnswerGetter
    {
        public static string RequestAndGetAnswer(string fieldName)
        {
            Console.WriteLine($"Write {fieldName}");
            string result = Console.ReadLine();
            return result;
        }
    }
}
