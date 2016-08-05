using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI.Drawing
{
    public static class Brushes
    {
        public static Brush Black => BrushFromUint(0xFF000000u);

        public static Brush Blue => BrushFromUint(0xFF0000FFu);

        public static Brush Grey => BrushFromUint(0xFF808080u);

        public static Brush Green => BrushFromUint(0xFF008000u);

        public static Brush Indigo => BrushFromUint(0xFF4B0082u);

        public static Brush Orange => BrushFromUint(0xFFFFA500u);

        public static Brush Purple => BrushFromUint(0xFF800080u);

        public static Brush Red => BrushFromUint(0xFFFF0000u);

        public static Brush Yellow => BrushFromUint(0xFFFFFF00u);

        public static Brush White => BrushFromUint(0xFFFFFFFFu);

        private static Brush BrushFromUint(uint argb)
        {
            var brush = new Brush(Color.FromUint(argb));
            return brush;
        }
    }
}
