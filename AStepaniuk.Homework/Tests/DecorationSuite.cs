using NUnit.Framework;
using Stepaniuk.Homework.Utils;
using Stepaniuk.Homework.PageObjectLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Stepaniuk.Homework.Tests
{
    [TestFixture]
    class DecorationSuite : SeleniumActions
    {
        [Test]
        [Order(1)]
        public void RegisterAndValidateUser()
        {
            var decorationIndex = new DecorationIndex();
            var testData = UserDataCreator.GetCreator();

            base.GoToPage("https://homeworkdecoration20181213051012.azurewebsites.net/");
            base.GetCurrentUrl().Should().Match("https://homeworkdecoration20181213051012.azurewebsites.net/");
            decorationIndex.ClickRegisterLink();            
            new DecorationRegisterPage().PopulateRegisterForm();
            decorationIndex.ClickUserDetails();            
            base.ValidateText("id=userName", testData.FirstName);
            base.ValidateText("id=userSurname", testData.SecondName);
            base.ValidateText("id=UserCompany", testData.Company);
            base.ValidateText("id=userEmail", testData.Email);
            decorationIndex.ClickLogout();
            base.GetCurrentUrl().Should().Match("https://homeworkdecoration20181213051012.azurewebsites.net/");
        }

        [Test]
        [Order(2)]
        public void LoginWithValidCredentials()
        {           
            var testData = UserDataCreator.GetCreator();

            new DecorationIndex().ClickLogin();            
            new DecorationLoginPage().EnterCredentials();
            base.ValidateText("xpath=//form[@id='logoutForm']/ul/li[1]/a", testData.Email);

        }
    }
}
