using Palindromes.Core.Interfaces;
using Palindromes.Core.Utilities;
using System;
using System.Linq;

namespace Palindromes.Core.Comparers
{
    public class StringPalindromeComparer : IPalindromeComparer<string>
    {
        /// <summary>
        /// Checks if the input argument is the same whether it is read forwards or backwards. There is no minimum
        /// length restriction. All characters (alphanumeric, whitespace, and symbols) are included in the comparison.
        /// The culture is ignored. It is case-sensitive. An <see cref="ArgumentNullException"/> is thrown if the input
        /// is null
        /// </summary>
        public bool IsPalindrome(string input)
        {
            Preconditions.CheckNotNull(input, nameof(input));

            // Short circuits if the string is less than three characters because, by definition, one- and two-character
            // strings are palindromes
            if (input.Length < 3)
            {
                return true;
            }

            // We use StringComparison.Ordinal here to ignore the culture, rather than InvariantOrdinal, because of its
            // faster behaviour and more logical behaviour (Jeffrey Richter, CLR via C# 4th Edition, p. 324).
            // InvariantOrdinal will, for example, treat 'Strasse' and 'Straße' as equal
            return string.Equals(input, new string(input.Reverse().ToArray()), StringComparison.Ordinal);
        }
    }
}