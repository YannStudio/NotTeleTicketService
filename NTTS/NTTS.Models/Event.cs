using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int AmountTickets { get; set; }
        public int AvailableTickets { get; set; }

        public Event(Guid eventId, string eventName, string eventDescription, int amountTickets, int availableTickets)
        {
            EventId = eventId;
            EventName = eventName;
            EventDescription = eventDescription;
            AmountTickets = amountTickets;
            AvailableTickets = availableTickets;
            
        }

    }
}
