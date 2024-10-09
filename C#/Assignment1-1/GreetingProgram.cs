namespace _02UnderstandingTypes;

public class GreetingProgram
{
    public void Greet()
    {
        DateTime currentTime = DateTime.Now;

        if (currentTime.Hour >= 6 && currentTime.Hour < 12)
        {
            Console.WriteLine("Good Morning");
        }

        if (currentTime.Hour >= 12 && currentTime.Hour < 17)
        {
            Console.WriteLine("Good Afternoon");
        }

        if (currentTime.Hour >= 17 && currentTime.Hour < 21)
        {
            Console.WriteLine("Good Evening");
        }

        if (currentTime.Hour >= 21 || currentTime.Hour < 6)
        {
            Console.WriteLine("Good Night");
        }
    }
}