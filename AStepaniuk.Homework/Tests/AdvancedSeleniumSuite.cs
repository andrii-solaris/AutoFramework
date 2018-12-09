using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Stepaniuk.Homework.Utils;
using Stepaniuk.Homework.PageObjectLibrary;

namespace Stepaniuk.Homework.Tests
{
    [TestFixture]
    [Author("astepaniuk")]
    class AdvancedSeleniumSuite : SeleniumActions
    {
        [SetUp, Sequential]
        public void SetUp([Values("http://www.leafground.com/home.html", "https://jqueryui.com/demos/")] string baseUrl)
        {
            base.GoToPage(baseUrl);            
        }

        [Test]
        [Order(1)]
        public void LeafgroundTest()
        {
            new LeafGroundIndex().NewTabClickHyperLink();
            new HyperLinkPage().HomePageHover();
            base.TakeScreenshot();
            base.SwitchToWindow(1);
            base.CloseCurrentWindow();
            base.SwitchToDefaultWindow();
        }
    }
}
