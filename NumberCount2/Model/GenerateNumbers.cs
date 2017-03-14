using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberCount2.Model
{
    public class GenerateNumbers
    {
        public NumberSeries numbers;

        public NumberSeries UpTo(int highestNumber)
        {
            numbers = new NumberSeries(highestNumber);
            return numbers;
        }
    }
}
