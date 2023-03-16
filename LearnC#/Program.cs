using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            byte age;
            Console.Write("age: ");
            age = Convert.ToByte(Console.ReadLine());
            if(age <= 20 )
            {
                Console.Write("no");
            } 
            else
            {
                Console.Write("yes");
            }
            Console.ReadLine();

        }
    }
}