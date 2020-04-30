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
            List<Seat> results = new List<Seat>();

            // Variables to determine room size
            int quantityColumns = 5;
            int quantityRows = 5;

            // Magicstring room states

            string ocupiedState = "Ocupied";
            string availableState = "Available";
            string selectedState = "Selected";

            // 2d array that will hold the room seats
            Seat[,] seats = new Seat[quantityColumns, quantityRows];

            // Random int generator, Counter, ocupied seats quantity variable to allocate ocupied seats in room
            int counter = 0;
            int ocupiedSeats = selectedEvent.AmountTickets - selectedEvent.AvailableTickets;
            Random r = new Random();

            // Fill room with seats
            for (int y = 0; y < quantityColumns; y++)
            {
                for (int x = 0; x < quantityRows; x++)
                {
                    Seat newSeat = new Seat(y, x, availableState);
                    seats[y, x] = newSeat;
                }
            }

            // Allocate random seats on ocupied regarding available tickets of selected event
            do
            {
                int randomRowNumber = r.Next(0, 4);
                int randomColumnNumber = r.Next(0, 4);

                if (seats[randomColumnNumber, randomRowNumber].State != ocupiedState)
                {
                    seats[randomColumnNumber, randomRowNumber].State = ocupiedState;
                    counter++;
                }

            } while (counter != ocupiedSeats);


            // Check Consecutive seats in room

            List<SeatingPossibility> possibilities = new List<SeatingPossibility>();
            List<IEnumerable<Seat>> result = new List<IEnumerable<Seat>>();

            counter = 0;

            for (int i = 0; i < quantityRows; i++)
            {
                var currentRow = from Seat item in seats
                                 where item.RowNumber == i
                                 select item;

                
                result = currentRow.FindConsecutiveSeats(AmountOfSelectedTickets).ToList();
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        int Score = 0;
                        foreach (var seat in item)
                        {
                            Score = Score + seat.RowNumber;
                        }
                        SeatingPossibility SeatingResult = new SeatingPossibility(item, Score);
                        possibilities.Add(SeatingResult);
                    }
                }                
            }

            var maxObject = possibilities.OrderByDescending(item => item.Score).First();

            foreach (var item in maxObject.PossibleSeats)
            {
                item.State = selectedState;
            }


            foreach (var item in seats)
            {
                results.Add(item);
            }

            return results;
        }
    }
}
