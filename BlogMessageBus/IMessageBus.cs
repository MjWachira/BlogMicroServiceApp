﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(object message, string Topic_Queue_Name);
    }
}
