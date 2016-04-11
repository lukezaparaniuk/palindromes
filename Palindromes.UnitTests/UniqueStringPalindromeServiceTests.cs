using Palindromes.Core.Entities;
using Palindromes.Core.Interfaces;
using Palindromes.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class UniqueStringPalindromeServiceTests
    {
        Mock<IPalindromeFinder<string, StringPalindrome>> _mockFinder;

        UniqueStringPalindromeService _service;

        IEnumerable<StringPalindrome> PALINDROMES = new[]
        {
            new StringPalindrome(value:"a", index: 1),
            new StringPalindrome(value:"bbb", index: 2),
            new StringPalindrome(value:"cccc", index: 3),
            new StringPalindrome(value:"dd", index: 4)
        };

        [TestInitialize]
        public void TestInitialize()
        {
            _mockFinder = new Mock<IPalindromeFinder<string, StringPalindrome>>();

            _mockFinder.Setup(x => x.Find(It.IsAny<string>())).Returns(PALINDROMES);

            _service = new UniqueStringPalindromeService(_mockFinder.Object);
        }

        [TestMethod]
        public void Can_Get_Palindromes_Successfully()
        {
            // act
            var result = _service.GetPalindromes(string.Empty);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
            // "cccc" has the longest length, so should be on top
            Assert.AreEqual(3, result.First().Index);
            // "a" has the shortest length, so should be at the bottom
            Assert.AreEqual(1, result.Last().Index);
        }

        [TestMethod]
        public void Can_Get_Top_Palindromes_Successfully_When_Less_Than_Total()
        {
            // act
            var result = _service.GetPalindromes(string.Empty, top: 3);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void Can_Get_Top_Palindromes_Successfully_When_Greater_Than_Total()
        {
            // act
            // Should not blow up because the result set only has 4 items
            var result = _service.GetPalindromes(string.Empty, top: 5);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }
    }
}
