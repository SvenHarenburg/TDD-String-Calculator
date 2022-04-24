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
                var specificDelimiter = ReadSpecificDelimiter(numbers);
                delimiters = new[] { specificDelimiter };
                cleanedNumbers = RemoveDelimiterSpecificationFromString(numbers, specificDelimiter);
            }

            var splitNumbers = ParseInputNumbersToIntArray(cleanedNumbers, delimiters);
            RemoveNumbersGreaterThan1000(ref splitNumbers);
            ValidateNumbers(splitNumbers);

            var sum = splitNumbers.Sum();
            RaiseAddOccured(numbers, sum);
            return sum;
        }

        private string ReadSpecificDelimiter(string numbers)
        {
            var specificationLine = numbers.Split("\n")[0];
            specificationLine = specificationLine.Remove(0, DelimiterSpecificationIndicator.Length);

            if (specificationLine.StartsWith('[') && specificationLine.EndsWith(']'))
            {
                specificationLine = specificationLine.Substring(1, specificationLine.Length - 2);                
            }

            var specificDelimiter = specificationLine;
            return specificDelimiter;
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

        private string RemoveDelimiterSpecificationFromString(string numbers, string delimiter)
        {
            var amountOfCharactersToRemove = DelimiterSpecificationIndicator.Length;
            amountOfCharactersToRemove += delimiter.Length;
            amountOfCharactersToRemove += "\n".Length;
            if (delimiter.Length > 1)
            {
                // Greater than 1 means it has to be encased in [] so remove those too
                amountOfCharactersToRemove += 2;
            }

            var numbersWithoutDelimiterSpecification = numbers.Remove(0, amountOfCharactersToRemove);
            return numbersWithoutDelimiterSpecification;
        }

        private bool FirstLineIsDelimiterSpecification(string numbers)
        {
            return numbers.StartsWith(DelimiterSpecificationIndicator);
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
