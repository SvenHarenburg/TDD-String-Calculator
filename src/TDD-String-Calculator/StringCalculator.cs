using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    //private struct calculation
    //{
    //    public string numbers;
    //    public string[] delimiters;
    //}

    public class StringCalculator
    {
        private readonly string[] defaultDelimiters = new[] { ",", "\n" };

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = defaultDelimiters;

            var firstLineIsDelimiter = FirstLineIsDelimiterSpecification(numbers);
            if (firstLineIsDelimiter)
            {
                var specificDelimiter = numbers.Split("\n")[0];
                delimiters = new[] { specificDelimiter };
                numbers = RemoveDelimiterSpecificationFromString(numbers, specificDelimiter);
            }

            var splitNumbers = ParseInputNumbersToIntArray(numbers, delimiters);
            return splitNumbers.Sum();
        }                

        private string RemoveDelimiterSpecificationFromString(string numbers, string delimiter)
        {
            var numbersWithoutDelimiterSpecification = numbers.Remove(0, delimiter.Length + "\n".Length);
            return numbersWithoutDelimiterSpecification;
        }

        private bool FirstLineIsDelimiterSpecification(string numbers)
        {
            bool firstLineIsDelimiter = false;
            if (numbers.Contains('\n'))
            {
                var firstLine = numbers.Split("\n")[0];
                firstLineIsDelimiter = !int.TryParse(firstLine, out _);
            }
            return firstLineIsDelimiter;
        }

        private int[] ParseInputNumbersToIntArray(string numbers, string[] delimiters)
        {
            return numbers
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
