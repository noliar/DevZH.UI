using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiGroupTitle")]
        public static extern IntPtr GroupTitle(ControlHandle group);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiGroupSetTitle")]
        public static extern void GroupSetTitle(ControlHandle group, byte[] title);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiGroupSetChild")]
        public static extern void GroupSetChild(ControlHandle group, ControlHandle child);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiGroupMargined")]
        public static extern bool GroupMargined(ControlHandle group);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiGroupSetMargined")]
        public static extern void GroupSetMargined(ControlHandle group, bool margined);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiNewGroup")]
        public static extern ControlHandle NewGroup(byte[] title);
    }
}
