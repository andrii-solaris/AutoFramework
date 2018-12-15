using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class UnsplashTestPage : SeleniumActions
    {
        public void ScrollToElement()
        {
            base.FluentScroll("xpath=//img[@alt='cactus succulent plant on white vase']");
        }

        public void DownloadLastPicture()
        {
            base.Hover("xpath=//img[@alt='cactus succulent plant on white vase']");
            base.Click("xpath=//img[@alt='cactus succulent plant on white vase']/ancestor::a/following-sibling::div/div[3]/div[2]/a");
        }
    }
}
