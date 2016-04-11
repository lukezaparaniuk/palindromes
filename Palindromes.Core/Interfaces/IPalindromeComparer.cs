namespace Palindromes.Core.Interfaces
{
    /// <summary>
    /// Defines behaviour used to identify palindromes
    /// </summary>
    /// <typeparam name="T">Underlying palindrome type</typeparam>
    public interface IPalindromeComparer<T>
    {
        /// <summary>
        /// Compares the input to see if the value reads the same forwards and backwards
        /// </summary>
        bool IsPalindrome(T input);
    }
}