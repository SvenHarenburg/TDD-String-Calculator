using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    public class StringCalculator
    {
        private readonly List<string> defaultDelimiters = new List<string>() { ",", "\n" };
        private const string DelimiterSpecificationIndicator = "//";
        private int addCallCount = 0;

        public event Action<string, int>? AddOccured;

        public int Add(string numbers)
        {
            addCallCount++;
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = defaultDelimiters;
            var cleanedNumbers = numbers;
            var firstLineIsDelimiter = FirstLineIsDelimiterSpecification(numbers);
            if (firstLineIsDelimiter)
            {
                delimiters = ReadSpecificDelimiters(numbers);
                cleanedNumbers = RemoveDelimiterSpecificationFromString(numbers);
            }

            var splitNumbers = ParseInputNumbersToIntArray(cleanedNumbers, delimiters);
            RemoveNumbersGreaterThan1000(ref splitNumbers);
            ValidateNumbers(splitNumbers);

            var sum = splitNumbers.Sum();
            RaiseAddOccured(numbers, sum);
            return sum;
        }

        private List<string> ReadSpecificDelimiters(string numbers)
        {
            var specificationLine = numbers.Split("\n")[0];
            specificationLine = specificationLine.Remove(0, DelimiterSpecificationIndicator.Length);

            var delimiters = new List<string>();
            if (specificationLine.StartsWith('[') && specificationLine.EndsWith(']'))
            {
                delimiters = ReadDelimitersInSquareBrackets(specificationLine);   
            }
            else
            {
                delimiters.Add(specificationLine);
            }

            return delimiters;
        }

        private List<string> ReadDelimitersInSquareBrackets(string specificationLine)
        {
            var delimiters = new List<string>();
            var segmentOpen = false;
            var currentDelimiter = new StringBuilder();

            for (int i = 0; i < specificationLine.Length; i++)
            {
                var currentChar = specificationLine[i];
                if (currentChar == '[' && !segmentOpen)
                {
                    segmentOpen = true;
                    currentDelimiter.Clear();
                    continue;
                }

                if (currentChar == ']' && segmentOpen)
                {
                    segmentOpen = false;
                    delimiters.Add(currentDelimiter.ToString());
                    continue;
                }

                currentDelimiter.Append(currentChar);
            }
            return delimiters;
        }

        private void RemoveNumbersGreaterThan1000(ref int[] numbers)
        {
            numbers = numbers.Where(number => number <= 1000).ToArray();
        }

        public int GetCalledCount()
        {
            return addCallCount;
        }

        private void RaiseAddOccured(string numbers, int result)
        {
            AddOccured?.Invoke(numbers, result);
        }

        private void ValidateNumbers(int[] numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0);
            if (negativeNumbers.Any())
            {
                var joined = string.Join(",", negativeNumbers);
                throw new Exception($"negatives not allowed: {joined}");
            }
        }

        private string RemoveDelimiterSpecificationFromString(string numbers)
        {
            var indexOfNewLine = numbers.IndexOf("\n");
            var numbersWithoutDelimiterSpecification = numbers.Substring(indexOfNewLine, numbers.Length - indexOfNewLine);

            return numbersWithoutDelimiterSpecification;
        }

        private bool FirstLineIsDelimiterSpecification(string numbers)
        {
            return numbers.StartsWith(DelimiterSpecificationIndicator);
        }

        private int[] ParseInputNumbersToIntArray(string numbers, List<string> delimiters)
        {
            return numbers
                .Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
