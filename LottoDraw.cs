using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabulousLotteryApp
{

    /// <summary>
    /// Draw the lottery numbers and bonus ball.
    /// Use these numbers to check tickets.
    /// </summary>
    public class LottoDraw
    {
        private List<int> _drawNumbers = new List<int>();
        private int _bonusBall = 0;

        public List<int> DrawNumbers
        {
            get
            {
                return _drawNumbers;
            }
            private set
            {
                _drawNumbers = value;
            }
        }

        public int BonusBall
        {
            get
            {
                return _bonusBall;
            }
            private set
            {
                _bonusBall = value;
            }

        }

        /// <summary>
        /// Constructor for Lotto Draw. No parameters, Perform Lotto Draw
        /// </summary>
        public LottoDraw()
        {
            PerformLotteryDraw();
        }

        /// <summary>
        /// Perform the Lottery draw.
        /// Populate DrawNumbers with 6 random numbers.
        /// Populate bonus ball with number.
        /// all numbers should be unique.
        /// </summary>
        private void PerformLotteryDraw()
        {
            Random rnd = new Random();
            int ball;

            //Lottery Draw
            for (var i = 0; i < 6; i++)
            {
                do
                {
                    ball = rnd.Next(1, 50);
                } while (DrawNumbers.Contains(ball));
                DrawNumbers.Add(ball);
            }

            DrawNumbers = BubbleSort(DrawNumbers);

            //Bonus Ball
            do
            {
                ball = rnd.Next(1, 50);
            } while (DrawNumbers.Contains(ball));
            BonusBall = ball;
        }

        public override string ToString()
        {
            var tempstring = $"Lotto Draw Numbers Are: ";

            foreach (var item in DrawNumbers)
            {
                tempstring += $" ({item}) ";
            }

            tempstring += $" Bonus: {BonusBall}";

            return tempstring;

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
        /// Check Matches from a lottery ticket.
        /// </summary>
        /// <param name="ticket">a Lottery ticket object</param>
        /// <returns>the number of matches 0-6 or 7 if matches 5+bonus</returns>
        public int CheckMatches(LotteryTicket ticket)
        {
            int matchedNumbers = 0;

            foreach (var ballnumber in ticket.TicketNumbers)
            {
                if (DrawNumbers.Contains(ballnumber))
                {
                    matchedNumbers++;
                }
            }

            //IF there are 5 correct numbers, check the bonus ball.
            if (matchedNumbers == 5)
            {
                if (ticket.TicketNumbers.Contains(BonusBall))
                {
                    return 7; // ticket matches 5 + bonus.
                }
            }

            return matchedNumbers;

        }

    }
}