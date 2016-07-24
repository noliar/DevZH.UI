using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Drawing;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    public class FontPicker : Control
    {
        public event EventHandler FontChanged;

        private Font _font;
        public Font Font
        {
            get
            {
                if (_font == null)
                {
                    _font = new Font();
                }
                _font.ControlHandle = NativeMethods.FontButtonFont(ControlHandle);
                return _font;
            }
        }

        public FontPicker()
        {
            this.ControlHandle = NativeMethods.NewFontButton();
            InitializeEvents();
        }


        protected void InitializeEvents()
        {
            NativeMethods.FontButtonOnChanged(ControlHandle, (button, data) =>
            {
                OnFontChanged(EventArgs.Empty);
            }, IntPtr.Zero);
        }

        protected virtual void OnFontChanged(EventArgs e)
        {
            FontChanged?.Invoke(this, e);
        }
    }
}
