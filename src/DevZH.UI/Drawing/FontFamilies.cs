using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI.Drawing
{
    public class FontFamilies : IControlHandle
    {
        public ControlHandle ControlHandle { get; private set; }

        public FontFamilies()
        {
            ControlHandle = NativeMethods.DrawListFontFamilies();
        }

        public int Count
        {
            get { return NativeMethods.DrawFontFamiliesNumFamilies(ControlHandle); }
        }

        public string this[int index]
        {
            get { return StringUtil.GetString(NativeMethods.DrawFontFamiliesFamily(ControlHandle, index)); }
        }

        public void Free()
        {
            NativeMethods.DrawFreeFontFamilies(ControlHandle);
        }
    }
}
