using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_4.Models.Entities
{
    public class Author
    {
        public int Id { get;  set; }
        public string FirstName { get;  set; }
        public string SecondName { get;  set; }
        public DateTime DateOfBirthday { get;  set; }
    }
}
