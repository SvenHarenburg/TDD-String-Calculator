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
            var result = 0;

            if (!string.IsNullOrEmpty(numbers))
            {
                if (numbers.Contains(delimiter))
                {
                    var splitNumbers = numbers.Split(delimiter);
                    for (int i = 0; i < splitNumbers.Length; i++)
                    {
                        var number = int.Parse(splitNumbers[i]);
                        result += number;
                    }                    
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
