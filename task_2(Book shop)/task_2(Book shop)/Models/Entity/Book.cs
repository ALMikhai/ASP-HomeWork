using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_Book_shop_.Models.Entity
{
    class Book
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime DateOfRelease { get; protected set; }
        public string AuthorId { get; protected set; }
        public string PablishingId { get; protected set; }
        public List<Genre> Genres { get; protected set; }
        public int NumberOfСopies { get; protected set; }

        public Book(string id, string name, DateTime dateOfRelease, string authorId, string pablishingId, List<Genre> genres)
        {
            Id = id;
            Name = name;
            DateOfRelease = dateOfRelease;
            AuthorId = authorId;
            PablishingId = pablishingId;
            Genres = genres;
            NumberOfСopies = 1;
        }

        private void Print()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Id - {Id}");
            Console.WriteLine($"Name - {Name}");
            Console.WriteLine($"Date Of Release - {DateOfRelease}");
            Console.WriteLine($"Author Id - {AuthorId}");
            Console.WriteLine($"Pablishing Id - {PablishingId}");
            //TODO жанры выписать.
            Console.WriteLine($"Number Of Сopies - {NumberOfСopies}");
            Console.WriteLine("-------------------------------------------");
        }

        public class BookController : Controller
        {
            public List<Book> books { get; private set; }

            public BookController()
            {
                books = new List<Book>();
            }

            public bool Add(object obj)
            {
                Book found = books.Find(match => match.Id == (obj as Book).Id);

                try
                {
                    if (found != null)
                    {
                        throw new IdException();
                    }
                    else
                    {
                        books.Add(obj as Book);
                        Console.WriteLine("Book added...");
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
                Book book = books.Find(match => match.Id == id);

                switch (fieldNumber)
                {
                    case 0:
                        {
                            try
                            {
                                book.Id = newField as string;
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
                                book.Name = newField as string;
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
                                book.DateOfRelease = DateTime.Parse(newField as string);
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
                                book.AuthorId = newField as string;
                                return true;
                            }
                            catch
                            {
                                goto default;
                            }
                        }
                    case 4:
                        {
                            try
                            {
                                book.PablishingId = newField as string;
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
                    books.Remove(books.Find(match => match.Id == id));
                    Console.WriteLine("Book deleted...");
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or book not found, try again...");
                    return false;
                }
            }
            public object GetOnId(string id)
            {
                try
                {
                    books.Find(match => match.Id == id).Print();
                    return true;
                }
                catch
                {
                    Console.WriteLine("Invalid id or book not found, try again...");
                    return false;
                }
            }

            public void PrintAll()
            {
                foreach (var author in books)
                {
                    author.Print();
                    Console.WriteLine();
                }
            }

            public void AddCopyOfBook(string id)
            {
                Book found = books.Find(match => match.Id == id);

                try
                {
                    if (found != null)
                    {
                        found.NumberOfСopies++;
                        Console.WriteLine("Copy of book added...");
                        
                    }
                    else
                    {
                        throw new IdException();
                    }
                }
                catch (IdException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            public void PrintInterior()
            {
                Console.WriteLine("0 - Add");
                Console.WriteLine("1 - Change element");
                Console.WriteLine("2 - Delete element");
                Console.WriteLine("3 - Print all");
                Console.WriteLine("4 - Get on id");
                Console.WriteLine("5 - Add copy");
            }

            public void PrintUI()
            {
                Console.WriteLine("0 - ID");
                Console.WriteLine("1 - Name");
                Console.WriteLine("2 - Date Of Release");
                Console.WriteLine("3 - Author Id");
                Console.WriteLine("4 - Pablishing Id");
            }

            public void PrintLabel()
            {
                Console.WriteLine("Book manager");
            }
        }
    }
}
