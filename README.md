------------------------------------
Palindromes finder by Luke Zapraniuk
------------------------------------

2016-03-23

Usage
-----
Open the .sln file in Visual Studio (tested against Community 2015 Update 1) and run the App project (ctrl + f5). Press
enter to use the default text, enter your own text, or press exit to quit the application (hopefully you weren't hoping
to search for the palindromes in the term 'exit'...).

Notes
-----
Written in C# 6.0 targeting .NET Framework 4.5.2.

The only external dependency is Moq in the UnitTests project. This can be grabbed from Nuget.

The prime mover object is Palindrome, which is a generic class because palindromes may also be numbers, bytes etc
(https://en.wikipedia.org/wiki/Longest_palindromic_substring). This unopinionated design decision allows the project to
be extended in the future.

I've taken the term 'unique' in the task specification to be a synonym for overlapping, rather than non-duplicate (if
the Index value is different). This is because, by their very nature, palindromes are composed of sub-sets of
palindromes ('hijkllkjih' contains 'ijkllkji', for example). Consensus around the exact definition of a palindrome is
a little fuzzy.

Algorithm
---------
I rolled my own (horribly inefficient) palindrome finding algorithm across the StringPalindromeFinder and
UniqueStringPalindromeFinder classes. My fag-packet calculations put the time complexity worst-case at between O(2n^2)
and O(2n log(n)). If I had more time I'd provide an implementation using Manacher's algorithm
(https://en.wikipedia.org/wiki/Longest_palindromic_substring) which has linear complexity [O(n)].

Tests
-----
I'd normally bundle my tests into the projects where their testees/targets are, as per the advice of Martin Feathers in
Working Effectively With Legacy code, but that relies on adding a reference to the
Microsoft.VisualStudio.QualityTools.UnitTestFramework assembly manually to the project. To avoid this being potentially
different across machines, I've used a preset UnitTests project instead.