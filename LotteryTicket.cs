using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabulousLotteryApp
{
    public class LotteryTicket
    {
        private User _ticketowner;
        private List<int> _ticketNumbers = new List<int>();
        private Prize _prize = null;
        private string _ticketview;

        /// <summary>
        /// Ticket Owner setters and getters
        /// </summary>
        public User TicketOwner
        {
            get
            {
                return _ticketowner;
            }
            set
            {
                if (_ticketowner != value)
                {
                    _ticketowner = value;
                }
            }
        }

        /// <summary>
        /// Ticket Numbers setters and getters
        /// </summary>
        public List<int> TicketNumbers
        {
            get
            {
                return _ticketNumbers;
            }
            set
            {
                if (value != _ticketNumbers)
                {
                    if (ContainsDuplicates(value))
                    {
                        throw new Exception("Duplicate numbers in ticket!");
                    }
                    if (!AllValidNumbers(value))
                    {
                        throw new Exception("Lottery Numbers are not valid");
                    }
                }
                _ticketNumbers = BubbleSort(value);
                Ticketview = ToString();
            }
        }

        /// <summary>
        /// Generate and store a prize.
        /// Can only be set from inside this class.
        /// </summary>
        public Prize Prize
        {
            get
            {
                return _prize;
            }
            private set
            {
                if (_prize != value)
                {
                    _prize = value;
                }
            }
        }

        public string Ticketview
        {
            get { return _ticketview; }
            private set { _ticketview = value; }
        }

        /// <summary>
        /// Constructor for a Lottery Ticket
        /// </summary>
        /// <param name="user">A pre-registered User</param>
        public LotteryTicket(User owner)
        {
            if (owner != null)
            {
                _ticketowner = owner;
            }
            else
            {
                throw new Exception("User does not exist!");
            }
        }


        /// <summary>
        /// Checks a list for duplicates. 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public bool ContainsDuplicates(List<int> numbers)
        {
            //Check each number and if there is more than one, return true.
            foreach (var number in numbers)
            {
                if (CountOccurences(numbers, number) > 1)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Count Occurences standard algorithm.
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <param name="occurence">Occurence to count as Integer</param>
        /// <returns>Number of occurences found in numbers list.</returns>
        public int CountOccurences(List<int> numbers, int occurence)
        {
            var count = 0;

            for (var i = 0; i < numbers.Count(); i++)
            {
                if (numbers[i] == occurence)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Checks for valid numbers.
        /// </summary>
        /// <param name="numbers">list of numbers to check</param>
        /// <returns>True if all valid numbers, false if invalid.</returns>
        public bool AllValidNumbers(List<int> numbers)
        {
            foreach (var number in numbers)
            {
                if (number < 1 || number > 49)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Ticket will generate a lucky dip.
        /// Numbers are added directly into the draw - no user intervention.
        /// </summary>
        public void LuckyDipGenerator()
        {
            List<int> nums = new List<int>();
            Random rnd = new Random();
            for (var i = 0; i < 6; i++)
            {
                int num;
                do
                {
                    num = rnd.Next(1, 50);
                } while (CountOccurences(nums, num) > 0);

                nums.Add(num);
            }

            //Set TicketNumbers to the nums list and it will sort it.
            TicketNumbers = nums;
            Ticketview = ToString();
        }

        /// <summary>
        /// Standard BubbleSort Algorithm
        /// </summary>
        /// <param name="numbers">List of numbers to be sorted</param>
        /// <returns>Sorted list of numbers.</returns>
        private List<int> BubbleSort(List<int> numbers)
        {
            var n = numbers.Count();
            bool swapped;
            while (true)
            {
                swapped = false;
                for (var i = 0; i < n - 1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        // Swap numbers[j] and numbers[j + 1]
                        var temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                        swapped = true;
                    }
                }

                // If no two elements were swapped in inner loop, the array is already sorted
                if (!swapped)
                    break;
            }

            return numbers;
        }

        /// <summary>
        /// Generate a prize. 
        /// </summary>
        /// <param name="matches">the number of matches</param>
        /// <param name="draw">A string of the winning draw</param>
        /// <exception cref="Exception">Matches not in range</exception>
        public void generatePrize(int matches, string draw)
        {
            if (matches < 0 || matches > 7)
            {
                throw new Exception("Unknown Prize");
            }
            else
            {
                Prize = new Prize(matches, draw);
            }
            Ticketview = ToString();
        }


        /// <summary>
        /// Return a text representation of this ticket with user details and numbers.
        /// Update: If there is a draw taken place, add those details and show winnings.
        /// </summary>
        /// <returns>Return a string representing the ticket.</returns>
        public override string ToString()
        {

            var tempstring = $"Ticket User: {TicketOwner.Name}\nPhone: {TicketOwner.PhoneNumber}  Email: {TicketOwner.Email}\n" +
                             $"Numbers: ";

            foreach (var item in TicketNumbers)
            {
                tempstring += $" {item} ";
            }

            if (Prize != null)
            {
                tempstring += $"\n{Prize.Draw}";
                tempstring += $"\n{Prize.Winnings}";
            }

            return tempstring;
        }


    }
}
