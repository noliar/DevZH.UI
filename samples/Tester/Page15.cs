using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;

namespace Tester
{
    public class Page15 : TabPage
    {
        

        private VerticalBox _container;
        private SpinBox _width, _height;
        private CheckBox _fullscreen;

        private MainWindow _mainWindow;

        private AreaHandler _borderAH;

        public Page15(string name, MainWindow mainWindow) : base(name)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private bool borderAHInit;

        private void InitializeComponent()
        {
            _container = new VerticalBox();
            this.Child = _container;

            var hbox = new HorizontalBox();
            _container.Children.Add(hbox);

            hbox.Children.Add(new Label("Size"));

            _width = new SpinBox(int.MinValue, int.MaxValue);
            hbox.Children.Add(_width, true);

            _height = new SpinBox(int.MinValue, int.MaxValue);
            hbox.Children.Add(_height, true);

            _fullscreen = new CheckBox("Fullscreen");
            hbox.Children.Add(_fullscreen);

            _width.ValueChanged += (sender, args) =>
            {
                var size = _mainWindow.Size;
                _mainWindow.Size = new Size(_width.Value, size.Height);
            };

            _height.ValueChanged += (sender, args) =>
            {
                var size = _mainWindow.Size;
                _mainWindow.Size = new Size(size.Width, _height.Value);
            };

            _fullscreen.Checked += (sender, args) =>
            {
                _mainWindow.FullScreen = true;
                UpdateSize();
            };

            _fullscreen.UnChecked += (sender, args) =>
            {
                _mainWindow.FullScreen = false;
                UpdateSize();
            };

            _mainWindow.Resize += (sender, args) =>
            {
                Console.WriteLine("size\n");
                UpdateSize();
            };
            UpdateSize();

            var checkbox = new CheckBox("Borderless");
            checkbox.Checked += (sender, args) =>
            {
                _mainWindow.Borderless = true;
            };

            checkbox.UnChecked += (sender, args) =>
            {
                _mainWindow.Borderless = false;
            };
            _container.Children.Add(checkbox);

            var button = new Button("Borderless Resizes");
            button.Click += (sender, args) =>
            {
                if (!borderAHInit)
                {
                    _borderAH = new AreaHandler();
                    borderAHInit = true;
                }
                var window = new Window("Border Resize Test", 300, 500);
                window.Borderless = true;

                var area = new Area(_borderAH);

                var b = new HorizontalBox();
                b.Children.Add(area, true);
                window.Child = b;
                window.Show();

            };
            _container.Children.Add(button);

            hbox = new HorizontalBox();
            _container.Children.Add(hbox, true);
            hbox.Children.Add(new Separator(Orientation.Vertical));
        }

        private void UpdateSize()
        {
            var size = _mainWindow.Size;
            _width.Value = (int)size.Width;
            _height.Value = (int) size.Height;
            // TODO on OS X this is updated AFTER sending the size change, not before
            _fullscreen.IsChecked = _mainWindow.FullScreen;

        }

        private class AreaHandler : IAreaHandler
        {
            class trect
            {
                public double left;
                public double top;
                public double right;
                public double bottom;
                public bool isIn;
            }

            class tareas
            {
                public trect move = new trect();
                public trect alsomove = new trect();
                public trect leftresize = new trect();
                public trect topresize = new trect();
                public trect rightresize = new trect();
                public trect bottomresize = new trect();
                public trect topleftresize = new trect();
                public trect toprightresize = new trect();
                public trect bottomleftresize = new trect();
                public trect bottomrightresize = new trect();
                public trect close = new trect();
            }

            double lastx = -1, lasty = -1;

            void tsetrect(trect re, double l, double t, double r, double b)
            {
                re.left = l;
                re.top = t;
                re.right = r;
                re.bottom = b;
                re.isIn = lastx >= re.left && lastx < re.right && lasty >= re.top && lasty < re.bottom;
            }

