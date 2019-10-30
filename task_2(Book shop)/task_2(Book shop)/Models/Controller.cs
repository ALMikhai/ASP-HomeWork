using System;
using System.Collections.Generic;
using System.Text;
using task_2_Book_shop_.Models;

namespace task_2_Book_shop_.Models
{
    interface Controller
    {
        bool Add(object obj);
        bool ChangeElement(string id, int fieldNumber, object newField);
        bool DeleteElement(string id);
        object GetOnId(string id);
    }
}
