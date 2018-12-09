using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class AtataIndexPage : SeleniumActions

    {
        public void ClickSignInButton()
        {
            Log.Information("Navigating to Atata sign-in window...");
            base.Click("id=sign-in");
        }
    }
}
