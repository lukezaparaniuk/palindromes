using Palindromes.Core.Entities;
using Palindromes.Core.Finders;
using Palindromes.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class UniqueStringPalindromeFinderTests
    {
        Mock<IPalindromeFinder<string, StringPalindrome>> _mockFinder;
        UniqueStringPalindromeFinder _finder;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockFinder = new Mock<IPalindromeFinder<string, StringPalindrome>>();

            _finder = new UniqueStringPalindromeFinder(_mockFinder.Object);
        }

        [TestMethod]
        public void Can_Find_Successfully()
        {
            // arrange
            const string INPUT = "abbabb";

            _mockFinder.Setup(x => x.Find(INPUT)).Returns(new[]
            {
                new StringPalindrome(value: "bb", index: 1),
                new StringPalindrome(value: "abba", index: 0),
                new StringPalindrome(value: "bbabb", index: 1),
                new StringPalindrome(value: "bab", index: 2)
            });

            // act
            var result = _finder.Find(INPUT);

            // assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result.Count(x => x.Equals(new UniqueStringPalindrome(value: "abba", index: 0))));
            Assert.AreEqual(1, result.Count(x => x.Equals(new UniqueStringPalindrome(value: "bbabb", index: 1))));
        }
    }
}