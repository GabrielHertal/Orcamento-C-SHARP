using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orçamento.Function
{
    public static class CNPJ
    {
        static readonly int[] VectorChecksum1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        static readonly int[] VectorChecksum2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public static bool IsValidCnpj(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return false;

            // Remover caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            if (cnpj.All(c => c == cnpj[0]))
                return false;

            var digits = cnpj.Select(c => c - '0').ToArray();

            if (!CheckSum(digits.AsSpan(..^2), VectorChecksum1, digits[^2]))
                return false;

            return CheckSum(digits.AsSpan(..^1), VectorChecksum2, digits[^1]);
        }

        private static bool CheckSum(ReadOnlySpan<int> digits, ReadOnlySpan<int> multipliers, int expected)
        {
            int sum = 0;
            for (int i = 0; i < digits.Length; ++i)
            {
                sum += digits[i] * multipliers[i];
            }

            int rem = sum % 11;
            rem = rem < 2 ? 0 : 11 - rem;

            return rem == expected;
        }
    }
}
