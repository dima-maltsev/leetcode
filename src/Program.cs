//Test("babad", "aba");

using System;

Test("babad", "bab");
Test("bb", "bb");
Test("cbbd", "bb");
Test("bbcd", "bb");
Test("a", "a");
Test("ac", "a");

//Console.WriteLine(IsPalindrome("bbd"));
//Console.WriteLine(IsPalindromeSubstring("babad", 1, 3));

void Test(string input, string expected)
{
    var actual = LongestPalindrome(input);
    if (actual == expected)
    {    
        Console.WriteLine($"Input: {input}. Output: {actual}");
    }
    else
    {
        Console.WriteLine($"ERROR: For input {input} expected {expected} but was {actual}");
    }
}

string LongestPalindrome(string s) 
{
    if (s.Length == 1) return s;

    var start = 0;
    var end = 0;

    for (var i = 0; i < s.Length; i++)
    {
        for (var j = i; j < s.Length; j++)
        {
            if (i == j) continue;

            if (IsPalindromeSubstring(s, i, j) && (j - i) > (end - start))
            {
                start = i;
                end = j;
            }

            if (end - start + 1 > s.Length - i)
            {
                return s.Substring(start, end - start + 1);    
            }
        }
    }    

    return s.Substring(start, end - start + 1);
}

bool IsPalindromeSubstring(string s, int start, int end)
{
    var length = end - start + 1;

    if (length <= 1) return true;

    for (var i = 0; i < length / 2; i++)
    {
        if (s[i + start] != s[end - i]) return false;
    }

    return true;
}

string LongestPalindrome1(string s) 
{
    if (s.Length == 1) return s;

    var longest = s[0].ToString();

    for (var i = 0; i < s.Length - 1; i++)
    {
        for (var j = i + 1; j <= s.Length; j++)
        {
            var substr = s.Substring(i, j - i);
            if (IsPalindrome(substr) && substr.Length > longest.Length)
            {
                longest = substr;
            } 
        }
    }    

    return longest;
}

bool IsPalindrome(string s)
{
    for (var i = 0; i < s.Length / 2; i++)
    {
        if (s[i] != s[s.Length - i - 1]) return false;
    }

    return true;
}
