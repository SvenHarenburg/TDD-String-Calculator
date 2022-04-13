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
            var sum = splitNumbers.Sum();
            return sum;
        }

        private static int[] ParseInputNumbersToIntArray(string numbers)
        {
            var result = new int[numbers.Length];
            var splitNumbers = numbers.Split(delimiter);
            for (int i = 0; i < splitNumbers.Length; i++)
            {
                var number = int.Parse(splitNumbers[i]);
                result[i] = number;
            }
            return result;
        }
    }
}
