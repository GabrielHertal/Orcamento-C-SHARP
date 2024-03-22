using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Function
{
    public static class CPF
    {
        static readonly int[] VectorChecksum1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] VectorChecksum2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public static bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            if (cpf.Length != 11)
                return false;

            if (!IsNumeric(cpf))
                return false;

            if (cpf.All(c => c == cpf[0]))
                return false;

            var digits = cpf.Select(c => c - '0').ToArray();

            if (!CheckSum(digits.AsSpan(..^2), VectorChecksum1, digits[^2]))
                return false;

            return CheckSum(digits.AsSpan(..^1), VectorChecksum2, digits[^1]);
        }

        private static bool IsNumeric(string input)
        {
            return input.All(char.IsDigit);
        }

        private static bool CheckSum(ReadOnlySpan<int> digits, ReadOnlySpan<int> multipliers, int expected)
        {
            int sum = 0;
            for (int i = 0; i < digits.Length; ++i)
            {
                sum += digits[i] * multipliers[i];
            }
            var rem = (sum * 10) % 11;
            if (rem == 10)
            {
                rem = 0;
            }
            return rem == expected;
        }
    }
}
