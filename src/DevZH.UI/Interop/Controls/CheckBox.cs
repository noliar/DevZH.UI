using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiCheckboxText")]
        public static extern IntPtr CheckBoxText(ControlHandle checkBox);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiCheckboxSetText")]
        public static extern void CheckBoxSetText(ControlHandle checkBox, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiCheckboxOnToggled")]
        public static extern void CheckBoxOnToggled(ControlHandle checkBox, CheckBoxOnToggledDelegate checkBoxOnToggled, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiCheckboxChecked")]
        public static extern bool CheckBoxChecked(ControlHandle checkBox);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiCheckboxSetChecked")]
        public static extern void CheckBoxSetChecked(ControlHandle checkBox, bool check);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewCheckbox")]
        public static extern ControlHandle NewCheckBox(byte[] text);
    }
}
