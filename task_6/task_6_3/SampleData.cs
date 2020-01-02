using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_6_3
{
    public static class SampleData
    {
        public static void Initialize(mobilestoredbContext context)
        {
            if (!context.NewPhones.Any())
            {
                context.NewPhones.AddRange(
                    new Phones
                    {
                        Name = "iPhone X",
                        Company = "Apple",
                        Price = 600,
                        NewField = "test",
                        AnotherField = "123"
                    },
                    new Phones
                    {
                        Name = "Samsung Galaxy Edge",
                        Company = "Samsung",
                        Price = 550,
                        NewField = "test",
                        AnotherField = "123"
                    },
                    new Phones
                    {
                        Name = "Pixel 3",
                        Company = "Google",
                        Price = 500,
                        NewField = "test",
                        AnotherField = "123"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
