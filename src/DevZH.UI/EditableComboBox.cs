using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Events;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class EditableComboBox : Control
    {
        private string _text;

        public virtual string Text
        {
            get
            {
                _text = StringUtil.GetString(NativeMethods.EditableComboBoxText(handle));
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    NativeMethods.EditableComboBoxSetText(handle, StringUtil.GetBytes(value));
                    _text = value;
                }
            }
        }

        public EditableComboBox()
        {
            handle = NativeMethods.NewEditableComboBox();
            InitializeEvents();
        }

        public void Add(params string[] text)
        {
            if (text == null)
            {
                NativeMethods.EditableComboBoxAppend(handle, StringUtil.GetBytes(null));
            }
            else
            {
                foreach (var s in text)
                {
                    NativeMethods.EditableComboBoxAppend(handle, StringUtil.GetBytes(s));
                }
            }
        }

        protected sealed override void InitializeEvents()
        {
            NativeMethods.EditableComboBoxOnChanged(handle, (box, data) =>
            {
                OnTextChanged(EventArgs.Empty);
            }, IntPtr.Zero);
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;
        protected virtual void OnTextChanged(EventArgs e)
        {
            var text = this.Text;
            TextChanged?.Invoke(this, new TextChangedEventArgs { Text = text });
        }
    }
}
