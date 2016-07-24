using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendItem")]
        public static extern ControlHandle MenuAppendItem(ControlHandle menu, byte[] name);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendCheckItem")]
        public static extern ControlHandle MenuAppendCheckItem(ControlHandle menu, byte[] name);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendQuitItem")]
        public static extern ControlHandle MenuAppendQuitItem(ControlHandle menu);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendPreferencesItem")]
        public static extern ControlHandle MenuAppendPreferencesItem(ControlHandle menu);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendAboutItem")]
        public static extern ControlHandle MenuAppendAboutItem(ControlHandle menu);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuAppendSeparator")]
        public static extern void MenuAppendSeparator(ControlHandle menu);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewMenu")]
        public static extern ControlHandle NewMenu(byte[] name);
    }
}
