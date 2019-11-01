using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_Book_shop_.Models.Entity
{
    class Publishing
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Publishing(string id, string name)
        {
            Id = id;
            Name = name;
        }

        private void Print()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Id - {Id}");
            Console.WriteLine($"Name - {Name}");
            Console.WriteLine("-------------------------------------------");
        }

        public class PublishingController : Controller
        {
            public List<Publishing> publishings { get; private set; }

            public PublishingController()
            {
                publishings = new List<Publishing>();
            }

            public bool Add(object obj)
            {
                try
                {
                    if (publishings.Find(match => match.Id == (obj as Author).Id) != null)
                    {
                        throw new IdException();
                    }
                    else
                    {
                        publishings.Add(obj as Publishing);
                        Console.WriteLine("Publishing added...");
                    }
                }
                catch (IdException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }

                return true;
            }

            public bool ChangeElement(string id, int fieldNumber, object newField)
            {
                Publishing publish = publishings.Find(match => match.Id == id);

                switch (fieldNumber)
                {
                    case 0:
                        {
                            try
                            {
                                publish.Id = newField as string;
                                return true;
                            }
                            catch
                            {
                                goto default;
                            }
                        }
                    case 1:
                        {
                            try
                            {
                                publish.Name = newField as string;
                                return true;
                            }
                            catch
                            {
                                goto default;
                            }
                        }
                    default:
                        {
                            Console.WriteLine("Invalid field number or new state, try again...");
                            return false;
                        }
                }
            }
            public bool DeleteElement(string id)
            {
                try
                {
                    publishings.Remove(publishings.Find(match => match.Id == id));
                    Console.WriteLine("Author deleted...");
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or author not found, try again...");
                    return false;
                }
            }
            public object GetOnId(string id)
            {
                try
                {
                    publishings.Find(match => match.Id == id).Print();
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or author not found, try again...");
                    return false;
                }
            }

            public void PrintAll()
            {
                foreach (var author in publishings)
                {
                    author.Print();
                    Console.WriteLine();
                }
            }

            public void PrintInterior()
            {
                Console.WriteLine("0 - Add");
                Console.WriteLine("1 - Change element");
                Console.WriteLine("2 - Delete element");
                Console.WriteLine("3 - Print all");
                Console.WriteLine("4 - Get on id");
            }

            public void PrintUI()
            {
                Console.WriteLine("0 - ID");
                Console.WriteLine("1 - Name");
            }

            public void PrintLabel()
            {
                Console.WriteLine("Publishing manager");
            }
        }
    }
}
