using System.Text.RegularExpressions;

namespace Assignment1_2;

public class extractPalindromes
{
    public void Main()
    {
     
        Console.WriteLine("Enter a text to extract palindromes from:");
        string input = Console.ReadLine();
        
        string[] words = Regex.Split(input, @"\W+");
        
        HashSet<string> palindromes = new HashSet<string>();

        
        foreach (string word in words)
        {
            if (IsPalindrome(word)) 
            {
                palindromes.Add(word); 
            }
        }
        
        List<string> sortedPalindromes = palindromes.OrderBy(p => p).ToList();

        
        Console.WriteLine("Unique palindromes:");
        Console.WriteLine(string.Join(", ", sortedPalindromes));
    }

    
    static bool IsPalindrome(string word)
    {
        word = word.ToLower();  
        int length = word.Length;

        for (int i = 0; i < length / 2; i++)
        {
            if (word[i] != word[length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }
}