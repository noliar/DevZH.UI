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
        public static extern void AreaSetSize(ControlHandle area, int width, int height);

        // TODO uiAreaQueueRedraw()
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaQueueRedrawAll")]
        public static extern void AreaQueueReDrawAll(ControlHandle area);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAreaScrollTo")]
        public static extern void AreaScrollTo(ControlHandle area, double x, double y, double width, double height);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewArea")]
        public static extern ControlHandle NewArea( AreaHandlerInternal ah);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewScrollingArea")]
        public static extern ControlHandle NewScrollingArea( AreaHandlerInternal ah, int width, int height);
    }
}
