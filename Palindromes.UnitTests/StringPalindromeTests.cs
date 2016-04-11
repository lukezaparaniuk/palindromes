using Palindromes.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class StringPalindromeTests
    {
        [TestMethod]
        public void Can_Instantiate_String_Palindrome_Successfully()
        {
            // arrange
            const string EXPECTED_VALUE = "value";
            const int EXPECTED_INDEX = 1;

            // act
            var palindrome = new StringPalindrome(value: EXPECTED_VALUE, index: EXPECTED_INDEX);

            // assert
            Assert.AreEqual(EXPECTED_VALUE, palindrome.Value);
            Assert.AreEqual(EXPECTED_INDEX, palindrome.Index);
            Assert.AreEqual(EXPECTED_VALUE.Length, palindrome.Length);
        }

        [TestMethod]
        public void Can_Instantiate_String_Palindrome_Fails_When_Value_Is_Null()
        {
            // act & assert
            try
            {
                var palindrome = new StringPalindrome(value: null, index: default(int));

                Assert.Fail("Exception expected");
            }
            catch(Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void Can_Instantiate_String_Palindrome_Fails_When_Index_Is_Less_Than_Zero()
        {
            // act & assert
            try
            {
                var palindrome = new StringPalindrome(value: "value", index: -1);

                Assert.Fail("Exception expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void Can_Compare_String_Palindromes_Successfully()
        {
            // act & assert
            // Same
            Assert.IsTrue(new StringPalindrome(value: "a", index: 1).Equals(new StringPalindrome(value: "a", index: 1)));

            // Different value
            Assert.IsFalse(new StringPalindrome(value: "b", index: 1).Equals(new StringPalindrome(value: "a", index: 1)));

            // Different index
            Assert.IsFalse(new StringPalindrome(value: "a", index: 1).Equals(new StringPalindrome(value: "a", index: 2)));
        }
    }
}
