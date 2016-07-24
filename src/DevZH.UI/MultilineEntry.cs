using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class MultilineEntry : Control
    {
        public bool IsWrapping { get; }

        private string _text;
        public override string Text
        {
            get
            {
                _text = StringUtil.GetString(NativeMethods.MultilineEntryText(ControlHandle));
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    NativeMethods.MultilineEntrySetText(ControlHandle, StringUtil.GetBytes(value));
                    _text = value;
                }
            }
        }

        private bool _isReadOnly;
        public bool IsReadOnly
        {
            get
            {
                _isReadOnly = NativeMethods.MultilineEntryReadOnly(ControlHandle);
                return _isReadOnly;
            }
            set
            {
                if (_isReadOnly != value)
                {
                    NativeMethods.MultilineEntrySetReadOnly(ControlHandle, value);
                    _isReadOnly = value;
                }
            }
        }

        public MultilineEntry(bool isWrapping = true)
        {
            IsWrapping = isWrapping;
            if (isWrapping)
            {
                ControlHandle = NativeMethods.NewMultilineEntry();
            }
            else
            {
                ControlHandle = NativeMethods.NewNonWrappingMultilineEntry();
            }
        }

        public void Append(string append)
        {
            if (!string.IsNullOrEmpty(append))
            {
                NativeMethods.MultilineEntryAppend(ControlHandle, StringUtil.GetBytes(append));
            }
        }
    }
}
