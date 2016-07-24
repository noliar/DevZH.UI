using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class DateTimePicker : Control
    {
        public DateTimePicker()
        {
            ControlHandle = NativeMethods.NewDateTimePicker();
        }
    }

    public class DatePicker : Control
    {
        public DatePicker()
        {
            ControlHandle = NativeMethods.NewDatePicker();
        }
    }

    public class TimePicker : Control
    {
        public TimePicker()
        {
            ControlHandle = NativeMethods.NewTimePicker();
        }
    }
}
