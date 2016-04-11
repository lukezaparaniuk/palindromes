using Palindromes.Core.Comparers;
using Palindromes.Core.Entities;
using Palindromes.Core.Interfaces;
using Palindromes.Core.Utilities;
using System;
using System.Collections.Generic;

namespace Palindromes.Core.Finders
{
    public class StringPalindromeFinder : IPalindromeFinder<string, StringPalindrome>
    {
        private IPalindromeComparer<string> _comparer;

        public StringPalindromeFinder()
        {
            _comparer = new StringPalindromeComparer();
        }

        public StringPalindromeFinder(IPalindromeComparer<string> comparer)
        {
            _comparer = comparer;
        }

        /// <summary>
        /// Returns a collection of found <see cref="StringPalindrome"/> objects. There are no restrictions on the
        /// minimum length of palindromes and duplicates are allowed, although Index properties will differ. If the
        /// input is null, an <see cref="ArgumentNullException"/> is thrown. This implementation has big O time
        /// complexity of between O(n^2) and O(n log(n))
        /// </summary>
        public IEnumerable<StringPalindrome> Find(string input)
        {
            Preconditions.CheckNotNull(input, nameof(input));

            var palindromes = new List<StringPalindrome>();

            // We do not need to grab the length of the input [char] array outside of the for loop because the JIT
            // compiler will optimise this for us (Jeffrey Richter, CLR via C# 4th Edition, p. 386). As per Robert
            // Martin's advice in Clean Code, we give our variables meaningful names
            for (var outerIndex = 0; outerIndex < input.Length; outerIndex++)
            {
                for (var innerIndex = outerIndex + 1; innerIndex <= input.Length; innerIndex++)
                {
                    var substring = input.Substring(outerIndex, innerIndex - outerIndex);

                    if (_comparer.IsPalindrome(substring))
                    {
                        palindromes.Add(new StringPalindrome(substring, outerIndex));
                    }
                }
            }

            return palindromes;
        }
    }
}