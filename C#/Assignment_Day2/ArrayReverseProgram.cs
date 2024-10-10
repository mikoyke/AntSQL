// namespace Assignment_Day2;
//
// public static class ArrayReverseProgram
// {
//
//     
//     public static void Main()
//     {   
//         Console.WriteLine("Generated numbers:");
//         int[] numbers = GenerateNumbers(10);
//         int[] reversedArr = ArrayReverse(numbers);
//         Console.WriteLine("\nReversed numbers:");
//         PrintNumbers(reversedArr);
//     }
//     
//     public static int[] GenerateNumbers(int length)
//     {
//         int[] arr = new int[length];
//         for (int i = 0; i < arr.Length; i++)
//         {
//             arr[i] = new Random().Next(0, 10);
//         }
//      
//         foreach (var n in arr)
//         {
//             Console.Write(n);
//         }
//         return arr;
//     }
//
//     public static int[] ArrayReverse(int[] numbers)
//     {
//         for (int i = 0; i < numbers.Length; i++)
//         {
//             int j = numbers.Length - 1 - i;
//             if (i >= j)
//             {
//                 break;
//             }
//             else
//             {
//                 int m = numbers[j];
//                 numbers[j] = numbers[i];
//                 numbers[i] = m;
//             }
//         }
//
//         return numbers;
//     }
//
//     public static void PrintNumbers(int[] numbers)
//     {
//      
//         foreach (var num in numbers)
//         {
//             Console.Write(num);
//         }
//         
//     }
// }
//
