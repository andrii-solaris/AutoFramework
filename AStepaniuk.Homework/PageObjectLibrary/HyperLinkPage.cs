using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class HyperLinkPage : SeleniumActions
    {
         public void HomePageHover()
        {
            base.Hover("link=Go to Home Page");
        }
    }
}
