using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using DevZH.UI.Drawing;
using DevZH.UI.Interface;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class Window : Control
    {
        private static readonly Dictionary<IntPtr, Window> Windows = new Dictionary<IntPtr, Window>();

        public EventHandler<CancelEventArgs> Closing;

        private Control _child;  
        public Control Child
        {
            set
            {
                _child = value;
                if (value == null)
                {
                    NativeMethods.WindowSetChild(handle, IntPtr.Zero);
                    return;
                }
                if (value.Verify())
                {
                    NativeMethods.WindowSetChild(handle, value.handle);
                }
            }
            get
            {
                return _child;
            }
        }

        // private string _title;
        public string Title
        {
            // Which is faster, P/Invoke or variable;
            get
            {
                var str = NativeMethods.WindowTitle(handle);
                return StringUtil.GetString(str);
            }
            set
            {
                var title = value;
                if (!ValidTitle(title)) title = "DevZH.UI";
                NativeMethods.WindowSetTitle(handle, StringUtil.GetBytes(title));
            }
        }

        /* //libui moved it to '_abort' part.
        
        private Point _location = new Point();

        public Point Location
        {
            get
            {
                int x, y;
                NativeMethods.WindowPosition(handle, out x, out y);
                _location.X = x;
                _location.Y = y;
                return _location;
            }
            set
            {
                _location = value;
                NativeMethods.WindowSetPosition(handle, (int) value.X, (int) value.Y);
                StartPosition = WindowStartPosition.Manual;
            }
        }*/

        private Size _size = new Size();
        public Size Size
        {
            get
            {
                int w, h;
                NativeMethods.WindowContentSize(handle, out w, out h);
                _size.Width = w;
                _size.Height = h;
                return _size;
            }
            set
            {
                _size = value;
                NativeMethods.WindowSetContentSize(handle, (int) value.Width, (int) value.Height);
            }
        }

        public bool AllowMargins
        {
            get { return NativeMethods.WindowMargined(handle); }
            set { NativeMethods.WindowSetMargined(handle, value);}
        }

        public bool FullScreen
        {
            get { return NativeMethods.WindowFullscreen(handle); }
            set { NativeMethods.WindowSetFullscreen(handle, value);}
        }

        public bool Borderless
        {
            get { return NativeMethods.WindowBorderless(handle); }
            set { NativeMethods.WindowSetBorderless(handle, value); }
        }

        public Window(string title, int width = 500, int height = 200, bool hasMemubar = false)
        {
            if (!ValidTitle(title)) title = "DevZH.UI";
            this.handle = NativeMethods.NewWindow(StringUtil.GetBytes(title), width, height, hasMemubar);
            Windows.Add(this.handle, this);
            this.InitializeEvents();
            this.InitializeData();
        }

        protected sealed override void InitializeEvents()
        {
            if (!this.Verify())
            {
                throw new TypeInitializationException(nameof(Window), new InvalidComObjectException());
            }
            NativeMethods.WindowOnClosing(this.handle, (window, data) =>
            {
                var args = new CancelEventArgs();
                OnClosing(args);
                // args.Cancel: True is not closing. False is to be closed and destroyed.
                // It maybe a little different to other wrapper.
                var cancel = args.Cancel;
                if (!cancel)
                {
                    if (Windows.Count > 1 && this != Application.MainWindow)
                    {
                        this.Close();
                    }
                    else
                    {
                        Application.Current.Exit();
                    }
                }
                return !cancel;
            }, IntPtr.Zero);

            /*NativeMethods.WindowOnPositionChanged(this.handle, (window, data) =>
            {
                OnLocationChanged(EventArgs.Empty);
            }, IntPtr.Zero);*/

            NativeMethods.WindowOnContentSizeChanged(this.handle, (window, data) =>
            {
                OnResize(EventArgs.Empty);
            }, IntPtr.Zero);
        }

        protected sealed override void InitializeData()
        {
        }

        protected virtual void OnClosing(CancelEventArgs e)
        {
            Closing?.Invoke(this, e);
        }

        // Is it necessary?
        protected bool ValidTitle(string title) => !string.IsNullOrEmpty(title);

        /* No effect by now
        public WindowStartPosition StartPosition { get; set; }
        */

        public override void Show()
        {
            /* No effect by now
            switch (StartPosition)
            {
                case WindowStartPosition.CenterScreen:
                    CenterToScreen();
                    break;
            }*/

            base.Show();
        }

        public void Close()
        {
            Hide();
            if (Child != null)
            {
                Child.Dispose(true);
                Child = null;
            }
            var intptr = this.handle;
            base.Destroy();
            Windows.Remove(intptr);
        }

        /* //libui moved it to '_abort' part.
        public void CenterToScreen()
        {
            NativeMethods.WindowCenter(handle);
        }*/
    }
}
