using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.Models
{
    public class SeatingPossibility
    {
        public IEnumerable<Seat> PossibleSeats { get; set; }
        public int Score { get; set; }
        public SeatingPossibility(IEnumerable<Seat> possibleSeats, int score)
        {
            PossibleSeats = possibleSeats;
            Score = score;
        }

    }
}
