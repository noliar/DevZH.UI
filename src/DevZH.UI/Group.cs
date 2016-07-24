using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class Group : Control
    {
        public Group(string title)
        {
            ControlHandle = NativeMethods.NewGroup(StringUtil.GetBytes(title));
        }

        public string Title
        {
            get { return StringUtil.GetString(NativeMethods.GroupTitle(ControlHandle)); }
            set { NativeMethods.GroupSetTitle(ControlHandle, StringUtil.GetBytes(value));}
        }

        public bool AllowMargins
        {
            get { return NativeMethods.GroupMargined(ControlHandle); }
            set { NativeMethods.GroupSetMargined(ControlHandle, value);}
        }

        private Control _child;
        public Control Child
        {
            get { return _child; }
            set
            {
                if (_child != value && value.Verify())
                {
                    NativeMethods.GroupSetChild(ControlHandle, value.ControlHandle);
                    _child = value;
                }
            }
        }
    }
}
