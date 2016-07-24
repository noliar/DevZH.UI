using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class MenuItem : Control
    {
        internal MenuItem(ControlHandle handle)
        {
            ControlHandle = handle;
            InitializeEvents();
        }

        public MenuItemTypes Type { get; internal set; }

        private bool _enabled = true;
        public override bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled == value) return;
                if (value)
                {
                    NativeMethods.MenuItemEnable(ControlHandle);
                }
                else
                {
                    NativeMethods.MenuItemDisable(ControlHandle);
                }
                _enabled = value;
            }
        }

        private bool _isChecked;
        public bool IsChecked
        {
            get
            {
                if (this.Type == MenuItemTypes.Check)
                {
                    _isChecked = NativeMethods.MenuItemChecked(ControlHandle);
                }
                return _isChecked;
            }
            set
            {
                if (_isChecked != value && this.Type == MenuItemTypes.Check)
                {
                    NativeMethods.MenuItemSetChecked(ControlHandle, value);
                    _isChecked = value;
                }
            }
        }

        public void InitializeEvents()
        {
            NativeMethods.MenuItemOnClicked(ControlHandle, (item, window, data) =>
            {
                OnClick(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
