namespace _02UnderstandingTypes;

public class PrintAPyramid
{
    public void print()
    {
        int numberOfLIne = 5;

        for (int i = 1; i <= numberOfLIne; i++)
        {
            for (int j = numberOfLIne; j > i; j--)
            {
                Console.Write(" ");
            }

            for (int k = 1; k <= (2 * i - 1); k++)
            {
                Console.Write("*");
            }
            
            Console.WriteLine();
        }
    }
}