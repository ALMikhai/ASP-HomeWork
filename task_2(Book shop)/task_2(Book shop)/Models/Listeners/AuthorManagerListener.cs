using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;
using task_2_Book_shop_.Models;

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
                            try
                            {
                                string id = AnswerGetter.RequestAndGetAnswer("Id");
                                string firstName = AnswerGetter.RequestAndGetAnswer("First name");
                                string secondName = AnswerGetter.RequestAndGetAnswer("Second name");
                                DateTime dateOfBirthday = DateTime.Parse(AnswerGetter.RequestAndGetAnswer("Date of birthday"));
                                controller.Add(new Author(id, firstName, secondName, dateOfBirthday));
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
            }
        }
    }
}
