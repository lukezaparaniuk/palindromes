using System.Diagnostics;

namespace Palindromes.Core.Entities
{
    /// <summary>
    /// Generic base class that represents a palindrome of underlying type T and associated metadata. A palindrome is
    /// defined as, "a word, phrase, number, or other sequence of characters which reads the same backward or forward"
    /// (<a href="https://en.wikipedia.org/wiki/Palindrome">Wikipedia</a>)
    /// </summary>
    /// <typeparam name="T">Underlying Palindrome type</typeparam>
    [DebuggerDisplay("Value = {Value}, Index = {Index}, Length = {Length}")]
    public abstract class Palindrome<T>
    {
        /// <summary>
        /// Palindrome
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The palindrome's position in the source (usually 0-based). Be careful of the Int32 type because it has the
        /// potential to wrap at Int32.MaxValue + 1, which will no doubt cause mischief
        /// </summary>
        public abstract int Index { get; }

        /// <summary>
        /// The palindrome's ordinal length. The same warning that applies to <see cref="Index"/> applies here also
        /// </summary>
        public abstract int Length { get; }
    }
}
