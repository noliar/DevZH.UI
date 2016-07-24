using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiRadioButtonsAppend")]
        public static extern void RadioButtonAppend(ControlHandle radioButton, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiRadioButtonsSelected")]
        public static extern int RadioButtonSelected(ControlHandle radioButton);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiRadioButtonsSetSelected")]
        public static extern void RadioButtonSetSelected(ControlHandle radioButton, int index);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiRadioButtonsOnSelected")]
        public static extern void RadioButtonOnSelected(ControlHandle radioButton, RadioButtonOnSelectedDelegate radioButtonOnSelected, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewRadioButtons")]
        public static extern ControlHandle NewRadioButton();
    }
}
