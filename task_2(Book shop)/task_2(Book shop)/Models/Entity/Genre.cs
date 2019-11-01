using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_Book_shop_.Models.Entity
{
    class Genre
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Genre(string id, string name)
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
            public List<Genre> genres { get; private set; }

            public PublishingController()
            {
                genres = new List<Genre>();
            }

            public bool Add(object obj)
            {
                try
                {
                    if (genres.Find(match => match.Id == (obj as Author).Id) != null)
                    {
                        throw new IdException();
                    }
                    else
                    {
                        genres.Add(obj as Genre);
                        Console.WriteLine("Genre added...");
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
                Genre publish = genres.Find(match => match.Id == id);

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
                    genres.Remove(genres.Find(match => match.Id == id));
                    Console.WriteLine("Genre deleted...");
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or genre not found, try again...");
                    return false;
                }
            }
            public object GetOnId(string id)
            {
                try
                {
                    genres.Find(match => match.Id == id).Print();
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or genre not found, try again...");
                    return false;
                }
            }

            public void PrintAll()
            {
                foreach (var genre in genres)
                {
                    genre.Print();
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
                Console.WriteLine("Genre manager");
            }
        }
    }
}
