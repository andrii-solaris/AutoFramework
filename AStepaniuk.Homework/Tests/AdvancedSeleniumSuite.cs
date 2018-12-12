using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Stepaniuk.Homework.Utils;
using Stepaniuk.Homework.PageObjectLibrary;
using Serilog;
using NUnit.Framework.Interfaces;
using System.Threading;
using System.IO;

namespace Stepaniuk.Homework.Tests
{
    [TestFixture]
    [Author("astepaniuk")]
    class AdvancedSeleniumSuite : SeleniumActions
    {

        [SetUp] 
        public void ClearDownloadsDirectory()
        {
            if (Directory.Exists($@"{Constants.CurrentDirectory}\Downloads")) 
                {
                    Directory.Delete($@"{Constants.CurrentDirectory}\Downloads", true);
                }            
        }

        [Test]
        [Order(1)]
        public void LeafgroundTest()
        {
            base.GoToPage("http://www.leafground.com/home.html");
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("http://www.leafground.com/home.html"));
            new LeafGroundIndex().NewTabClickHyperLink();
            base.SwitchToWindow(1);
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("http://www.leafground.com/pages/Link.html"));
            new HyperLinkPage().HomePageHover();
            base.TakeScreenshot();
            base.CloseCurrentWindow();
            base.SwitchToWindow(0);                       
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("http://www.leafground.com/home.html"));            
        }

        [Test]
        [Order(2)]
        public void DragAndDropTest()
        {
            base.GoToPage("https://jqueryui.com/demos/");
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("https://jqueryui.com/demos/"));
            new JQueryIndexPage().ClickDroppableLink();
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("https://jqueryui.com/droppable/"));
            new JQueryDroppablePage().DragSmallerBoxToBiggerOne();
            base.ValidateText("xpath=//div[@id='droppable']/p", "Dropped!");
        }

        [Test]
        [Order(3)]
        public void ScrollToLastPicture()
        {
            base.GoToPage("https://unsplash.com/search/photos/test");
            Assert.That(base.GetCurrentUrl(), Is.EqualTo("https://unsplash.com/search/photos/test"));
            new UnsplashTestPage().ScrollToElement();            
            new UnsplashTestPage().DownloadLastPicture();
            Thread.Sleep(4000);
            Assert.That(Directory.GetFiles($@"{Constants.CurrentDirectory}\Downloads", "the-roaming-platypus-529026-unsplash.jpg"), Is.Not.Empty);

        }

        public void TearDown()
        {

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Log.Debug($"Test failed! Stack trace of an error is {stackTrace}{errorMessage}");

            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                Log.Debug("Test passed!");
                var unsplashPage = new UnsplashTestPage();
                unsplashPage.ScrollToElement();
                unsplashPage.DownloadLastPicture();
            }            
        }
    }
}
