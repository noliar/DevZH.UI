using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFormAppend")]
        public static extern void FormAppend(ControlHandle form, byte[] label, ControlHandle child, bool stretchy);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFormDelete")]
        public static extern void FormDelete(ControlHandle form, int index);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFormPadded")]
        public static extern bool FormPadded(ControlHandle form);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFormSetPadded")]
        public static extern void FormSetPadded(ControlHandle form, bool padded);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewForm")]
        public static extern ControlHandle NewForm();
    }
}
