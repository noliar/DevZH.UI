using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Brush
    {
        [MarshalAs(UnmanagedType.I4)]
        public BrushType BrushType;

        // solid brushes
        public double R;
        public double G;
        public double B;
        public double A;

        // gradient brushes
        public double X0;      // linear: start X, radial: start X
        public double Y0;      // linear: start Y, radial: start Y
        public double X1;      // linear: end X, radial: outer circle center X
        public double Y1;      // linear: end Y, radial: outer circle center Y
        public double OuterRadius;		// radial gradients only

        public GradientStop[] Stops;
        //[MarshalAs(UnmanagedType.SysUInt)]
        //public uint NumStops;
        public UIntPtr NumStops;

        // TODO extend mode
        // cairo: none, repeat, reflect, pad; no individual control
        // Direct2D: repeat, reflect, pad; no individual control
        // Core Graphics: none, pad; before and after individually
        // TODO cairo documentation is inconsistent about pad

        // TODO images

        // TODO transforms

        //
        public Color Color;

        internal Brush(Color color)
        {
            BrushType = BrushType.Solid;

            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;

            X0 = default(double);
            X1 = default(double);

            Y0 = default(double);
            Y1 = default(double);

            OuterRadius = default(double);

            Stops = null;
            NumStops = UIntPtr.Zero;

            Color = color;
        }
    }
}
