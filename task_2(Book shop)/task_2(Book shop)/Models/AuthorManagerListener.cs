using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;

namespace task_2_Book_shop_.Models
{
    public class AuthorMenagerListener : Listener
    {
        public AuthorMenagerListener() { }

        public void Start(object obj)
        {
            Author.AuthorController controller = obj as Author.AuthorController;

            string input = "";
            while(input != "exit")
            {
                Console.WriteLine("Pick action or write 'exit':");
                controller.PrintInterior();
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        {
                            controller.Add(new Author("2", "a", "b", "2013-02-23"));
                            break;
                        }
                    case "1":
                        {
                            break;
                        }
                    case "2":
                        {
                            break;
                        }
                    case "3":
                        {
                            controller.PrintAll();
                            break;
                        }
                    case "4":
                        {
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect input, try again...");
                            break;
                        }
                }
            }
        }
    }
}
