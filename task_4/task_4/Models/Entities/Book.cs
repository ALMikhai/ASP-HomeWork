using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_4.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int AuthorId { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
