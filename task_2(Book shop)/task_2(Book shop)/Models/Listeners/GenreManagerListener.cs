using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;

namespace task_2_Book_shop_.Models
{
    class GenreManagerListener : Listener
    {
        public GenreManagerListener() { }

        public void Start(object obj)
        {
            Controller controller = obj as Controller;

            string input = "";
            while (input != "exit")
            {
                Console.WriteLine("Pick action or write 'exit':");
                controller.PrintInterior();
                input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        {
                            try
                            {
                                string id = AnswerGetter.RequestAndGetAnswer("Id");
                                string name = AnswerGetter.RequestAndGetAnswer("Name");
                                controller.Add(new Genre(id, name));
                            }
                            catch
                            {
                                goto default;
                            }
                            break;
                        }
                    case "1":
                        {
                            string id = AnswerGetter.RequestAndGetAnswer("Id");
                            controller.PrintUI();
                            string fieldNumber = AnswerGetter.RequestAndGetAnswer("variable field number");
                            string newField = AnswerGetter.RequestAndGetAnswer("new value");
                            controller.ChangeElement(id, Convert.ToInt32(fieldNumber), newField);
                            break;
                        }
                    case "2":
                        {
                            string id = AnswerGetter.RequestAndGetAnswer("Id");
                            controller.DeleteElement(id);
                            break;
                        }
                    case "3":
                        {
                            controller.PrintAll();
                            break;
                        }
                    case "4":
                        {
                            string id = AnswerGetter.RequestAndGetAnswer("Id");
                            controller.GetOnId(id);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect input, try again...");
                            break;
                        }
                }
                Console.WriteLine();
            }
        }
    }
}
