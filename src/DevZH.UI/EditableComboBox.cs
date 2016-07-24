using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class EditableComboBox : Control
    {
        private string _text;

        public override string Text
        {
            get
            {
                _text = StringUtil.GetString(NativeMethods.EditableComboBoxText(ControlHandle));
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    NativeMethods.EditableComboBoxSetText(ControlHandle, StringUtil.GetBytes(value));
                    _text = value;
                }
            }
        }

        public EditableComboBox()
        {
            ControlHandle = NativeMethods.NewEditableComboBox();
            InitializeEvents();
        }

        public void Add(params string[] text)
        {
            if (text == null)
            {
                NativeMethods.EditableComboBoxAppend(ControlHandle, StringUtil.GetBytes(null));
            }
            else
            {
                foreach (var s in text)
                {
                    NativeMethods.EditableComboBoxAppend(ControlHandle, StringUtil.GetBytes(s));
                }
            }
        }

        protected void InitializeEvents()
        {
            NativeMethods.EditableComboBoxOnChanged(ControlHandle, (box, data) =>
            {
                OnTextChanged(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
