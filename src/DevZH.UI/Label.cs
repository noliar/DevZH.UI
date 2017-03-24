using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class Label : Control
    {
        public Label(string text)
        {
            _text = text;
            handle = NativeMethods.NewLabel(StringUtil.GetBytes(text));
        }

        private string _text;
        public string Text
        {
            get
            {
                _text = StringUtil.GetString(NativeMethods.LabelText(handle));
                return _text;
            }
            set
            {
                if (_text != value)
                {
                    NativeMethods.LabelSetText(handle, StringUtil.GetBytes(value));
                    _text = value;
                }
            }
        }
    }
}
