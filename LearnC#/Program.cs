using System;

namespace LearnC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            public enum State
        {
            Walking,
            Reading,
            Drinkin
        }
        int[] arr = new int[3];
        int[] temArr = new int[5];

        arr = temArr;
            arr[0] = 5;
            Console.WriteLine(temArr[0]);

            Console.ReadLine();

        }
}
}