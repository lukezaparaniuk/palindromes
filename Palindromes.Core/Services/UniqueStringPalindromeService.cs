using Palindromes.Core.Entities;
using Palindromes.Core.Finders;
using Palindromes.Core.Interfaces;
using Palindromes.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes.Core.Services
{
    public class UniqueStringPalindromeService : IPalindromeService<string, StringPalindrome>
    {
        private IPalindromeFinder<string, StringPalindrome> _finder = new UniqueStringPalindromeFinder();

        public UniqueStringPalindromeService() { }

        public UniqueStringPalindromeService(IPalindromeFinder<string, StringPalindrome> finder)
        {
            _finder = finder;
        }

        /// <summary>
        /// Gets a collection of <see cref="StringPalindrome"/> objects from the input using the <see cref="UniqueStringPalindromeFinder"/>
        /// finder implementation by default. The collection is sorted descendingly on the <see cref="StringPalindrome.Length"/> property.
        /// Throws an <see cref="ArgumentNullException"/> if the input is null
        /// </summary>
        public IEnumerable<StringPalindrome> GetPalindromes(string input)
        {
            Preconditions.CheckNotNull(input, nameof(input));

            return _finder.Find(input).OrderByDescending(x => x.Length);
        }

        /// <summary>
        /// Like the <see cref="GetPalindromes(string)"/> method, but limits the collection size as specified by the top
        /// argument. If the top argument is less that zero, a <see cref="ArgumentOutOfRangeException"/> is thrown
        /// </summary>
        public IEnumerable<StringPalindrome> GetPalindromes(string input, int top)
        {
            Preconditions.CheckGreaterThanOrEqualToZero(top, nameof(top));

            return GetPalindromes(input).Take(top);
        }
    }
}
