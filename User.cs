using System;
using System.Linq;
using System.Xml.Linq;

namespace FabulousLotteryApp
{
    public class User
    {
        private string _name = null;
        private string _email = null;
        private string _phoneNumber = null;

        /// <summary>
        /// Setters and Getters for Name
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                // if the name is the same, ignore it!
                if (_name != value)
                {
                    if (!IsValidName(value))
                    {
                        throw new Exception("Name is not valid!");
                    }
                    else
                    {
                        _name = value;
                    }
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    if (!IsValidEmail(value))
                    {
                        throw new Exception("Email is not valid!");
                    }
                    else
                    {
                        _email = value;
                    }
                }
            }
        }

        /// <summary>
        /// Getters and Setters for Phone Number
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (!IsValidPhone(value))
                {
                    throw new Exception("Phone Number is invalid");
                }
                else
                {
                    if (value != _phoneNumber)
                        _phoneNumber = value;
                }
            }
        }

        /// <summary>
        /// Constructor for User.
        /// </summary>
        /// <param name="name">String Name</param>
        /// <param name="email">String E-mail</param>
        /// <param name="pnumber">String Phone Number</param>
        public User(string name, string email, string pnumber)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = pnumber;
        }


        /// <summary>
        /// Checks if a name is valid, it is not blank, and doesn't contain digits. 
        /// </summary>
        /// <param name="name">String of a user's name.</param>
        /// <returns>True if valid, False if invalid.</returns>
        private bool IsValidName(string name)
        {
            if (name == null)
                return false;
            if (name.Length == 0)
                return false;
            if (name.Any(char.IsDigit))
                return false;

            return true;
        }

        /// <summary>
        /// Check if the e-mail is valid. 
        /// must be not null, be length > 0, no white space, and contain an @
        /// </summary>
        /// <param name="email">e-mail address as string</param>
        /// <returns>True if valid, false if not.</returns>
        private bool IsValidEmail(string email)
        {
            if (email == null)
                return false;
            if (email.Length == 0)
                return false;
            if (email.Any(char.IsWhiteSpace))
                return false;
            if (!email.Contains('@'))
                return false;

            return true;
        }

        /// <summary>
        /// Check if phone number is valid.
        /// Only checking if not null, and length is greater than 0. 
        /// May check for digits in specific format but leave for now.
        /// </summary>
        /// <param name="phone">phone number as string</param>
        /// <returns>true if valid, false if invalid.</returns>
        private bool IsValidPhone(string phone)
        {
            if (phone == null)
                return false;
            if (phone.Length == 0)
                return false;
            return true;
        }

    }
}