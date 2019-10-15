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

        public static double Formula_1(double x) // y = sinx + 1/3 * sin3x.
        {
            return (System.Math.Sin(x) + ((1/3) * System.Math.Sin(3 * x)));
        }

        public static double Formula_2(double x) // y = sinx - (1/3)sin3x + (1/5)sin5x.
        {
            return (System.Math.Sin(x) - ((1 / 3) * System.Math.Sin(3 * x)) + ((1 / 5) * System.Math.Sin(5 * x)));
        }

        public static double Formula_3(double x) // e*sin х.
        {
            return (System.Math.Pow(System.Math.E, x) * System.Math.Sin(x));
        }

        public static double Formula_4(double x) // ???
        {
            return (System.Math.Sqrt(x + System.Math.Sqrt(x + System.Math.Sqrt(x))));
        }
    }
}
