using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCount2.Model
{
    public class NumberSeries
    {
        public static int? start = 1;
        public int? end = null;
        public Hashtable count = null;

        

        /// <summary>
        /// Calculates the number needed of each digit to write all numbers from 1 up to highestNumber in the decimal system.
        /// </summary>
        /// <param name="highestNumber"></param>
        public NumberSeries(int highestNumber)
        {
            end = highestNumber;
            count = null;  // reset hashtable
            return;
        }  // Constructor

        public int? Count(int digit)
        {
            int? result = null;
            string allDigits = "";
            bool impossible = (digit < 0 || digit > 9);

            if (!impossible)
            {
                int from = (int) (start.HasValue ? start : 1);
                int? to = end;

                if (count == null)
                {
                    allDigits = SortDigits(from, to);

                    // initialize the hashtable
                    count = new Hashtable(10);
                    for (int d = 0; d <= 9; d++)
                    {
                        count.Add(d, 0);
                    }

                    // fill the hashtable
                    CountDigits(allDigits);
                }

                result = (int?) count[digit];
            }

            return result;
        }  // Count()

        private string SortDigits(int from, int? upTo)
        {
            string digits = "";

            if (upTo.HasValue && upTo >= from)
            {
                for (int d = from; d <= upTo; d++)
                {
                    digits += d.ToString();
                }
            }

            return digits;
        }  // SortDigits()

        private void CountDigits(string digits)
        {
            return;
        }  // CountDigits()

    }  // class NumberSeries
}
