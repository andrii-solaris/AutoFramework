using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class DecorationLoginPage : SeleniumActions
    {
        private UserDataCreator _testData = UserDataCreator.GetCreator();

        public void EnterCredentials()
        {
            base.SetText("id=Email", _testData.Email);
            base.SetText("id=Password", $"*1{ _testData.Password}");
            base.SubmitForm("id=Password");
        }
    }
}
