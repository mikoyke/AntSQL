namespace Assignment_Day2;

public static class Fibonacci
{
    public static void Main()
    {
        
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Fibonacci({i}) = {FindFibonacci(i)}");
        }
    }

    public static int FindFibonacci(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }

        return FindFibonacci(n - 1) + FindFibonacci(n - 2);
    }
}