using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntryText")]
        public static extern IntPtr MultilineEntryText(ControlHandle entry);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntrySetText")]
        public static extern void MultilineEntrySetText(ControlHandle entry, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntryAppend")]
        public static extern void MultilineEntryAppend(ControlHandle entry, byte[] text);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntryOnChanged")]
        public static extern void MultilineEntryOnChanged(ControlHandle entry, MultilineEntryOnChangedDelegate multilineEntryOnChanged, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntryReadOnly")]
        public static extern bool MultilineEntryReadOnly(ControlHandle entry);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMultilineEntrySetReadOnly")]
        public static extern void MultilineEntrySetReadOnly(ControlHandle entry, bool isReadOnly);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewMultilineEntry")]
        public static extern ControlHandle NewMultilineEntry();

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewNonWrappingMultilineEntry")]
        public static extern ControlHandle NewNonWrappingMultilineEntry();
    }
}
