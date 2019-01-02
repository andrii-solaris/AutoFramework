using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class DecorationIndex : SeleniumActions
    {
        public void ClickRegisterLink()
        {
            base.Click("link=Register");
        }

        public void ClickUserDetails()
        {
            base.Click("xpath=//form[@id='logoutForm']/ul/li[1]/a");
        }

        public void ClickLogout()
        {
            base.Click("xpath=//form[@id='logoutForm']/ul/li[2]/a");
        }

        public void ClickLogin()
        {
            base.Click("id=loginLink");
        }
    }
}
