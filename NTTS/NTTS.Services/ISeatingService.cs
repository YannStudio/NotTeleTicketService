using NTTS.Models;
using System.Collections.Generic;

namespace NTTS.Services
{
    public interface ISeatingService
    {
        IList<Seat> GetSeats(Event selectedEvent, int AmountOfSelectedTickets);
    }
}