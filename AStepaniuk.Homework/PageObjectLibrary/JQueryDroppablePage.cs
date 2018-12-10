using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class JQueryDroppablePage : SeleniumActions
    {
        public void DragSmallerBoxToBiggerOne()
        {
            base.SwitchToFrame("xpath=//iframe[@class='demo-frame']");
            base.DragAndDrop("id=draggable", "id=droppable");
        }
    }
}
