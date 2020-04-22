using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.Models
{
    public class Event
    {

        public string EventName { get; set; }
        public string EventDescription { get; set; }

        public Event(string eventName, string eventDescription)
        {
            EventName = eventName;
            EventDescription = eventDescription;
        }

    }
}
