using System;
using System.Collections.Generic;
using System.Linq;

namespace DieRoller
{
    /// <summary>
    /// Class to implement Die Roller.
    /// </summary>
    public class RollADie
    {
        /// <summary>
        /// Collection of last less or equal 5 tosses.
        /// </summary>
        private List<int> listOfNumbers;

        /// <summary>
        /// The delegate type for rolling dice.
        /// </summary>
        public delegate void DieTosses();

        /// <summary>
        /// The event that triggered if there is 2 sixes in a row.
        /// </summary>
        public event DieTosses TwoSixesInARow;

        /// <summary>
        /// The delegat type for last 5 tosses.
        /// </summary>
        /// <param name="list">List of 5 numbers</param>
        public delegate void ConsequentFiveTosses(List<int> list);

        /// <summary>
        /// The event that triggered if sum of last 5 numbers is greater or equal 20.
        /// </summary>
        public event ConsequentFiveTosses SumOfConsequentNumbers;

        /// <summary>
        /// The number of times 'two sixes in a row' appear.
        /// </summary>
        private int countOfSixes;

        /// <summary>
        /// Property for countOfSixes that has only getter.
        /// </summary>
        public int CountOfSixes
        {
            get
            {
                return countOfSixes;
            }
        }

        /// <summary>
        /// Random type object to get the value of toss.
        /// </summary>
        Random current;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public RollADie()
        {
            current=new Random();
            countOfSixes = 0;
            listOfNumbers = new List<int> { };
        }

        /// <summary>
        /// Method to roll a die.
        /// </summary>
        public void Roll()
        {
            //Getting random number from 1 to 6.
            int currentNext = current.Next(1, 7);
            //Condition to check if last 2 numbers are sixes or not.
            if(currentNext==6 && listOfNumbers.Count >= 1 && listOfNumbers.Last() == 6)
            {
                countOfSixes++;
                TwoSixesInARow?.Invoke();
            }
            listOfNumbers.Add(currentNext);
            //Condition to check if there are 5 elements already.
            if (listOfNumbers.Count() == 5)
            {
                //Checking if sum of elements greater or equal than 20.
                if (listOfNumbers.Sum() >= 20)
                {
                    SumOfConsequentNumbers?.Invoke(listOfNumbers);
                }
                //Removing first element of the list.
                listOfNumbers.RemoveAt(0);
            }

        }
    }
}
