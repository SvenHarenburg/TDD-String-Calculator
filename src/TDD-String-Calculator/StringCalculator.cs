﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_String_Calculator
{
    public class StringCalculator
    {
        private readonly string[] defaultDelimiters = new[] { ",", "\n" };
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

            var firstLineIsDelimiter = FirstLineIsDelimiterSpecification(numbers);
            if (firstLineIsDelimiter)
            {
                var specificDelimiter = numbers.Split("\n")[0];
                delimiters = new[] { specificDelimiter };
                numbers = RemoveDelimiterSpecificationFromString(numbers, specificDelimiter);
            }

            var splitNumbers = ParseInputNumbersToIntArray(numbers, delimiters);
            ValidateNumbers(splitNumbers);            
            var sum = splitNumbers.Sum();
            AddOccured?.Invoke(numbers, sum);
            return sum;
        }        
        
        public int GetCalledCount()
        {
            return addCallCount;
        }

        private void ValidateNumbers(int[] numbers)
        {
            var negativeNumbers = numbers.Where(number => number < 0);
            if(negativeNumbers.Any())
            {
                var joined = string.Join(",", negativeNumbers);
                throw new Exception($"negatives not allowed: {joined}");
            }
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
