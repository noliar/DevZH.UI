using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Interop
{
    internal partial class NativeMethods
    {
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlDestroy", SetLastError = true)]
        public static extern void ControlDestroy(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlHandle")]
        public static extern UIntPtr ControlHandle(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlParent")]
        public static extern ControlHandle ControlParent(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlSetParent")]
        public static extern void ControlSetParent(ControlHandle control, ControlHandle parent);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlToplevel")]
        public static extern bool ControlToplevel(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlVisible")]
        public static extern bool ControlVisible(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlShow")]
        public static extern void ControlShow(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlHide")]
        public static extern void ControlHide(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlEnabled")]
        public static extern bool ControlEnabled(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlEnable")]
        public static extern void ControlEnable(ControlHandle control);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlDisable")]
        public static extern void ControlDisable(ControlHandle control);

        /* This is unneccesary.
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiAllocControl")]
        public static extern ControlHandle AllocControl(UIntPtr size, uint osSignature, uint typeSignature, string typeName);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiFreeControl")]
        public static extern void FreeControl(ControlHandle control);

        // TODO make sure all controls have these(belows)
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlVerifySetParent")]
        public static extern void ControlVerifySetParent(ControlHandle control, ControlHandle parent);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiControlEnabledToUser")]
        public static extern bool ControlEnabledToUser(ControlHandle control);
        */
    }
}
