namespace Assignment1_2;

public class findLongestSeq
{
    public void Main()
    {
        Console.WriteLine("Enter the array (space-separated integers):");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxLength = 1;
        int currentLength = 1;
        int element = arr[0]; 
        int bestElement = arr[0]; 

     
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
                bestElement = arr[i];
            }
        }


        Console.WriteLine("The longest sequence is:");
        Console.WriteLine(string.Join(" ", Enumerable.Repeat(bestElement, maxLength)));
    }
}