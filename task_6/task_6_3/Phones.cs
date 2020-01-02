using System;
using System.Collections.Generic;

namespace task_6_3
{
    public partial class Phones
    {
        public Phones()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }
        public string NewField { get; set; }
        public string AnotherField { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
