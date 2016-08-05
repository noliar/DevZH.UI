using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI.Drawing
{
    public class TextLayout : IControlHandle
    {
        public ControlHandle ControlHandle { get; }

        public double Width
        {
            set
            {
                NativeMethods.DrawTextLayoutSetWidth(ControlHandle, value);
            }
        }

        private readonly Metrics _extents = new Metrics();
        public Metrics Extents
        {
            get
            {
                double width, height;
                NativeMethods.DrawTextLayoutExtents(ControlHandle, out width, out height);
                _extents.Width = width;
                _extents.Height = height;
                return _extents;
            }
        }

        public TextLayout(string text, Font defaultFont, double width)
        {
            ControlHandle = NativeMethods.DrawNewTextLayout(StringUtil.GetBytes(text), defaultFont.ControlHandle, width);
        }

        public void Free()
        {
            NativeMethods.DrawFreeTextLayout(ControlHandle);
        }

        public void SetColor(int begin, int end, Color color)
        {
            NativeMethods.DrawTextLayoutSetColor(ControlHandle, begin, end, color.R, color.G, color.B, color.A);   
        }
    }
}
