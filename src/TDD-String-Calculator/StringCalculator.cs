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
        private readonly string[] delimiters = new[] { ",", "\n" };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            
            if (!StringContainsAnyDelimiter(numbers))
            {
                return int.Parse(numbers);
            }

            var splitNumbers = ParseInputNumbersToIntArray(numbers);
            return splitNumbers.Sum();            
        }        

        private int[] ParseInputNumbersToIntArray(string numbers)
        {
            return numbers
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
        }

        private bool StringContainsAnyDelimiter(string numbers)
        {            
            return delimiters.Any(
                delimiter => numbers.Contains(delimiter));            
        }
    }
}
