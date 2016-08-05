using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Events;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class MenuItem : Control
    {
        internal MenuItem(ControlHandle handle, MenuItemTypes type)
        {
            ControlHandle = handle;
            Type = type;
            InitializeEvents();
        }

        public MenuItemTypes Type { get; }

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
            switch (Type)
            {
                case MenuItemTypes.Quit:
                    break;
                default:
                    NativeMethods.MenuItemOnClicked(ControlHandle, (item, window, data) =>
                    {
                        OnClick(new DataEventArgs(window));
                    }, IntPtr.Zero);
                    break;
            }
        }
    }
}
