using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var result = 0;

            if (!string.IsNullOrEmpty(numbers))
            {
                if (numbers.Contains(","))
                {
                    var splitNumbers = numbers.Split(',');
                    result = int.Parse(splitNumbers[0]) + int.Parse(splitNumbers[1]);
                }
                else
                {
                    result = int.Parse(numbers);
                }
            }

            return result;

        }
    }
}
