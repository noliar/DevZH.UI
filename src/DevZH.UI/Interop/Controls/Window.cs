using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowTitle")]
        public static extern IntPtr WindowTitle(ControlHandle window);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetTitle")]
        public static extern void WindowSetTitle(ControlHandle window, byte[] title);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowPosition")]
        public static extern void WindowPosition(ControlHandle window, out int x, out int y);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetPosition")]
        public static extern void WindowSetPosition(ControlHandle window, int x, int y);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowCenter")]
        public static extern void WindowCenter(ControlHandle window);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowOnPositionChanged")]
        public static extern void WindowOnPositionChanged(ControlHandle window, WindowOnPositionChangedDelegate onPositionChanged, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowContentSize")]
        public static extern void WindowContentSize(ControlHandle window, out int width, out int height);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetContentSize")]
        public static extern void WindowSetContentSize(ControlHandle window, int width, int height);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowFullscreen")]
        public static extern bool WindowFullscreen(ControlHandle window);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetFullscreen")]
        public static extern void WindowSetFullscreen(ControlHandle window, bool fullscreen);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowOnContentSizeChanged")]
        public static extern void WindowOnContentSizeChanged(ControlHandle window, WindowOnContentSizeChangedDelegate onContentSizeChanged, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowOnClosing")]
        public static extern void WindowOnClosing(ControlHandle window, WindowOnClosingDelegate onClosing, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowBorderless")]
        public static extern bool WindowBorderless(ControlHandle window);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetBorderless")]
        public static extern void WindowSetBorderless(ControlHandle window, bool borderless);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetChild")]
        public static extern void WindowSetChild(ControlHandle window, ControlHandle child);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowMargined")]
        public static extern bool WindowMargined(ControlHandle window);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiWindowSetMargined")]
        public static extern void WindowSetMargined(ControlHandle window, bool margined);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewWindow")]
        public static extern ControlHandle NewWindow(byte[] title, int width, int height, bool hasMenubar);
    }
}
