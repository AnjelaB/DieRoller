using System;
using System.Collections.Generic;
using System.Linq;
using DieRoller;

namespace assignment5
{
    class Program
    {
        /// <summary>
        /// Static method to print "Two sixes in a row.".
        /// </summary>
        public static void CountOfSixes()
        {
            Console.WriteLine("Two sixes in a row.");
        }
        /// <summary>
        /// Static method to print sum of list elements.
        /// </summary>
        /// <param name="list"></param>
        public static void LastFiveNumbers(List<int> list)
        {
            
            for(int i=0; i<list.Count-1 ;i++)
            {
                Console.Write(list[i] + " + ");
            }
            Console.WriteLine(list.Last() + " >= 20");
        }


        static void Main(string[] args)
        {
            RollADie obj = new RollADie();
            obj.TwoSixesInARow += CountOfSixes;
            obj.SumOfConsequentNumbers += LastFiveNumbers;
            for(int i = 0; i < 50; i++)
            {
                obj.Roll();
            }
            
            Console.WriteLine("The number of times 'Two sixes in a row' appear : " + obj.CountOfSixes);
            Console.ReadLine();
        }
    }
}
