using System;
using System.Collections.Generic;
using System.Text;

namespace NTTS.UI.WPF.Messages
{
    public class FrameNavigationMessage
    {
        public string PageName { get; set; }
        public FrameNavigationMessage(string pageName)
        {
            PageName = pageName;
        }

    }
}
