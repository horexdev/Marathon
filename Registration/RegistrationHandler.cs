using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using Marafon.Database;

namespace Marafon.Registration
{
    public class RegistrationHandler
    {
        public void RegisterUser(string email, string password, string firstName, string lastName,
            string roleAbbreviation, byte[] binaryAvatar)
        {
            using (var context = new marathonEntities())
            {
                var user = new users
                {
                    Email = email,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Avatar = binaryAvatar,
                    RoleId = roleAbbreviation
                };

                context.users.Add(user);
                context.SaveChanges();
            }
        }

        public void RegisterRunner(string email, string gender, DateTime dateOfBirth, string countryCode)
        {
            using (var context = new marathonEntities())
            {
                var runner = new runner
                {
                    Email = email.Trim(' '),
                    Gender = gender,
                    DateOfBirth = new DateTime?(),
                    CountryCode = countryCode
                };

                context.runner.Add(runner);
                context.SaveChanges();
            }
        }

        public bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            try
            {
                var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                var addr = new MailAddress(email);

                return addr.Address == email && regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            if (password.Length < 6)
                return false;

            var isDigit = false;
            var isLetter = false;
            var isSymbol = false;

            foreach (var ch in password)
            {
                if (char.IsDigit(ch) && !isDigit)
                    isDigit = true;
                if (char.IsLetter(ch) && !isLetter)
                    isLetter = true;
                if (char.IsSymbol(ch) && !isSymbol)
                    isSymbol = true;
            }

            return isDigit && isLetter && isSymbol;
        }
    }
}