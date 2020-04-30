using NTTS.Models;
using System;
using System.Collections.Generic;

namespace NTTS.Services
{
    public class EventService : IEventService
    {
        public IList<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            
            
            for (int i = 0; i < 5; i++)
            {
                Guid eventId = Guid.NewGuid();
                Random r = new Random();
                Event randomEvents = new Event(eventId,"Das Boot", "De beste film ooit gemaakt volgens het Vodhopper team", 5,r.Next(1,4));
                events.Add(randomEvents);
            }          
            
            return events;
        }

    }
}
