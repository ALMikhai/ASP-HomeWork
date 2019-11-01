using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models.Entity;

namespace task_2_Book_shop_.Models
{
    public class Shop
    {
        List<Controller> controllers;
        List<Listener> listeners;

        public Shop()
        {
            controllers = new List<Controller>();
            listeners = new List<Listener>();

            controllers.Add(new Author.AuthorController());
            listeners.Add(new AuthorManagerListener());

            controllers.Add(new Publishing.PublishingController());
            listeners.Add(new PublishingManagerListener());

            controllers.Add(new Genre.PublishingController());
            listeners.Add(new GenreManagerListener());

            controllers.Add(new Book.BookController());
            listeners.Add(new BookManagerListener());
        }

        public void Start()
        {
            string input = "";

            while (input != "exit")
            {
                Console.WriteLine("Pick controller or write 'exit':");
                for (var i = 0; i < controllers.Count; i++)
                {
                    Console.Write(i + " - ");
                    controllers[i].PrintLabel();
                }
                input = Console.ReadLine();

                try
                {
                    listeners[Convert.ToInt32(input)].Start(controllers[Convert.ToInt32(input)]);
                }
                catch
                {
                    Console.WriteLine("Incorrect input, try again...");
                    Console.WriteLine();
                    continue;
                }
            }
        }
    }
}
