namespace Palindromes.Core.Entities
{
    /// <summary>
    /// Wraps the <see cref="StringPalindrome"/> type. The <see cref="StartIndex"/> and <see cref="EndIndex"/> properties
    /// help to ascertain uniqueness by establishing overlap with other palindromes
    /// </summary>
    public class UniqueStringPalindrome : StringPalindrome
    {
        /// <summary>
        /// Returns the <see cref="Index"/> value but is included because it assists with comphrension
        /// </summary>
        public int StartIndex => Index;

        /// <summary>
        /// Returns the sum of the <see cref="Index"/> and <see cref="Length"/> values
        /// </summary>
        public int EndIndex => Index + Length;

        /// <summary>
        /// Default value is true
        /// </summary>
        public bool Unique { get; set; } = true;

        public UniqueStringPalindrome(string value, int index) : base(value, index) { }
    }
}
