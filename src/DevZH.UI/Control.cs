using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Events;
using DevZH.UI.Interface;
using DevZH.UI.Interop;

namespace DevZH.UI
{
    /// <summary>
    /// TODO: store some info.
    /// TODO: add some event.
    /// </summary>
    public abstract class Control : IDisposable, IControlHandle
    {
        public event EventHandler LocationChanged;

        public event EventHandler Resize;

        public event EventHandler Click;

        public event EventHandler<TextChangedEventArgs> TextChanged;

        internal static Dictionary<ControlHandle, Control> ControlCaches = new Dictionary<ControlHandle, Control>();

        /// <summary>
        /// It stored a pointer to a control instance.
        /// </summary>
        public ControlHandle ControlHandle { get; protected set; }

        public Control Parent { get; internal set; }

        public int Index { get; protected internal set; }

        public virtual string Text { get; set; }

        protected Control()
        {
            
        }

        protected internal bool Verify()
        {
            return this.ControlHandle != null && !this.ControlHandle.IsInvalid;
        }

        /// <summary>
        /// The handle that this control is bound to.
        /// </summary>
        public UIntPtr Handle => NativeMethods.ControlHandle(this.ControlHandle);

        public virtual bool Enabled
        {
            get
            {
                return NativeMethods.ControlEnabled(this.ControlHandle);
            }
            set
            {
                if (value)
                {
                    NativeMethods.ControlEnable(this.ControlHandle);
                }
                else
                {
                    NativeMethods.ControlDisable(this.ControlHandle);
                }
            }
        }

        private bool _visible;
        public bool Visible
        {
            get
            {
                return NativeMethods.ControlVisible(this.ControlHandle);
            }
            set
            {
                if(_visible == value) return;
                if (value)
                {
                    NativeMethods.ControlShow(this.ControlHandle);
                }
                else
                {
                    NativeMethods.ControlHide(this.ControlHandle);
                }
                _visible = value;
            }
        }

        public bool TopLevel
        {
            get
            {
                if (Verify())
                {
                    return NativeMethods.ControlToplevel(this.ControlHandle);
                }
                return false;
            }
            /* TODO
            set
            {
                
            }
            */
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!ControlHandle.IsInvalid)
            {
                DestroyHandle();
            }
        }

        protected virtual void DestroyHandle()
        {
            // TODO maybe store some info
            NativeMethods.ControlDestroy(ControlHandle);
        }

        public virtual void Show()
        {
            this.Visible = true;
        }

        protected virtual void OnResize(EventArgs e)
        {
            Resize?.Invoke(this, e);
        }

        protected virtual void OnLocationChanged(EventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }

        protected virtual void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
        }

        protected virtual void OnTextChanged(EventArgs e)
        {
            var text = this.Text;
            TextChanged?.Invoke(this, new TextChangedEventArgs {Text = text});
        }

        protected internal virtual void DelayRender()
        {
            
        }
    }
}
