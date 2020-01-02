using System;
using System.Collections.Generic;

namespace WebApplication1
{
    public partial class Vacancy
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int EmployerId { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary { get; set; }
        public string Description { get; set; }
    }
}
