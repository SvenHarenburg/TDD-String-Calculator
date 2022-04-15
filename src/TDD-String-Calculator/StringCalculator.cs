using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    public class StringCalculator
    {
        private readonly string[] defaultDelimiters = new[] { ",", "\n" };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            bool useSpecificDelimiter = false;
            string specificDelimiter = "";

            if (numbers.Contains("\n"))
            {
                var firstLine = numbers.Split("\n")[0];
                var firstLineIsDelimiter = !int.TryParse(firstLine, out _);
                if (firstLineIsDelimiter)
                {
                    useSpecificDelimiter = true;
                    specificDelimiter = firstLine;
                }
            }

            if (useSpecificDelimiter)
            {
                var numbersWithoutFirstLine = numbers.Remove(0, specificDelimiter.Length + "\n".Length);
                var splitNumbers = ParseInputNumbersToIntArray(numbersWithoutFirstLine, specificDelimiter);
                return splitNumbers.Sum();
            }
            else
            {
                if (!StringContainsAnyDefaultDelimiter(numbers))
                {
                    return int.Parse(numbers);
                }

                var splitNumbers = ParseInputNumbersToIntArrayWithDefaultDelimiters(numbers);
                return splitNumbers.Sum();
            }
        }

        private int[] ParseInputNumbersToIntArrayWithDefaultDelimiters(string numbers)
        {
            return numbers
                .Split(defaultDelimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
        }

        private int[] ParseInputNumbersToIntArray(string numbers, string delimiter)
        {
            return numbers
                .Split(delimiter)
                .Select(int.Parse)
                .ToArray();
        }

        private bool StringContainsAnyDefaultDelimiter(string numbers)
        {
            return defaultDelimiters.Any(
                delimiter => numbers.Contains(delimiter));
        }
    }
}
