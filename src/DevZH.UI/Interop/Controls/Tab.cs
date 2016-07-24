using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabAppend")]
        public static extern void TabAppend(ControlHandle tab, byte[] name, ControlHandle child);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabInsertAt")]
        public static extern void TabInsertAt(ControlHandle tab, byte[] name, int before, ControlHandle child);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabDelete")]
        public static extern void TabDelete(ControlHandle tab, int index);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabNumPages")]
        public static extern int TabNumPages(ControlHandle tab);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabMargined")]
        public static extern bool TabMargined(ControlHandle tab, int page);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiTabSetMargined")]
        public static extern void TabSetMargined(ControlHandle tab, int page, bool margined);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewTab")]
        public static extern ControlHandle NewTab();
    }
}
