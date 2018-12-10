using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class JQueryIndexPage : SeleniumActions
    {
        public void ClickDroppableLink()
        {
            base.Click("link=Droppable");
        }
    }
}
