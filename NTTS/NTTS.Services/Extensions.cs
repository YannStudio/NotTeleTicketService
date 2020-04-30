using NTTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NTTS.Services
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<Seat>> FindConsecutiveSeats(this IEnumerable<Seat> sequence, int sequenceSize)
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

    } 
}
