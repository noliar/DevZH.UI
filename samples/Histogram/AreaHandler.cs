using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;
using DevZH.UI.Interop;

namespace Histogram
{
    public class AreaHandler : IAreaHandler
    {
        private const int pointRadius = 5;
        private const int xoffLeft = 20;
        private const int yoffTop = 20;
        private const int xoffRight = 20;
        private const int yoffBottom = 20;

        private Path _path;
        private SolidColorBrush _brush;
        private StrokeParams _strokeParams;
        private ColorPicker _colorPicker;
        private List<SpinBox> _spinBoxs;

        private int _currentPoint = -1;

        public AreaHandler(ColorPicker colorPicker, List<SpinBox> spinBoxs)
        {
            _colorPicker = colorPicker;
            _spinBoxs = spinBoxs;
        }

        public void Draw(AreaBase area, ref AreaDrawParams param)
        {
            _brush = Brushes.White;
            _path = new Path(FillMode.Winding);
            _path.AddRectangle(0d,0d, param.AreaWidth, param.AreaHeight);
            _path.End();
            param.Context.Fill(_path, _brush);
            _path.Free();

            double graphWidth;
            double graphHeight;
            GraphSize(param.AreaWidth, param.AreaHeight, out graphWidth, out graphHeight);

            _strokeParams = new StrokeParams()
            {
                LineCap = LineCap.Flat,
                LineJoin = LineJoin.Miter,
                Thickness = 2,
                MiterLimit = 10.0
            };

            _brush = Brushes.Black;
            _path = new Path(FillMode.Winding);
            _path.NewFigure(xoffLeft, yoffTop);
            _path.LineTo(xoffLeft, yoffTop + graphHeight);
            _path.LineTo(xoffLeft + graphWidth, yoffTop + graphHeight);
            _path.End();
            param.Context.Stroke(_path, _brush, _strokeParams);
            _path.Free();

            var matrix = Matrix.SetIdentity();
            matrix.Translate(xoffLeft, yoffTop);
            param.Context.Transform(matrix);

            _brush = (SolidColorBrush) _colorPicker.Color;
            var a = _brush.A;
            _brush.A = _brush.A/2;
            _path = ConstructGraph(graphWidth, graphHeight, true);
            param.Context.Fill(_path, _brush);
            _path.Free();

            _path = ConstructGraph(graphWidth, graphHeight, false);
            _brush.A = a;
            param.Context.Stroke(_path, _brush, _strokeParams);
            _path.Free();

            if (_currentPoint != -1)
            {
                double[] xs, ys;
                PointLocations(graphWidth, graphHeight, out xs, out ys);
                _path = new Path(FillMode.Winding);
                _path.NewFigureWithArc(xs[_currentPoint], ys[_currentPoint], 5, 0, 6.23, false);
                _path.End();
                param.Context.Fill(_path, _brush);
                _path.Free();
            }
        }

        private void GraphSize(double clientWidth, double clientHeight, out double graphWidth, out double graphHeight)
        {
            graphWidth = clientWidth - xoffLeft - xoffRight;
            graphHeight = clientHeight - yoffTop - yoffBottom;
        }

        private Path ConstructGraph(double width, double height, bool extend)
        {
            double[] xs;
            double[] ys;
            PointLocations(width, height, out xs, out ys);
            var path = new Path(FillMode.Winding);
            path.NewFigure(xs[0], ys[0]);
            for (int i = 1; i < 10; i++)
            {
                path.LineTo(xs[i], ys[i]);
            }

            if (extend)
            {
                path.LineTo(width, height);
                path.LineTo(0, height);
                path.CloseFigure();
            }

            path.End();
            return path;
        }

        private void PointLocations(double width, double height, out double[] xs, out double[] ys)
        {
            double xincr, yincr;

            xincr = width/9; // 10 - 1 to make the last point be at the end
            yincr = height/100;
            xs = new double[10];
            ys = new double[10];
            for (var i = 0; i < 10; i++)
            {
                var n = _spinBoxs[i].Value;
                n = 100 - n;
                xs[i] = xincr*i;
                ys[i] = yincr*n;
            }
        }

        private bool InPoint(double x, double y, double xtest, double ytest)
        {
            // TODO switch to using a matrix
            x -= xoffLeft;
            y -= yoffTop;
            return (x >= xtest - pointRadius) &&
                (x <= xtest + pointRadius) &&
                (y >= ytest - pointRadius) &&
                (y <= ytest + pointRadius);
        }

        public void MouseEvent(AreaBase area, ref AreaMouseEvent mouseEvent)
        {
            double graphWidth, graphHeight;
            double[] xs, ys;
            GraphSize(mouseEvent.AreaWidth, mouseEvent.AreaHeight, out graphWidth, out graphHeight);
            PointLocations(graphWidth, graphHeight, out xs, out ys);

            int i;
            for (i = 0; i < 10; i++)
            {
                if (InPoint(mouseEvent.X, mouseEvent.Y, xs[i], ys[i]))
                {
                    break;
                }
            }
            if (i == 10)
            {
                i = -1;
            }
            _currentPoint = i;
            area.QueueReDrawAll();
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
            return false;
        }
    }
}
