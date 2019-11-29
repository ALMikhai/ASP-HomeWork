using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_3_web_api_.Models
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send()
        {
            return ("from text");
        }
    }
}
