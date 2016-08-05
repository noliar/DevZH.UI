using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawListFontFamilies")]
        public static extern ControlHandle DrawListFontFamilies();

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFontFamiliesNumFamilies")]
        public static extern int DrawFontFamiliesNumFamilies(ControlHandle ff);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFontFamiliesFamily")]
        public static extern IntPtr DrawFontFamiliesFamily(ControlHandle ff, int n);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFreeFontFamilies")]
        public static extern void DrawFreeFontFamilies(ControlHandle ff);
    }
}
