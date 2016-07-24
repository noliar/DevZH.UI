using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class TabPage : Control
    {
        public string Name { get; }

        protected Control _child;

        public Control Child
        {
            get { return _child; }
            protected set
            {
                if (_child != value)
                {
                    _child = value;
                    ControlHandle = _child.ControlHandle;
                }
            }
        }

        private bool _beforeAdd = true;
        private bool _allowMargins;
        public bool AllowMargins
        {
            get
            {
                if (Parent != null && !Parent.Verify())
                {
                    _allowMargins = NativeMethods.TabMargined(Parent.ControlHandle, Index);
                    _beforeAdd = false;
                }
                return _allowMargins;
            }
            set
            {
                if (_allowMargins != value)
                {
                    if (Parent != null && !Parent.Verify())
                    {
                        NativeMethods.TabSetMargined(Parent.ControlHandle, Index, value);
                    }
                    _allowMargins = value;
                }
            }
        }

        public TabPage(string name)
        {
            Name = name;
        }

        protected internal override void DelayRender()
        {
            if (_beforeAdd && _allowMargins)
            {
                NativeMethods.TabSetMargined(Parent.ControlHandle, Index, _allowMargins);
            }
        }
    }
}
