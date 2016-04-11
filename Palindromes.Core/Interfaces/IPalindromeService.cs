using Palindromes.Core.Entities;
using System.Collections.Generic;

namespace Palindromes.Core.Interfaces
{
    /// <summary>
    /// Defines behaviour to get a collection of Palindrome objects from a given input
    /// </summary>
    /// <typeparam name="T">Underlying palindrome value type</typeparam>
    /// <typeparam name="U"><see cref="Palindrome{T}"/> derived object</typeparam>
    public interface IPalindromeService<T, U> where U : Palindrome<T>
    {
        /// <summary>
        /// Returns a collection of Palindrome objects
        /// </summary>
        IEnumerable<U> GetPalindromes(T input);

        /// <summary>
        /// Returns a collection of the top n Palindrome objects
        /// </summary>
        IEnumerable<U> GetPalindromes(T input, int top);
    }
}
