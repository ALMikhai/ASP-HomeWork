using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;

namespace task_2_Book_shop_.Models
{
    public class Shop
    {
        List<Controller> controllers;

        public Shop()
        {
            controllers = new List<Controller>();
            controllers.Add(new Author.AuthorController());
        }

        public void Start()
        {
            string input = "";

            while(input != "exit")
            {
                Console.WriteLine("Pick controller or write 'exit':");
                foreach(var controll in controllers)
                {
                    Console.WriteLine(controll);// Нормальный вывод контроллера.
                }
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        {
                            AuthorMenagerStart();
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Incorrect input, try again...");
                            continue;
                        }
                }
            }
        }

        private void AuthorMenagerStart()
        {
            // UI для авторов.
        }
    }
}
