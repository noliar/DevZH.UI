using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiLabelText")]
        public static extern IntPtr LabelText(ControlHandle label);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiLabelSetText")]
        public static extern void LabelSetText(ControlHandle label, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewLabel")]
        public static extern ControlHandle NewLabel(byte[] text);
    }
}
