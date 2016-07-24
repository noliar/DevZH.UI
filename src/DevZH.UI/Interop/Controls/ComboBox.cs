using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiComboboxAppend")]
        public static extern void ComboBoxAppend(ControlHandle comboBox, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiComboboxSelected")]
        public static extern int ComboBoxSelected(ControlHandle comboBox);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiComboboxSetSelected")]
        public static extern void ComboBoxSetSelected(ControlHandle comboBox, int n);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiComboboxOnSelected")]
        public static extern void ComboBoxOnSelected(ControlHandle comboBox, ComboBoxOnSelectedDelegate comboBoxOnSelected, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewCombobox")]
        public static extern ControlHandle NewComboBox();
    }
}
