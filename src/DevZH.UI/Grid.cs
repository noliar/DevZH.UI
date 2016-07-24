using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class Grid : ContainerControl, IContainerControl<GridItemCollection, Grid>
    {
        public Grid()
        {
            ControlHandle = NativeMethods.NewGrid();
        }

        private bool _allowPadding;
        public bool AllowPadding
        {
            get
            {
                _allowPadding = NativeMethods.GridPadded(ControlHandle);
                return _allowPadding;
            }
            set
            {
                if (_allowPadding != value)
                {
                    NativeMethods.GridSetPadded(ControlHandle, value);
                    _allowPadding = value;
                }
            }
        }

        private GridItemCollection _children;

        public GridItemCollection Children
        {
            get
            {
                if (_children == null)
                {
                    _children = new GridItemCollection(this);
                }
                return _children;
            }
        }
    }

    public class GridItemCollection : ControlCollection<Grid>
    {
        public GridItemCollection(Grid uiParent) : base(uiParent)
        {
        }

        public override void Add(Control item)
        {
            Add(item, 0, 0, 0, 0, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
        }

        public virtual void Add(Control item, int left, int top, int xspan, int yspan, int hexpand,
            HorizontalAlignment halign, int vexpand, VerticalAlignment valign)
        {
            if (this.Contains(item))
            {
                throw new InvalidOperationException("cannot add the same control.");
            }
            if (item == null) return;
            NativeMethods.GridAppend(Owner.ControlHandle, item.ControlHandle, left, top, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Add(item);
        }

        private new void Insert(int index, Control item)
        {
            
        }

        public virtual void Insert(Control item, Control existui,GridEdge at, int xspan, int yspan, int hexpand, HorizontalAlignment halign, int vexpand, VerticalAlignment valign)
        {
            NativeMethods.GridInsertAt(Owner.ControlHandle, item.ControlHandle, existui.ControlHandle, at, xspan, yspan, hexpand, halign, vexpand, valign);
            base.Insert(existui.Index, item);
        }
    }
}
