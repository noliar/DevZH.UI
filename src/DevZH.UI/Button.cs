using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevZH.UI.Interface;
using DevZH.UI.Interop;
using DevZH.UI.Utils;
using System.Reflection;

namespace DevZH.UI
{
    public class Button : ButtonBase
    {
        public override string Text
        {
            get { return StringUtil.GetString(NativeMethods.ButtonText(ControlHandle)); }
            set { NativeMethods.ButtonSetText(ControlHandle, StringUtil.GetBytes(value));}
        }

        public Button(string text) : base(text)
        {
            /*var result = this.GetType().GetTypeInfo().IsSubclassOf(typeof(Button));
            if (!result)
            {
                ControlHandle = NativeMethods.NewButton(StringUtil.GetBytes(text));
                InitializeEvents();
            }*/
            ControlHandle = NativeMethods.NewButton(StringUtil.GetBytes(text));
            InitializeEvents();
        }

        protected void InitializeEvents()
        {
            NativeMethods.ButtonOnClicked(ControlHandle, (button, data) =>
            {
                OnClick(EventArgs.Empty);
            }, IntPtr.Zero);
        }
    }
}
