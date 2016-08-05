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
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawNewPath")]
        public static extern ControlHandle DrawNewPath(FillMode fillMode);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFreePath")]
        public static extern void DrawFreePath(ControlHandle path);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathNewFigure")]
        public static extern void DrawPathNewFigure(ControlHandle path, double x, double y);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathNewFigureWithArc")]
        public static extern void DrawPathNewFigureWithArc(ControlHandle path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathLineTo")]
        public static extern void DrawPathLineTo(ControlHandle path, double x, double y);

        // notes: angles are both relative to 0 and go counterclockwise
        // TODO is the initial line segment on cairo and OS X a proper join?
        // TODO what if sweep < 0?
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathArcTo")]
        public static extern void DrawPathArcTo(ControlHandle path, double xCenter, double yCenter, double radius, double startAngle, double sweep, bool negative);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathBezierTo")]
        public static extern void DrawPathBezierTo(ControlHandle path, double c1x, double c1y, double c2x, double c2y, double endX, double endY);
        
        // TODO quadratic bezier
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathCloseFigure")]
        public static extern void DrawPathCloseFigure(ControlHandle path);

        // TODO effect of these when a figure is already started
        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathAddRectangle")]
        public static extern void DrawPathAddRectangle(ControlHandle path, double x, double y, double width, double height);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawPathEnd")]
        public static extern void DrawPathEnd(ControlHandle path);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawStroke")]
        public static extern void DrawStroke(ControlHandle context, ControlHandle path, ref Brush brush, ref StrokeParams strokeParam);

        [DllImport(LibUI, CallingConvention = CallingConvention.Cdecl, EntryPoint = "uiDrawFill")]
        public static extern void DrawFill(ControlHandle context, ControlHandle path, ref Brush brush);
    }
}
