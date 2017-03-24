using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Events;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public abstract class EntryBase : Control
    {
        protected EntryBase(Entry.Types type)
        {
            switch (type)
            {
                case Entry.Types.Basic:
                    handle = NativeMethods.NewEntry();
                    break;
                case Entry.Types.Password:
                    handle = NativeMethods.NewPasswordEntry();
                    break;
                case Entry.Types.Search:
                    handle = NativeMethods.NewSearchEntry();
                    break;
            }
            InitializeEvents();
        }

        public virtual string Text
        {
            get { return StringUtil.GetString(NativeMethods.EntryText(handle)); }
            set { NativeMethods.EntrySetText(handle, StringUtil.GetBytes(value));}
        }

        private bool _readonly;
        public bool IsReadOnly
        {
            get
            {
                _readonly = NativeMethods.EntryReadOnly(handle);
                return _readonly;
            }
            set
            {
                if (_readonly != value)
                {
                    NativeMethods.EntrySetReadOnly(handle, value);
                }
            }
        }

        protected sealed override void InitializeEvents()
        {
            NativeMethods.EntryOnChanged(handle, (entry, data) =>
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
