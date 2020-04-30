using NTTS.Models;
using System.Collections.Generic;

namespace NTTS.Services
{
    public interface IEventService
    {
        IList<Event> GetAllEvents();
        
    }
}