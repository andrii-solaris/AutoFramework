using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class DecorationRegisterPage : SeleniumActions
    {

        private UserDataCreator _testData = UserDataCreator.GetCreator(); 

        public void PopulateRegisterForm()
        {
            base.SetText("id=Email", _testData.Email);
            base.SetText("id=Name", _testData.FirstName);
            base.SetText("id=Surname", _testData.SecondName);
            base.SetText("id=Company", _testData.Company);
            base.SetText("id=Password", $"*1{ _testData.Password}");
            base.SetText("id=ConfirmPassword", $"*1{ _testData.Password}");
            base.SubmitForm("id=ConfirmPassword");
        }
    }
}
