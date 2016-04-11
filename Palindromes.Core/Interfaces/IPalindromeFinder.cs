using Palindromes.Core.Entities;
using System.Collections.Generic;

namespace Palindromes.Core.Interfaces
{
    /// <summary>
    /// Defines behaviour to discover palindromes
    /// </summary>
    /// <typeparam name="T">Underlying palindrome type</typeparam>
    /// <typeparam name="U"><see cref="Palindrome{T}"/> derived object</typeparam>
    public interface IPalindromeFinder<T, U> where U : Palindrome<T>
    {
        /// <summary>
        /// Enumerates through the given input and returns a collection of discovered palindromes values wrapped in a
        /// Palindrome object
        /// </summary>
        IEnumerable<U> Find(T input);
    }
}
