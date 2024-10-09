namespace Assignment1_2;

public class RotateArray
{
    public void Main()
    {
        
        Console.WriteLine("Enter the array (space-separated integers):");
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        
        Console.WriteLine("Enter the number of rotations (k):");
        int k = int.Parse(Console.ReadLine());

        int n = arr.Length;
        
        int[] sum = new int[n];
        
        for (int r = 1; r <= k; r++)
        {
            int[] rotated = new int[n];
            for (int i = 0; i < n; i++)
            {
                rotated[(i + r) % n] = arr[i];
            }
            
            for (int i = 0; i < n; i++)
            {
                sum[i] += rotated[i];
            }
        }

    
        Console.WriteLine("Sum of arrays after each rotation:");
        Console.WriteLine(string.Join(" ", sum));
    }
}