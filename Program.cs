// Uppercase 65-90
// Lowercase 97 - 122
// Number 48-57

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

string input = "A man, a plan, a canal, Panama!";

var summary = BenchmarkRunner.Run<Extensions>();

var extensions = new Extensions();

var res = extensions.IsPalindrome();

Console.Write(res);


public class Extensions
{
    [Benchmark]
    public bool IsPalindrome()
    {
        string input = "A man, a plan, a canal, Panama!";
        StringBuilder sb = new StringBuilder(input);
        StringBuilder reverseSb = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            int code = (int)input[i];
            bool upperCase = code >= 65 && code <= 90;
            bool lowerCase = code >= 97 && code <= 122;
            bool number = code >= 48 && code <= 57;

            if (!upperCase && !lowerCase && !number)
            {
                sb.Remove(i, 1);
            }
            else
            {
                reverseSb.Append(input[i]);
            }

        }
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;
        return comparer.Compare(sb.ToString(), reverseSb.ToString()) == 0;
    }
}


