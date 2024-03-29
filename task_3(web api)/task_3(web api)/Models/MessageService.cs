﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_3_web_api_.Models
{
    public class MessageService
    {
        private IMessageSender _sender;

        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send()
        {
            return _sender.Send();
        }
    }
}
