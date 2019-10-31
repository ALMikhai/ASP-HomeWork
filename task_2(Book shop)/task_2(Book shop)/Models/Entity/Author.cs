using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;

namespace task_2_Book_shop_.Models.Entity
{
    public class Author
    {
        public string Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string SecondName { get; protected set; }
        public DateTime DateOfBirthday { get; protected set; }

        public Author(string id, string firstName, string secondName, string dateOfBirthday)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;

            try
            {
                DateOfBirthday = DateTime.Parse(dateOfBirthday);
            }
            catch
            {
                Console.WriteLine("Invalid date string, try again...");
            }
        }

        private void Print()
        {
            Console.WriteLine($"Id - {Id}");
            Console.WriteLine($"First name - {FirstName}");
            Console.WriteLine($"Second name - {SecondName}");
            Console.WriteLine($"Date of birthday - {DateOfBirthday}");
        }

        public class AuthorController : Controller
        {
            public List<Author> authors { get; private set; }

            public AuthorController()
            {
                authors = new List<Author>();
            }

            public bool Add(object obj)
            {
                try
                {
                    authors.Add(obj as Author);
                    Console.WriteLine("Author added...");
                }
                catch
                {
                    Console.WriteLine("Failed to add new item, try again...");
                    return false;
                }

                return true;
            }

            public bool ChangeElement(string id, int fieldNumber, object newField)
            {
                Author author = authors.Find(match => match.Id == id);

                switch (fieldNumber)
                {
                    case 0:
                        {
                            try
                            {
                                author.Id = newField as string;
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
                                author.FirstName = newField as string;
                                return true;
                            }
                            catch
                            {
                                goto default;
                            }
                        }
                    case 2:
                        {
                            try
                            {
                                author.SecondName = newField as string;
                                return true;
                            }
                            catch
                            {
                                goto default;
                            }
                        }
                    case 3:
                        {
                            try
                            {
                                author.DateOfBirthday = DateTime.Parse(newField as string);
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
                    authors.Remove(authors.Find(match => match.Id == id));
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
                    authors.Find(match => match.Id == id).Print();
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
                foreach(var author in authors)
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
                Console.WriteLine("1 - First name");
                Console.WriteLine("2 - Second name");
                Console.WriteLine("3 - Date of birthday");
            }

            public void PrintLabel()
            {
                Console.WriteLine("Author manager");
            }
        }
    }
}
