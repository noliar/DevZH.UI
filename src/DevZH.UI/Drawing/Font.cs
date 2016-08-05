using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI.Drawing
{
    public class Font : IControlHandle
    {
        public ControlHandle ControlHandle { get; protected internal set; }

        public UIntPtr Handle
        {
            get { return NativeMethods.DrawTextFontHandle(ControlHandle); }
        }

        internal Font()
        {
            
        }

        public Font(FontDescriptor descriptor)
        {
            ControlHandle = NativeMethods.DrawLoadClosestFont(ref descriptor);
        }

        public void Free()
        {
            NativeMethods.DrawFreeTextFont(ControlHandle);
        }

        public FontDescriptor Describe
        {
            get
            {
                FontDescriptor value;
                NativeMethods.DrawTextFontDescribe(ControlHandle, out value);
                return value;
            }
        }

        public FontMetrics Metrics
        {
            get
            {
                FontMetrics value;
                NativeMethods.DrawTextFontGetMetrics(ControlHandle, out value);
                return value;
            }
        }
    }
}
