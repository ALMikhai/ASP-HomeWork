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
        [Required] public DateTime CreationDateTime { get; set; }

        public string TimeFromCreate
        {
            get
            {
                var timeSpan = DateTime.Now - CreationDateTime;
                var result =
                    $"{timeSpan.Days} days, {timeSpan.Hours} hours, {timeSpan.Minutes} minutes, {timeSpan.Seconds} seconds";
                return result;
            }
        }
    }
}
