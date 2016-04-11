using Palindromes.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Palindromes.UnitTests
{
    [TestClass]
    public class UniqueStringPalindromeTests
    {
        [TestMethod]
        public void Can_Get_Start_Index_Successfully()
        {
            // act & assert
            Assert.AreEqual(1, new UniqueStringPalindrome(value: "value", index: 1).StartIndex);
        }

        [TestMethod]
        public void Can_Get_End_Index_Successfully()
        {
            // act & assert
            // The Index value is 1 and the Value length is 5, so 1 + 5 = 6
            Assert.AreEqual(6, new UniqueStringPalindrome(value: "value", index: 1).EndIndex);
        }

        [TestMethod]
        public void Can_Get_Unique_Successfully()
        {
            // act & assert
            // Defaults to true
            Assert.IsTrue(new UniqueStringPalindrome(value: "value", index: 1).Unique);
        }
    }
}