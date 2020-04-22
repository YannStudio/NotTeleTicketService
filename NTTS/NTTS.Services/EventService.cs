using NTTS.Models;
using System.Collections.Generic;

namespace NTTS.Services
{
    public class EventService : IEventService
    {
        public IList<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            Event randomEvents = new Event("Das Boot", "De beste film ooit gemaakt volgens het Vodhopper team");
            events.Add(randomEvents);
            
            return events;
        }
    }
}
