namespace Assignment1_2;

public class PrimeCalculator
{
    public void Main(int StartNum, int EndNum)
    {
        int startNum = StartNum;
        int endNum = EndNum;
        int[] primes = FindPrimesInRange(startNum, endNum);
        
        Console.WriteLine("Prime numbers between " + startNum + " and " + endNum + ":");
        Console.WriteLine(string.Join(", ", primes));
    }
    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        
        for (int num = startNum; num <= endNum; num++)
        {
            bool isPrime = true;

            if (num < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }
}