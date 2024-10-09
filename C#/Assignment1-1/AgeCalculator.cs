namespace _02UnderstandingTypes;

public class AgeCalculator
{
    public void Calculator(int years, int month, int day)
    {
        DateTime birthDate = new DateTime(years, month, day);
        DateTime currentDate = DateTime.Now;
        
        TimeSpan ageSpan = currentDate - birthDate;
        int daysOld = (int)ageSpan.TotalDays;
        Console.WriteLine($"You are {daysOld} years old.");

        int daysToNextAnniversay = 10000 - (daysOld % 10000);
        DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversay);
        Console.WriteLine($"Your next 10000 day anniversary is on: {nextAnniversary.ToShortDateString()}");
    }
}