using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCount2.Model
{
    public class NumberSeries
    {
        public int ID { get; set; }  // Required for the primary key when building a Controller with a database for the Model

        public string upto { get; set; }


        public static int? start = 1;
        public int? end = null;
        public Dictionary<Byte, int> count = null;
        
        /// <summary>
        /// Calculates the number needed of each digit to write all numbers from 1 up to highestNumber in the decimal system.
        /// </summary>
        /// <param name="highestNumber"></param>
        public NumberSeries(int highestNumber)
        {
            end = highestNumber;
            count = null;  // reset Dictionary
            return;
        }  // Constructor

        public int? Count(int digit)
        {
            int? result = null;
            string allDigits = "";
            string allDigitsSorted = "";
            bool impossible = (digit < 0 || digit > 9);

            if (!impossible)
            {
                int from = (int) (start.HasValue ? start : 1);
                Byte idx = Convert.ToByte(digit);
                int? to = end;

                if (count == null)
                {
                    // initialize the hashtable
                    count = new Dictionary<Byte, int>(10);
                    for (Byte d = 0; d <= 9; d++)
                    {
                        count.Add(d, 0);
                    }

                    allDigits = WriteDigits(from, to);
                    allDigitsSorted = SortDigits(allDigits);

                    // fill the hashtable
                    CountDigits(allDigitsSorted);
                }

                result = (int?) count[idx];
            }

            return result;
        }  // Count()

        private string WriteDigits(int from, int? upTo)
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
        }  // WriteDigits()

        private string SortDigits(string digits)
        {
            char[] digitList = digits.ToArray();

            digits = "";
            Array.Sort(digitList);
            foreach (char digit in digitList)
            {
                digits += digit;
            }

            return digits;
        }  // SortDigits()

        private void CountDigits(string digitList)
        {
            int newOffset = 0;
            int previousOffset = 0;

            // we assume that the string contains every digit between 1 and its highest digit
            for (Byte i = 0; i <= 9; i++)
            {
                if (previousOffset < digitList.Length)
                {
                    char digit = (char)(i + '1');
                    newOffset = digitList.Contains(digit) ? digitList.IndexOf(digit) : (i == 0 ? 0 : digitList.Length);
                }
                count[i] = newOffset - previousOffset;
                previousOffset = newOffset;
            }

            return;
        }  // CountDigits()

    }  // class NumberSeries
}
