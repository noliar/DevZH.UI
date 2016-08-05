using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DevZH.UI.Interop;

namespace DevZH.UI.Drawing
{
    public abstract class AreaBase : Control
    {
        internal AreaHandlerInternal AreaHandlerInternal { get; }

        protected Dictionary<IntPtr, AreaBase> Areas = new Dictionary<IntPtr, AreaBase>();

        protected AreaBase(IAreaHandler handler)
        {
            var areaHandlerInternal = new AreaHandler
            {
                DragBroken = (areaHandler, area) =>
                {
                    var realArea = Areas[area];
                    handler.DragBroken(realArea);
                },
                Draw = (IntPtr areaHandler, IntPtr area, ref AreaDrawParamsInternal param) =>
                {
                    var realArea = Areas[area];
                    var p = (AreaDrawParams) param;
                    handler.Draw(realArea, ref p);
                },
                KeyEvent = (IntPtr areaHandler, IntPtr area, ref AreaKeyEvent keyEvent) =>
                {
                    var realArea = Areas[area];
                    return handler.KeyEvent(realArea, ref keyEvent);
                },
                MouseCrossed = (areaHandler, area, left) =>
                {
                    var realArea = Areas[area];
                    handler.MouseCrossed(realArea, left);
                },
                MouseEvent = (IntPtr areaHandler, IntPtr area, ref AreaMouseEvent mouseEvent) =>
                {
                    var realArea = Areas[area];
                    handler.MouseEvent(realArea, ref mouseEvent);
                }
            };


            AreaHandlerInternal = new AreaHandlerInternal
            {
                DragBroken = Marshal.GetFunctionPointerForDelegate(areaHandlerInternal.DragBroken),
                Draw = Marshal.GetFunctionPointerForDelegate(areaHandlerInternal.Draw),
                KeyEvent = Marshal.GetFunctionPointerForDelegate(areaHandlerInternal.KeyEvent),
                MouseCrossed = Marshal.GetFunctionPointerForDelegate(areaHandlerInternal.MouseCrossed),
                MouseEvent = Marshal.GetFunctionPointerForDelegate(areaHandlerInternal.MouseEvent)
            }; ;
        }

        private Size _size;
        public Size Size
        {
            set
            {
                if (_size != value)
                {
                    NativeMethods.AreaSetSize(ControlHandle, (int)value.Width, (int)value.Height);
                    _size = value;
                }
            }
            get { return _size; }
        }

        public void QueueReDrawAll()
        {
            NativeMethods.AreaQueueReDrawAll(ControlHandle);
        }

        public void ScrollTo(double x, double y, double width, double height)
        {
            NativeMethods.AreaScrollTo(ControlHandle, x, y, width, height);
        }
    }

    public class Area : AreaBase
    {
        public Area(IAreaHandler handler) : base(handler)
        {
            ControlHandle = NativeMethods.NewArea( AreaHandlerInternal);
            var handle = ControlHandle.DangerousGetHandle();
            Areas[handle] = this;
        }
    }

    public class ScrollingArea : AreaBase
    {
        public ScrollingArea(IAreaHandler handler, int width, int height) : base(handler)
        {
            ControlHandle = NativeMethods.NewScrollingArea( AreaHandlerInternal, width, height);
            var handle = ControlHandle.DangerousGetHandle();
            Areas[handle] = this;
        }
    }
}