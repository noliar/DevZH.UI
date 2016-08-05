using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DevZH.UI.Drawing;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawLoadClosestFont")]
        public static extern ControlHandle DrawLoadClosestFont(ref FontDescriptor desc);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFreeTextFont")]
        public static extern void DrawFreeTextFont(ControlHandle font);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawTextFontHandle")]
        public static extern UIntPtr DrawTextFontHandle(ControlHandle font);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawTextFontDescribe")]
        public static extern void DrawTextFontDescribe(ControlHandle font, out FontDescriptor desc);

        // TODO make copy with given attributes methods?
        // TODO yuck this name
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawTextFontGetMetrics")]
        public static extern void DrawTextFontGetMetrics(ControlHandle font, out FontMetrics metrics);
    }
}
