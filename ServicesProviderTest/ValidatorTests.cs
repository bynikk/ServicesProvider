using NUnit.Framework;
using ServicesProvider.Models.ViewModels;
using ServicesProvider.Service;
using System;
using System.Collections.Generic;

namespace ServicesProviderTest
{

    [TestFixture]
    public class ValidatorTests
    {
        private ValidatorViewModel _validator = new ValidatorViewModel();

        private static IEnumerable<(SignUpViewModel model, bool exceptedResult)> GetSignUpViewModelModels()
        {
            yield return (new SignUpViewModel()
            {
                FirstName = "11111",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "d",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstNameeeeeeeeeeeeeeeeeeeee",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "l",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastNameeeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "email@gmailcom",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "emailgmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "Last4Name",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "375001234444",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+37500-",
                UserName = "UserName",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "UserNameeeeeeeeeeeeeeeeeeeeeeeeeeeeee",
            }, false);
            yield return (new SignUpViewModel()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Email = "email@gmail.com",
                Password = "123qwe",
                PhoneNumber = "+375001234444",
                UserName = "U",
            }, false);
        }

        [TestCaseSource(nameof(GetSignUpViewModelModels))]
        public void SignUpViewModelValidatorFalseTest((SignUpViewModel model, bool exceptedResult) data)
        {
            Assert.AreEqual(data.exceptedResult, _validator.ValidateSignUpViewModel(data.model));
        }

        [Test]
        public void SignUpViewModelValidatorTrueTest()
        {
            SignUpViewModel model = new SignUpViewModel()
             {
                 FirstName = "FirstName",
                 LastName = "LastName",
                 Email = "email@gmail.com",
                 Password = "123qwe",
                 PhoneNumber = "+375001234444",
                 UserName = "UserName1",
             };
            Assert.AreEqual(true, _validator.ValidateSignUpViewModel(model));
        }
        
        [Test]
        public void SignUpViewModelValidatorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _validator.ValidateSignUpViewModel(null));
        }

        private static IEnumerable<(UsersAdViewModel model, bool exceptedResult)> GetUsersAdViewModelModels()
        {
            yield return (new UsersAdViewModel()
            {
                Name = "Name",
                LongDesc = "1",
                ShortDesc = "qwertyuioppqwert",
            }, false);
            yield return (new UsersAdViewModel()
            {
                Name = "Name",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "qwertyuioppqwertqwertyuioppqwertqwertyuioppqwertqwertyuioppqwertqwertyuioppqwert",
            }, false);
            yield return (new UsersAdViewModel()
            {
                Name = "Name",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "1",
            }, false);
            yield return (new UsersAdViewModel()
            {
                Name = "Name",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "qwertyuioppqwert",
            }, false);
            yield return (new UsersAdViewModel()
            {
                Name = "a",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "qwertyuioppqwert",
            }, false);
            yield return (new UsersAdViewModel()
            {
                Name = "NameNameNameNameNameNameNameNameNameName",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "qwertyuioppqwert",
            }, false);
        }

        [TestCaseSource(nameof(GetUsersAdViewModelModels))]
        public void UsersAdViewModelValidatorFalseTest((UsersAdViewModel model, bool exceptedResult) data)
        {
            Assert.AreEqual(data.exceptedResult, _validator.ValidateUsersAdViewModel(data.model));
        }

        [Test]
        public void UsersAdViewModelValidatorNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => _validator.ValidateUsersAdViewModel(null));
        }

        [Test]
        public void UsersAdViewModelValidatorTrueTest()
        {
            UsersAdViewModel model = new UsersAdViewModel()
            {
                Name = "Name",
                LongDesc = "qwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwertqwertyuiopqwert",
                ShortDesc = "qwertyuioppqwert",
            };
            Assert.AreEqual(true, _validator.ValidateUsersAdViewModel(model));
        }
    }
} 