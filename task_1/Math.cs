using System;
using System.Collections.Generic;
using System.Text;

namespace task_1
{
    public static class Math
    {
        public static void mathListener()
        {
            string input;
            double first;
            double second;

            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Write operator (+, -, *, /), or 'exit'.");
                    input = Console.ReadLine();

                    if (input == "exit") return;

                    try
                    {
                        Console.WriteLine("Write first num.");
                        first = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Write second num.");
                        second = Convert.ToDouble(Console.ReadLine());

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect num, try again");
                    }
                }

                Console.Write("Answer - ");

                switch (input)
                {
                    case "+":
                        {
                            Console.WriteLine((first + second).ToString());
                            break;
                        }

                    case "-":
                        {
                            Console.WriteLine((first - second).ToString());
                            break;
                        }

                    case "*":
                        {
                            Console.WriteLine((first * second).ToString());
                            break;
                        }

                    case "/":
                        {
                            Console.WriteLine((second != 0) ? (first / second).ToString() : ("Cannot be divided by zero."));
                            break;
                        }

                    default :
                        {
                            Console.WriteLine("Incorrect operator, try again.");
                            break;
                        }
                }
            }
        }
    }
}
