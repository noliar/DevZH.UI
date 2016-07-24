using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public abstract class EntryBase : Control
    {
        protected EntryBase()
        {
            
        }

        public override string Text
        {
            get { return StringUtil.GetString(NativeMethods.EntryText(ControlHandle)); }
            set { NativeMethods.EntrySetText(ControlHandle, StringUtil.GetBytes(value));}
        }

        private bool _readonly;
        public bool IsReadOnly
        {
            get
            {
                _readonly = NativeMethods.EntryReadOnly(ControlHandle);
                return _readonly;
            }
            set
            {
                if (_readonly != value)
                {
                    NativeMethods.EntrySetReadOnly(ControlHandle, value);
                }
            }
        }

        protected void InitializeEvents()
        {
            NativeMethods.EntryOnChanged(ControlHandle, (entry, data) =>
            {
                OnTextChanged(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
