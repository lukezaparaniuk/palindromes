using Palindromes.Core.Comparers;
using Palindromes.Core.Entities;
using Palindromes.Core.Finders;
using Palindromes.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class StringPalindromeFinderTests
    {
        IPalindromeComparer<string> _comparer;
        Mock<IPalindromeComparer<string>> _mockComparer;
        StringPalindromeFinder _finder;

        [TestInitialize]
        public void TestInitialize()
        {
            _comparer = new StringPalindromeComparer();
            _mockComparer = new Mock<IPalindromeComparer<string>>();
            _finder = new StringPalindromeFinder(_mockComparer.Object);
        }

        [TestMethod]
        public void Can_Find_Successfully()
        {
            // arrange
            const string INPUT = "abcdeedfgh";

            // We're passing through the arguments and calling the implemented method because we want the actual
            // response and there is little value mocking it. Technically this is an integration test, but it runs super
            // quickly
            _mockComparer.Setup(x => x.IsPalindrome(It.IsAny<string>())).Returns((string x) => _comparer.IsPalindrome(x));

            // act
            var result = _finder.Find(INPUT);

            // assert
            Assert.IsNotNull(result);

            // The input string "abcdeedfgh" has 10 single-character palindromes, 9 double-character palindromes, and 1
            // four-character palindrome, so 20 in total
            Assert.AreEqual(20, result.Count());

            // We expect a 4-character palindrome at index position 3 "a[0]b[1]c[2]d[3]..."
            Assert.AreEqual(1, result.Count(x => x.Equals(new StringPalindrome("deed", 3))));
        }

        [TestMethod]
        public void Can_Find_Fails_When_Input_Is_Null()
        {
            // act & assert
            try
            {
                _finder.Find(null);

                Assert.Fail("Exception expected");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }
    }
}
