using Palindromes.Core.Comparers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class StringPalindromeComparerTests
    {
        StringPalindromeComparer _comparer;

        [TestInitialize]
        public void TestInitialize()
        {
            _comparer = new StringPalindromeComparer();
        }

        [TestMethod]
        public void Can_Check_Is_Palindrome_Successfully()
        {
            // act & assert
            Assert.IsTrue(_comparer.IsPalindrome("a"));
            Assert.IsTrue(_comparer.IsPalindrome("ab"));
            Assert.IsTrue(_comparer.IsPalindrome("abba"));
            Assert.IsFalse(_comparer.IsPalindrome("abb")); // Not a palindrome
        }

        [TestMethod]
        public void Can_Check_Is_Palindrome_Fails_When_Input_Is_Null()
        {
            // act & assert
            try
            {
                _comparer.IsPalindrome(null);

                Assert.Fail("Exception expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }
    }
}
