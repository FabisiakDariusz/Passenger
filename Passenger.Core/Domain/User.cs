using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Salt { get; protected set; }
        public string Password { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreateAt{ get; protected set; }

        protected User()
        {
        }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            Username = username;
            Password = password;
            Salt = salt;
            CreateAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            Regex emaildRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("E-mail can not by empty");
            }
            else if(!emaildRegex.IsMatch(email))
            {
                throw new Exception("Wrong e-mail");
            }
            else if (Email == email)
            {
                return;
            }

            Email = email;
        }

        public void SetPassword(string password)
        {

            if (Password == password || !ValidatePassword(password))
            {
                return;
            }

            Password = password;
        }

        private bool ValidatePassword(string password)
        {
            var input = password;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                throw new Exception("Password should contain At least one lower case letter");
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                throw new Exception("Password should contain At least one upper case letter");
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                throw new Exception("Password should not be less than 8 or greater 15 characters");
            }
            else if (!hasNumber.IsMatch(input))
            {
                throw new Exception("Password should contain At least one numeric value");
            }

            else if (!hasSymbols.IsMatch(input))
            {
                throw new Exception("Password should contain At least one special case characters");
            }
            else
            {
                return true;
            }
        }

    }
}
