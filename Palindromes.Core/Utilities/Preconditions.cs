using System;

namespace Palindromes.Core.Utilities
{
    /// <summary>
    /// Static utility methods used to validate arguments. Copied from Jon Skeet's
    /// <a href="https://github.com/haf/NodaTime/blob/master/src/NodaTime/Utility/Preconditions.cs">NodaTime</a>
    /// </summary>
    internal static class Preconditions
    {
        /// <summary>
        /// Returns the given argument after checking whether it's null. This is useful for putting
        /// nullity checks in parameters which are passed to base class constructors.
        /// </summary>
        internal static T CheckNotNull<T>(T argument, string argumentName) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return argument;
        }

        internal static int CheckGreaterThanOrEqualToZero(int argument, string argumentName)
        {
            if (argument < 0)
            {
                throw new ArgumentOutOfRangeException(argumentName, "The argument is not greater than or equal to zero");
            }
            return argument;
        }
    }
}
