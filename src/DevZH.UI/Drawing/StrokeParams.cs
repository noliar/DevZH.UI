using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DevZH.UI.Drawing
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StrokeParams
    {
        public LineCap LineCap;
        public LineJoin LineJoin;
        public double Thickness;
        public double MiterLimit;
        public double[] Dashes;
        //[MarshalAs(UnmanagedType.SysUInt)]
        //public uint NumDashes;
        public UIntPtr NumDashes;
        public double DashPhase;
    }

    public static class StrokeParamsValue
    {
        public const double DefaultMiterLimit = 10.0;
    }
}
