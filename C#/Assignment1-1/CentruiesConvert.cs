namespace _02UnderstandingTypes;

public class CentruiesConvert
{
    public void Convert(int a)
    {
        int years = a * 100;
        double days = years * 365.2422;
        long hours = (long)days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        decimal nanoseconds = (decimal)microseconds * 1000;
        
        Console.WriteLine($"{a} centuries = {years} year = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}