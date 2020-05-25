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
                    Seat newSeat = new Seat(y+1, x+1, availableState);
                    newSeat.Score = GetScoreOfSeat(newSeat);
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


                result = FindConsecutiveSeats(currentRow, AmountOfSelectedTickets).ToList();
                if (result.Count != 0)
                {
                    foreach (var item in result)
                    {
                        int Score = 0;
                        foreach (var seat in item)
                        {
                            Score = Score + seat.Score;
                        }
                        SeatingPossibility SeatingResult = new SeatingPossibility(item, Score);
                        possibilities.Add(SeatingResult);
                    }
                }                
            }
            
            // Get object with highest score and set seat to selected state

            var maxObject = possibilities.OrderByDescending(item => item.Score).First();

            foreach (var item in maxObject.PossibleSeats)
            {
                item.State = selectedState;
            }

            // Convert 2d array to IList

            foreach (var item in seats)
            {
                results.Add(item);
            }

            return results;
        }

        // Find n amount consectutive seats in row

        private IEnumerable<IEnumerable<Seat>> FindConsecutiveSeats(IEnumerable<Seat> sequence, int sequenceSize)
        {
            IEnumerable<Seat> results = Enumerable.Empty<Seat>();
            int count = 0;

            foreach (var item in sequence)
            {
                if (item.State == "Available")
                {
                    results = results.Concat(Enumerable.Repeat(item, 1));
                    count++;

                    if (count == sequenceSize)
                    {
                        yield return results;
                        results = results.Skip(1);
                        count--;
                    }
                }
                else
                {
                    count = 0;
                    results = Enumerable.Empty<Seat>();
                }
            }
        }

        // Calculate seat score

        private int GetScoreOfSeat(Seat seat)
        {
            int result = 0;

            if (seat.SeatNumber == 1 || seat.SeatNumber == 5)
            {
                result = 1; 
            }

            if (seat.SeatNumber == 2 || seat.SeatNumber == 4)
            {
                result = 2;
            }

            if (seat.SeatNumber == 3)
            {
                result = 3;
            }

            if (seat.RowNumber == 1 || seat.RowNumber == 5)
            {
                result = result + 1;
            }

            if (seat.RowNumber == 2 || seat.RowNumber == 4)
            {
                result = result + 2;
            }

            if (seat.RowNumber == 3)
            {
                result = result + 3;
            }


            return result;
        } 

    }
}
