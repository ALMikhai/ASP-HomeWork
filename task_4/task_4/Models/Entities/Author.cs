using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_4.Models.Entities
{
    public class Author
    {
        public int Id { get;  set; }
        [Required]
        public string FirstName { get;  set; }
        [Required]
        public string SecondName { get;  set; }
        [Required]
        public DateTime DateOfBirthday { get;  set; }
    }
}
