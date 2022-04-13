using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    public class StringCalculator
    {
        private const char delimiter = ',';

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            if (!numbers.Contains(delimiter))
            {
                return int.Parse(numbers);
            }

            var splitNumbers = ParseInputNumbersToIntArray(numbers);
            return splitNumbers.Sum();            
        }

        private static int[] ParseInputNumbersToIntArray(string numbers)
        {            
            return numbers
                .Split(delimiter)
                .Select(int.Parse).ToArray();            
        }
    }
}