            void filltareas(double awid, double aht, tareas ta)
            {

                tsetrect(ta.move, 20, 20, awid - 20, 20 + 30);

                tsetrect(ta.alsomove, 30, 200, 100, 270);

                tsetrect(ta.leftresize, 5, 20, 15, aht - 20);

                tsetrect(ta.topresize, 20, 5, awid - 20, 15);

                tsetrect(ta.rightresize, awid - 15, 20, awid - 5, aht - 20);

                tsetrect(ta.bottomresize, 20, aht - 15, awid - 20, aht - 5);

                tsetrect(ta.topleftresize, 5, 5, 15, 15);

                tsetrect(ta.toprightresize, awid - 15, 5, awid - 5, 15);

                tsetrect(ta.bottomleftresize, 5, aht - 15, 15, aht - 5);

                tsetrect(ta.bottomrightresize, awid - 15, aht - 15, awid - 5, aht - 5);

                tsetrect(ta.close, 130, 200, 200, 270);
            }

            void drawtrect(DrawContext c, trect tr, double r, double g, double bl)
            {
                var p = new Path(FillMode.Winding);
                var b = new SolidColorBrush();
                b.R = r;
                b.G = g;
                b.B = bl;
                b.A = 1.0;
                if (tr.isIn)
                {
                    b.R += b.R * 0.75;
                    b.G += b.G * 0.75;
                    b.B += b.B * 0.75;
                }
                p.AddRectangle(tr.left,
                    tr.top,
                    tr.right - tr.left,
                    tr.bottom - tr.top);
                p.End();
                c.Fill(p, b);
                p.Free();
            }

            public void Draw(AreaBase area, ref AreaDrawParams p)
            {
                tareas ta = new tareas();

                filltareas(p.AreaWidth, p.AreaHeight, ta);
                drawtrect(p.Context, ta.move, 0, 0.5, 0);
                drawtrect(p.Context, ta.alsomove, 0, 0.5, 0);
                drawtrect(p.Context, ta.leftresize, 0, 0, 0.5);
                drawtrect(p.Context, ta.topresize, 0, 0, 0.5);
                drawtrect(p.Context, ta.rightresize, 0, 0, 0.5);
                drawtrect(p.Context, ta.bottomresize, 0, 0, 0.5);
                drawtrect(p.Context, ta.topleftresize, 0, 0.5, 0.5);
                drawtrect(p.Context, ta.toprightresize, 0, 0.5, 0.5);
                drawtrect(p.Context, ta.bottomleftresize, 0, 0.5, 0.5);
                drawtrect(p.Context, ta.bottomrightresize, 0, 0.5, 0.5);
                drawtrect(p.Context, ta.close, 0.5, 0, 0);

                // TODO add current position prints here
            }

            public void MouseEvent(AreaBase area, ref AreaMouseEvent e)
            {
                tareas ta = new tareas();

                lastx = e.X;
                lasty = e.Y;
                filltareas(e.AreaWidth, e.AreaHeight, ta);
                // redraw our highlighted rect
                area.QueueReDrawAll();
                if (e.Down != 1)
                    return;
                if (ta.move.isIn || ta.alsomove.isIn) {
                    area.BeginUserWindowMove();
                    return;
                }
                if (ta.leftresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.Left);
                    return;
                }
                if (ta.topresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.Top);
                    return;
                }
                if (ta.rightresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.Right);
                    return;
                }
                if (ta.bottomresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.Bottom);
                    return;
                }
                if (ta.topleftresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.TopLeft);
                    return;
                }
                if (ta.toprightresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.TopRight);
                    return;
                }
                if (ta.bottomleftresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.BottomLeft);
                    return;
                }
                if (ta.bottomrightresize.isIn)
                {
                    area.BeginUserWindowResize(WindowResizeEdge.BottomRight);
                    return;
                }
                if (ta.close.isIn) {
                    // TODO
                    return;
                }
            }

            public void MouseCrossed(AreaBase area, int left)
            {
                //throw new NotImplementedException();
            }

            public void DragBroken(AreaBase area)
            {
                //throw new NotImplementedException();
            }

            public bool KeyEvent(AreaBase area, ref AreaKeyEvent keyEvent)
            {
                //throw new NotImplementedException();
                return false;
            }
        }

        void resize(AreaBase area, bool cond , WindowResizeEdge edge )
        {
            if (cond)
            {
                area.BeginUserWindowResize(edge); 
                return;
            }
        }
}
}
