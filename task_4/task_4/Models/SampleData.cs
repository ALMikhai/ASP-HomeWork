using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task_4.Models.Entities;

namespace task_4.Models
{
    public class SampleData
    {
        public static void Initialize(ShopContext context)
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Name =  "War and Peace",
                        DateOfRelease = new DateTime(1999, 12, 2),
                        AuthorId = 0,
                        NumberOfCopies = 100
                    },

                    new Book
                    {
                        Name = "Dead Souls",
                        DateOfRelease = new DateTime(2000, 12, 20),
                        AuthorId = 1,
                        NumberOfCopies = 24
                    },

                    new Book
                    {
                        Name = "Warcraft",
                        DateOfRelease = new DateTime(1990, 4, 28),
                        AuthorId = 2,
                        NumberOfCopies = 14
                    });
            }

            //context.Database.ExecuteSqlCommand("delete from Authors");

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Lev",
                        SecondName = "Tolstoy",
                        DateOfBirthday = new DateTime(1828, 8, 1),
                        CreationDateTime = new DateTime(1990, 10, 21)
                    },

                    new Author 
                    {
                        FirstName = "Nikolay",
                        SecondName = "Gogol",
                        DateOfBirthday = new DateTime(1809, 4, 1),
                        CreationDateTime = DateTime.Now
                    },

                    new Author
                    {
                        FirstName = "WoW",
                        SecondName = "Community",
                        DateOfBirthday = new DateTime(2017, 8, 19),
                        CreationDateTime = new DateTime(2015, 1, 1)
                    });
            }

            context.SaveChanges();
        }
    }
}
