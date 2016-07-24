using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class RadioButtonList : Control
    {
        public event EventHandler Selected;

        private int _selectedIndex;
        public int SelectedIndex
        {
            get
            {
                _selectedIndex = NativeMethods.RadioButtonSelected(ControlHandle);
                return _selectedIndex;
            }
            set
            {
                if (_selectedIndex != value)
                {
                    NativeMethods.RadioButtonSetSelected(ControlHandle, value);
                    _selectedIndex = value;
                }
            }
        }

        public RadioButtonList()
        {
            ControlHandle = NativeMethods.NewRadioButton();
            InitializeEvents();
        }

        public void Add(params string[] rbText)
        {
            if (rbText == null)
            {
                NativeMethods.RadioButtonAppend(ControlHandle, StringUtil.GetBytes(null));
            }
            else
            {
                foreach (var text in rbText)
                {
                    NativeMethods.RadioButtonAppend(ControlHandle, StringUtil.GetBytes(text));
                }
            }
        }

        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        protected void InitializeEvents()
        {
            NativeMethods.RadioButtonOnSelected(ControlHandle, (btn, data) =>
            {
                OnSelected(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
