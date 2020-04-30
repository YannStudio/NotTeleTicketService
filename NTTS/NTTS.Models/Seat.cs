using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.Models
{
    public class Seat
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public string State { get; set; }

        public Seat(int rowNumber, int seatNumber, string state)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            State = state;
        }

    }
}
