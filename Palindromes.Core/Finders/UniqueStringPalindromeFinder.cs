using Palindromes.Core.Entities;
using Palindromes.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes.Core.Finders
{
    // We don't subclass StringPalindromeFinder because we don't want the base Find method being explicitly accessed. We
    // can't override it (and it isn't virtual anyway) because we'll change its behaviour
    public class UniqueStringPalindromeFinder : IPalindromeFinder<string, StringPalindrome>
    {
        private IPalindromeFinder<string, StringPalindrome> _finder { get; } = new StringPalindromeFinder();

        public UniqueStringPalindromeFinder() { }

        public UniqueStringPalindromeFinder(IPalindromeFinder<string, StringPalindrome> finder)
        {
            _finder = finder;
        }

        /// <summary>
        /// Depends on the functionality provided by <see cref="StringPalindromeFinder"/> by default (this can be
        /// changed through the <see cref="IPalindromeFinder"/>-accepting constructor. It returns the longest unique
        /// [non-overlapping] palindromes. For example, the input "abba" contains the palindromes "abbabb" and "bb", but
        /// only "abba" is returned because it fully overlaps "bb". However, "bbabb" will also be returned because
        /// "abba" only partially overlaps it.
        ///
        /// It enumerates the input in much the same way as <see cref="StringPalindromeFinder"/>, so has complexity of
        /// between between O(2n^2) and O(2n log(n))
        /// </summary>
        public IEnumerable<StringPalindrome> Find(string input)
        {
            var palindromes = _finder.Find(input).Select(x => new UniqueStringPalindrome(x.Value, x.Index)).ToArray();

            for (var n = 0; n < palindromes.Length; n++)
            {
                for (var m = 0; m < palindromes.Length; m++)
                {
                    if (n != m)
                    {
                        var lhs = palindromes[n].StartIndex <= palindromes[m].StartIndex; // Left-hand side
                        var rhs = palindromes[n].EndIndex >= palindromes[m].EndIndex; // Right-hand side

                        if (lhs && rhs)
                        {
                            palindromes[m].Unique = false;
                        }
                    }
                }
            }

            return palindromes.Where(x => x.Unique);
        }
    }
}
