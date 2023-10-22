using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabulousLotteryApp
{

    /// <summary>
    /// Game Controller. 
    /// </summary>
    public class PlayGame
    {
        public ObservableCollection<User> UsersList = new ObservableCollection<User>();
		public ObservableCollection<LotteryTicket> TicketList = new ObservableCollection<LotteryTicket>();
        public LottoDraw draw = null;


        /// <summary>
        /// Create a new player from the User Interface passing in name, phone and e-mail.
        /// </summary>
        /// <param name="name">String of user's name</param>
        /// <param name="phone">String of user's phone number</param>
        /// <param name="email">String of user's email address</param>
        /// <exception cref="Exception">Exception if validation fails.</exception>
        public void NewPlayer(string name, string phone, string email)
        {
            if (draw != null)
            {
                // Draw has taken place, no more users.
                throw new Exception("Draw has already taken place!");
            }

            try
            {
                User usr = new User(name, email, phone);
                UsersList.Add(usr);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);   //Caught an exception, throw it back to UI
            }
        }

        /// <summary>
        /// Polymorphic New Ticket for tickets from a usr who chose their numbers on the UI
        /// </summary>
        /// <param name="usr">USER from a drop down list</param>
        /// <param name="ball1">ball1 as integer</param>
        /// <param name="ball2">ball2 as integer</param>
        /// <param name="ball3">ball3 as integer</param>
        /// <param name="ball4">ball4 as integer</param>
        /// <param name="ball5">ball5 as integer</param>
        /// <param name="ball6">ball6 as integer</param>
        /// <returns>Returns a string of the ticket to send to UI</returns>
        /// <exception cref="Exception">Exception when validation fails.</exception>
        public string NewTicket(User usr, int ball1, int ball2, int ball3, int ball4, int ball5, int ball6)
        {
            if (draw != null)
            {
                // Draw has taken place, no more users.
                throw new Exception("Draw has already taken place!");
            }

            try
            {
                List<int> balls = new List<int> { ball1, ball2, ball3, ball4, ball5, ball6 };
                LotteryTicket ticket = new LotteryTicket(usr);
                ticket.TicketNumbers = balls;
                TicketList.Add(ticket);
                return ticket.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); // throw this exception back to the UI
            }
        }

        /// <summary>
        /// Polymorphic NewTicket
        /// Create a new Lottery Ticket for a user (selected from a drop-down list)
        /// user has selected a lucky dip instead of picking own numbers
        /// </summary>
        /// <param name="usr">USER from drop down list</param>
        /// <param name="luckyDip">True if luckydip</param>
        /// <returns>String of ticket to send to UI</returns>
        /// <exception cref="Exception">Exception when validation fails.</exception>
        public string NewTicket(User usr, bool luckyDip)
        {
            if (draw != null)
            {
                // Draw has taken place, no more users.
                throw new Exception("Draw has already taken place!");
            }

            try
            {
                LotteryTicket ticket = new LotteryTicket(usr);
                ticket.LuckyDipGenerator();
                TicketList.Add(ticket);
                return ticket.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); // throw this exception back to the UI
            }
        }

        /// <summary>
        /// Run the draw.  
        /// Create a new lottery draw
        /// and for each ticket, check winning numbers and generate prize.
        /// </summary>
        /// <exception cref="Exception">Exception if called when draw already exists.</exception>
        public void RunDraw()
        {
            if (draw != null)
            {
                // Draw has taken place, no more users.
                throw new Exception("Draw has already taken place!");
            }

            draw = new LottoDraw();

            // For each ticket in the list, check the numbers and generate a prize.
            foreach (LotteryTicket ticket in TicketList)
            {
                try
                {
                    var matches = draw.CheckMatches(ticket);
                    ticket.generatePrize(matches, draw.ToString());
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message); //Errors get thrown back to the UI
                }
            }
        }
    }
}