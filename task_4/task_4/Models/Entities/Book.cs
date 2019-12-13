using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_4.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int NumberOfCopies { get; set; }
    }
}
