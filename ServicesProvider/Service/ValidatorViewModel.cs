using ServicesProvider.Models;
using ServicesProvider.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesProvider.Service
{
    public class ValidatorViewModel
    {
        // ValidateSignUpViewModel constant
        string UserNameValidRegx = @"^[\p{L}\p{N}]+$";
        private readonly int maxUserNameLength = 20;
        private readonly int minUserNameLength = 3;

        string FirstNameValidRegx = @"^[A-Za-z]+$";
        private readonly int maxFirstNameLegth = 20;
        private readonly int minFirstNameLength = 2;

        string LastNameValidRegx = @"^[A-Za-z]+$";
        private readonly int maxLastNameLength = 20;
        private readonly int minLastNameLength = 2;

        string PhoneValidRegx = @"^\+?(\d[\d -. ]+)?(\([\d -. ]+\))?[\d-. ]+\d$";
        private readonly int minPhoneLength = 6;
        private readonly int maxPhoneLength = 20;

        string EmailValidRegx = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
        private readonly int minEmailLength = 5;
        private readonly int maxEmailLength = 35;

        private readonly int minPasswordLength = 6;
        private readonly int maxPasswordLength = 20;

        // ValidateUsersAdViewModel constant

        private readonly int minNameLength = 4;
        private readonly int maxNameLength = 12;

        private readonly int minShortDescLength = 15;
        private readonly int maxShortDescLength = 30;

        private readonly int minLongDescLength = 30;
        private readonly int maxLongDescLength = 250;

        //public string Img { set; get; }

        public bool ValidateSignUpViewModel(SignUpViewModel model)
        {
            bool res = true;

            if (model == null)
            {
                throw new ArgumentNullException();
            }

            // UserName validation
            else if (model.UserName.Length < minUserNameLength || model.UserName.Length > maxUserNameLength)
            {
                res = false;
            }

            else if (!Regex.IsMatch(model.UserName, UserNameValidRegx))
            {
                res = false;
            }

            // First Name validation
            else if (model.FirstName.Length < minFirstNameLength || model.FirstName.Length > maxFirstNameLegth)
            {
                res = false;
            }

            else if (!Regex.IsMatch(model.FirstName, FirstNameValidRegx))
            {
                res = false;
            }

            // Last Name validation
            else if (model.LastName.Length < minLastNameLength || model.LastName.Length > maxLastNameLength)
            {
                res = false;
            }

            else if (!Regex.IsMatch(model.LastName, LastNameValidRegx))
            {
                res = false;
            }

            // Phone number validation
            else if (model.PhoneNumber.Length < minPhoneLength || model.PhoneNumber.Length > maxPhoneLength)
            {
                res = false;
            }

            else if (!Regex.IsMatch(model.PhoneNumber, PhoneValidRegx))
            {
                res = false;
            }

            // Email validation
            else if (model.Email.Length < minEmailLength || model.Email.Length > maxEmailLength)
            {
                res = false;
            }

            else if (!Regex.IsMatch(model.Email, EmailValidRegx))
            {
                res = false;
            }

            // Password validation
            else if (model.Password.Length < minPasswordLength || model.Password.Length > maxPasswordLength)
            {
                res = false;
            }

            return res;
        }

        public bool ValidateUsersAdViewModel(UsersAdViewModel model)
        {
            bool res = true;
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            // Name validation
            else if (model.Name.Length < minNameLength || model.Name.Length > maxNameLength)
            {
                res = false;
            }

            // ShortDesc validation
            else if (model.ShortDesc.Length < minShortDescLength || model.ShortDesc.Length > maxShortDescLength)
            {
                res = false;
            }

            // LongDesc validation
            else if (model.LongDesc.Length < minLongDescLength || model.LongDesc.Length > maxLongDescLength)
            {
                res = false;
            }

            return res;
        }
    }
}
