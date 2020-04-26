using NTTS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.UI.WPF.Messages
{
    public class EventDetailMessage
    {
        public Event EventInfo { get; set; }
        public EventDetailMessage(Event eventInfo)
        {
            EventInfo = eventInfo;
        }

    }
}
