using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class DateTimePicker : Control
    {
        public enum Types : byte
        {
            DateTimePicker,
            DatePicker,
            TimePicker,
        }

        public DateTimePicker() : this(Types.DateTimePicker)
        {
        }

        protected DateTimePicker(Types types = Types.DateTimePicker)
        {
            switch (types)
            {
                case Types.DateTimePicker:
                    handle = NativeMethods.NewDateTimePicker();
                    break;
                case Types.DatePicker:
                    handle = NativeMethods.NewDatePicker();
                    break;
                case Types.TimePicker:
                    handle = NativeMethods.NewTimePicker();
                    break;
            }
            
        }
    }

    public class DatePicker : DateTimePicker
    {
        public DatePicker() : base(Types.DatePicker)
        {
        }
    }

    public class TimePicker : DateTimePicker
    {
        public TimePicker() : base(Types.DateTimePicker)
        {
        }
    }
}
