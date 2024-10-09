using System.Text.RegularExpressions;

namespace Assignment1_2;

public class reverseString
{
    public void useChar()
    {
        Console.WriteLine("Enter a string to reverse: ");
        string input = Console.ReadLine();

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversedString = new string(charArray);
        
        Console.WriteLine($"Reversed string: {reversedString}");
    }

    public void useForLoop()
    {
        Console.WriteLine("Enter a string to reverse: ");
        string input = Console.ReadLine();

        for (int i = input.Length-1; i >=0; i--)
        {
            Console.Write(input[i]);
        }
    }

    public void reverseWordsWithoutChangePunctuation()
    {
        Console.WriteLine("Enter a string to reverse: ");
        string input = Console.ReadLine();

        string pattern = @"[.,:;=()&[\]""'\\/!? ]+";
        string[] words = Regex.Split(input, pattern);
        MatchCollection separators = Regex.Matches(input, pattern);

        List<string> reversedWords = new List<string>();

        for (int i = words.Length - 1; i >= 0; i--)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                reversedWords.Add(words[i]);
            }
        }

        int wordIndex = 0;
        string result = "";

        for (int i = 0; i < reversedWords.Count; i++)
        {
            if (wordIndex < reversedWords.Count)
            {
                result += reversedWords[wordIndex++] + separators[i].Value;
            }
        }
        Console.WriteLine(result);

    }
}