using System;

namespace FabulousLotteryApp
{

    //Class containing prize details.

    public class Prize
    {
        private int _matches;
        private string _draw;
        private string _winnings;

        public int Matches
        {
            get
            {
                return _matches;
            }
            private set
            {
                _matches = value;
            }
        }

        public string Winnings
        {
            get
            {
                return _winnings;
            }
            private set
            {
                _winnings = value;
            }
        }

        public string Draw
        {
            get
            {
                return _draw;
            }
            private set
            {
                _draw = value;
            }
        }

        /// <summary>
        /// Generate a prise from the MatchedNumbers and a string of the current draw
        /// </summary>
        /// <param name="matchedNumbers">Integer representing how many numbers were matched</param>
        /// <param name="draw">String of the draw that took place to add to the ticket.</param>
        /// <exception cref="Exception">Exception when validation fails.</exception>
        public Prize(int matchedNumbers, string draw)
        {
            Matches = matchedNumbers;
            Draw = draw;

            switch (matchedNumbers)
            {
                case 0:
                    Winnings = "No Win!";
                    break;
                case 1:
                    Winnings = "Match 1: Free Ticket!";
                    break;
                case 2:
                    Winnings = "Match 2: Free Ticket!";
                    break;
                case 3:
                    Winnings = "Match 3: Win $10";
                    break;
                case 4:
                    Winnings = "Match 4: Win $100";
                    break;
                case 5:
                    Winnings = "Match 5: Win $1000";
                    break;
                case 6:
                    Winnings = "JACKPOT: WIN $1,000,000";
                    break;
                case 7:
                    Winnings = "Match 5 + Bonus : Win $10,000";
                    break;
                default:
                    throw new Exception("Unknown Win!");
            }
        }
    }
}
