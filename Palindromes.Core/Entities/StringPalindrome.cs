using Palindromes.Core.Utilities;
using System;

namespace Palindromes.Core.Entities
{
    /// <summary>
    /// Represents a palindrome that has an underlying data type of string
    /// </summary>
    public class StringPalindrome : Palindrome<string>
    {
        public override int Index { get; }

        public override int Length { get { return Value.Length; } }

        /// <summary>
        /// Instantiates a new instance of the <see cref="StringPalindrome"/> class. Throws an <see cref="ArgumentNullException"/>
        /// if the value argument is null or an <see cref="ArgumentOutOfRangeException"/> if the index argument is less than zero
        /// </summary>
        public StringPalindrome(string value, int index)
        {
            Value = Preconditions.CheckNotNull(value, nameof(value));
            Index = Preconditions.CheckGreaterThanOrEqualToZero(index, nameof(index));
        }

        /// <summary>
        /// Compares <see cref="StringPalindrome"/> objects for equality based an (ordinal) comparison of the Value
        /// property and the Index property
        /// </summary>
        // Implementation debt https://msdn.microsoft.com/en-us/library/336aedhh(v=vs.85).aspx
        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            return String.Equals(Value, ((StringPalindrome)obj).Value, StringComparison.Ordinal) && Index == ((StringPalindrome)obj).Index;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Index.GetHashCode();
        }
    }
}