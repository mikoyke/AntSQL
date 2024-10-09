namespace _02UnderstandingTypes;

public class GuessNumber
{
    public void StartGuess()
    {
        int correctNumber = new Random().Next(3) + 1;
        int guessNumber=10;
    
        while (guessNumber != correctNumber)
        {
            guessNumber = int.Parse(Console.ReadLine());
            if (guessNumber == correctNumber)
            {
                Console.WriteLine("Correct");
            }
            else if (guessNumber > 3 && guessNumber < 10)
            {
                Console.WriteLine("Out of range");
            }
            else if (guessNumber > correctNumber)
            {
                Console.WriteLine("Too big");
            }
            else if (guessNumber < correctNumber)
            {
                Console.WriteLine("Too small");
            }
        }
    }
}