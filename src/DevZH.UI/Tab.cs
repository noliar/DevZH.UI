using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class Tab : ContainerControl, IContainerControl<Tab.TabPageCollection, Tab>
    {
        public class TabPageCollection : ControlCollection<Tab>
        {
            public TabPageCollection(Tab uiParent) : base(uiParent)
            {
            }

            public override void Add(Control child)
            {
                var page = child as TabPage;
                if (page == null)
                {
                    throw new ArgumentException("cannot only attach TabPage to Tab");
                }
                base.Add(child);
                NativeMethods.TabAppend(Owner.ControlHandle, StringUtil.GetBytes(page.Name), child.ControlHandle);
                child.DelayRender();
            }

            public override void Insert(int i, Control child)
            {
                var page = child as TabPage;
                if (page == null)
                {
                    throw new ArgumentException("cannot only attach TabPage to Tab");
                }
                base.Insert(i, child);
                NativeMethods.TabInsertAt(Owner.ControlHandle, StringUtil.GetBytes(page.Name), i, child.ControlHandle);
                child.DelayRender();
            }

            public override bool Remove(Control item)
            {
                NativeMethods.TabDelete(Owner.ControlHandle, item.Index);
                return base.Remove(item);
            }
        }

        private TabPageCollection _tab;
        public TabPageCollection Children
        {
            get
            {
                if (_tab == null)
                {
                    _tab = new TabPageCollection(this);
                }
                return _tab;
            }
        }

        public Tab()
        {
            ControlHandle = NativeMethods.NewTab();
        }
    }
}
