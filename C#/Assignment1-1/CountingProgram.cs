namespace _02UnderstandingTypes;

public class CountingProgram
{
    public void Count()
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            Console.WriteLine($"Counting by {increment}s: ");

            for (int i = 0; i <= 24; i += increment)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine("\n");
        }
    }
}