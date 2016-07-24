using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class ProgressBar : Control
    {
        public ProgressBar()
        {
            ControlHandle = NativeMethods.NewProgressBar();
        }

        private int _value;
        public int Value
        {
            get
            {
                _value = NativeMethods.ProgressBarValue(ControlHandle);
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    NativeMethods.ProgressBarSetValue(ControlHandle, value);
                    _value = value;
                }
            }
        }
    }
}
