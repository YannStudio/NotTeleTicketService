using NTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTTS.Services
{
    public class SeatingService : ISeatingService
    {
        public IList<Seat> GetSeats(Event selectedEvent, int AmountOfSelectedTickets)
        {
            Seat[,] seats2 = new Seat[0,0];

            List<Seat> seats = new List<Seat>();
            int counter = 0;
            int ocupiedSeats = selectedEvent.AmountTickets - selectedEvent.AvailableTickets;

            // Fill row of seats
            for (int y = 0; y < 1; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Seat newSeat = new Seat(y, (x + 1), "Available");
                    seats.Add(newSeat);
                }
            }

            
            // Set random seats on ocupied regarding available tickets of selected event
            do
            {
                Random r = new Random();
                int randomSeatNumber = r.Next(0, 4);

                if (seats[randomSeatNumber].State != "Ocupied")
                {
                    seats[randomSeatNumber].State = "Ocupied";
                    counter++;
                }

            } while (counter != ocupiedSeats);


            // Check Consecutive seats in and fill is selection is possible

            var possibleSeats = seats.FindConsecutiveSeats(AmountOfSelectedTickets);
              
            if (possibleSeats.Count() != 0) 
            { 
                foreach (var item in possibleSeats.FirstOrDefault())
                {
                    item.State = "Selected";
                }
            }
            else
            {
                possibleSeats = seats.FindConsecutiveSeats(AmountOfSelectedTickets - 1);

            }

            return seats;
        }
    }
}
