using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class ComboBox : Control
    {
        public event EventHandler Selected;

        public ComboBox()
        {
            ControlHandle = NativeMethods.NewComboBox();
            InitializeEvents();
        }

        public void Add(params string[] text)
        {
            if (text == null)
            {
                NativeMethods.ComboBoxAppend(ControlHandle, StringUtil.GetBytes(null));
            }
            else
            {
                foreach (var s in text)
                {
                    NativeMethods.ComboBoxAppend(ControlHandle, StringUtil.GetBytes(s));
                }
            }
        }

        private int _index;
        public int SelectedIndex
        {
            get
            {
                _index = NativeMethods.ComboBoxSelected(ControlHandle);
                return _index;
            }
            set
            {
                if (_index != value)
                {
                    NativeMethods.ComboBoxSetSelected(ControlHandle, value);
                    _index = value;
                }
            }
        }

        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }

        protected void InitializeEvents()
        {
            NativeMethods.ComboBoxOnSelected(ControlHandle, (box, data) =>
            {
                OnSelected(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
