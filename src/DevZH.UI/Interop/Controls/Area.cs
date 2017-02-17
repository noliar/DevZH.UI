using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DevZH.UI.Drawing;
using DevZH.UI.Interop;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        // TODO give a better name
        // TODO document the types of width and height
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaSetSize")]
        public static extern void AreaSetSize(IntPtr area, int width, int height);

        // TODO uiAreaQueueRedraw()
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaQueueRedrawAll")]
        public static extern void AreaQueueReDrawAll(IntPtr area);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaScrollTo")]
        public static extern void AreaScrollTo(IntPtr area, double x, double y, double width, double height);

        // TODO document these can only be called within Mouse() handlers
        // TODO should these be allowed on scrolling areas?
        // TODO decide which mouse events should be accepted; Down is the only one guaranteed to work right now
        // TODO what happens to events after calling this up to and including the next mouse up?
        // TODO release capture?
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaBeginUserWindowMove")]
        public static extern void AreaBeginUserWindowMove(IntPtr area);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaBeginUserWindowResize")]
        public static extern void AreaBeginUserWindowResize(IntPtr area, WindowResizeEdge edge);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewArea")]
        public static extern IntPtr NewArea( AreaHandlerInternal ah);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewScrollingArea")]
        public static extern IntPtr NewScrollingArea( AreaHandlerInternal ah, int width, int height);
    }
}
