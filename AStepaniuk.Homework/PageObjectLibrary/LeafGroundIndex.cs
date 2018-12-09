using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stepaniuk.Homework.Utils;

namespace Stepaniuk.Homework.PageObjectLibrary
{
    class LeafGroundIndex : SeleniumActions
    {
     public void NewTabClickHyperLink()
        {
            base.NewTabTargetClick("xpath=//h5[text()='HyperLink']/..");
        }                           
    }
}
