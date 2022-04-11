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
                result = int.Parse(numbers);
            }

            return result;

        }
    }
}
