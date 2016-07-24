using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuItemEnable")]
        public static extern void MenuItemEnable(ControlHandle menuItem);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuItemDisable")]
        public static extern void MenuItemDisable(ControlHandle menuItem);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuItemOnClicked")]
        public static extern void MenuItemOnClicked(ControlHandle menuItem, MenuItemOnClickedDelegate menuItemOnClicked, IntPtr data);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuItemChecked")]
        public static extern bool MenuItemChecked(ControlHandle menuItem);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiMenuItemSetChecked")]
        public static extern void MenuItemSetChecked(ControlHandle menuItem, bool isChecked);
    }
}
