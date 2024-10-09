// See https://aka.ms/new-console-template for more information

using _02UnderstandingTypes;

//Practice number sizes and ranges
/*
1.Create a console application project named /Assignment1-1/ that outputs the
number of bytes in memory that each of the following number types uses, and the
minimum and maximum values they can have: sbyte, byte, short, ushort, int, uint, long,
ulong, float, double, and decimal.

Console.WriteLine("Number Type INformation:");
Console.WriteLine($"byte: Size = {sizeof(byte)} bytes, Min = 0 bytes, Max = 255 bytes");
Console.WriteLine($"sbyte: Size = {sizeof(sbyte)} bytes, Min = -128 bytes, Max = 127 bytes");
Console.WriteLine($"short: Size = {sizeof(short)} bytes, Min = -32,768 bytes, Max = 32,767 bytes");
Console.WriteLine($"ushort: Size = {sizeof(ushort)} bytes, Min = 0 bytes, Max = 65,535 bytes");
Console.WriteLine($"int: Size = {sizeof(int)} bytes, Min = -2,147,483,648 bytes, Max = 2,147,483,647 bytes");
Console.WriteLine($"uint: Size = {sizeof(uint)} bytes, Min = 0 bytes, Max = 4,294,967,295 bytes");
Console.WriteLine($"long: Size = {sizeof(long)} bytes, Min = -9,223,372,036,854,775,808 bytes, Max = 9,223,372,036,854,775,807 bytes");
Console.WriteLine($"ulong: Size = {sizeof(ulong)} bytes, Min = 0 bytes, Max = 18,446,744,073,709,551,61 bytes");
Console.WriteLine($"float: Size = {sizeof(float)} bytes, Min = \u00b11.0e-45 bytes, Max = \u00b13.4e38 bytes");
Console.WriteLine($"double: Size = {sizeof(double)} bytes, Min = \u00b15e-324 bytes, Max = \u00b11.7e308 bytes");
Console.WriteLine($"decimal: Size = {sizeof(decimal)} bytes, Min = \u00b11.0\u00d710e-28 bytes, Max =\u00b17.9e28 bytes");
*/



/*
2.Write program to enter an integer number of centuries and convert it to years, days, hours,
 minutes, seconds, milliseconds, microseconds, nanoseconds. Use an appropriate data
 type for every data conversion.

CentruiesConvert demo = new CentruiesConvert();
demo.Convert(5);
*/



//Practice loops and operators

/*
 1.FizzBuzzis a group word game for children to teach them about division. Players take turns
 to count incrementally, replacing any number divisible by three with the word /fizz/, any
 number divisible by five with the word /buzz/, and any number divisible by both with /
 fizzbuzz/.

FizzBuzz demo = new FizzBuzz();
demo.PlayGame();
*/




/*
What will happen if this code executes?
   int max = 500;
   for (byte i = 0; i < max; i++)
   {
    WriteLine(i);
   }

Since the for loop condition checks i < max where max is 500, the loop will continue running.
After i reaches its maximum value (255), it will overflow and wrap around to 0, starting the count again from 0.
This will result in an infinite loop, because i will keep cycling between 0 and 255, and will never reach 500.


What code could you add (don’t change any of the preceding code) to warn us about the problem?


   int max = 500;
   byte previousValue = 0;
   for (byte i = 0; i < max; i++)
   {
    Console.WriteLine(i);
    if (i < previousValue)
    {
     Console.WriteLine("Waring: Overflow occurred, i has wrapped around!");
     break;
    }
    previousValue = i;
   }
*/   





/*2
PrintAPyramid demoPrintAPyramid = new PrintAPyramid();
demoPrintAPyramid.print();
*/



/* 3.
GuessNumber demoGuessNumber = new GuessNumber();
demoGuessNumber.StartGuess();
*/


/* 4.
AgeCalculator demoAgeCalculator = new AgeCalculator();
demoAgeCalculator.Calculator(1996, 1, 26);
*/

/* 5.
GreetingProgram demoGreeting = new GreetingProgram();
demoGreeting.Greet();
*/


CountingProgram demoCountingProgram = new CountingProgram();
demoCountingProgram.Count();
