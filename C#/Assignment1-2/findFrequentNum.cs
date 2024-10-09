namespace Assignment1_2;

public class findFrequentNum
{
    public void Main()
    {
      
        Console.WriteLine("Enter the array (space-separated integers):");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        
        foreach (int num in arr)
        {
            if (frequency.ContainsKey(num))
            {
                frequency[num]++;
            }
            else
            {
                frequency[num] = 1;
            }
        }
        
        int maxFrequency = frequency.Values.Max();
        
        int mostFrequentNumber = arr.First(num => frequency[num] == maxFrequency);
        
        Console.WriteLine($"The most frequent number is: {mostFrequentNumber}");
        
        var mostFrequentNumbers = frequency.Where(pair => pair.Value == maxFrequency).Select(pair => pair.Key).ToList();

        if (mostFrequentNumbers.Count > 1)
        {
            Console.WriteLine("The numbers " + string.Join(", ", mostFrequentNumbers) +
                              " have the same maximal frequency (each occurs " + maxFrequency + " times).");
            Console.WriteLine("The leftmost of them is: " + mostFrequentNumber);
        }
    }
}