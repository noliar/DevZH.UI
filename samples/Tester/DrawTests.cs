using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;

namespace Tester
{
    public static class DrawTests
    {
        public delegate void Draw(ref AreaDrawParams param);

        public static Dictionary<string, Draw> Funcs = new Dictionary<string, Draw>
        {
            {"Original uiArea test", DrawOriginal},
            {"Draw Gradient",DrawGradient },
            {"Draw Dashes", DrawDashes }
        };

        private static void DrawDashes(ref AreaDrawParams param)
        {
            var offset = -50;
            var dashes = new double[] {50d, 10d, 10d, 10d};
            var brush = Brushes.Black;
            var sp = new StrokeParams();
            sp.Dashes = dashes;
            sp.DashPhase = offset;
            sp.Thickness = 10;

            var path = new Path(FillMode.Winding);
            path.NewFigure(128.0, 25.6);
            path.LineTo(230.4, 230.4);
            path.LineTo(230.4 - 102.4, 230.4 + 0.0);
            path.BezierTo(51.2, 230.4, 51.2, 128.0, 128.0, 128.0);
            path.End();
            param.Context.Stroke(path, brush, sp);
            path.Free();
        }

        private static void DrawGradient(ref AreaDrawParams param)
        {
            var areaSize = 250d;
            var padding = 30d;
            var circleRadius = (areaSize - padding)/2;

            var path = new Path(FillMode.Winding);
            path.AddRectangle(-50, -50, areaSize + 100, areaSize + 100);
            path.End();
            var brush = Brushes.Lime;
            param.Context.Fill(path, brush);
            path.Free();

            path = new Path(FillMode.Winding);
            path.AddRectangle(0, 0, areaSize, areaSize);
            path.End();
            brush = Brushes.White;
            param.Context.Fill(path, brush);
            brush = Brushes.Red;
            var sp = new StrokeParams() { Thickness = 1 };
            param.Context.Stroke(path, brush, sp);
            path.Free();

            path = new Path(FillMode.Winding);
            path.NewFigureWithArc(areaSize/2, areaSize/2, circleRadius, 0, 2*Math.PI, false);
            path.End();
            var stops = new GradientStop[2];
            stops[0] = new GradientStop() {Pos = 0, R = 0, G = 1, B = 1, A = 1};
            stops[1] = new GradientStop() { Pos = 1, R = 0, G = 0, B = 1, A = 1 };
            var linear = new LinearGradientBrush
            {
                StartPoint = new Point(areaSize/2, padding),
                EndPoint = new Point(areaSize/2, areaSize - padding),
                Stops = stops
            };
            param.Context.Fill(path, linear);
            path.Free();
        }

        private static void DrawOriginal(ref AreaDrawParams param)
        {
            var sp = new StrokeParams() {Thickness = 1};
            var brush = Brushes.Red;
            var path = new Path(FillMode.Winding);
            path.NewFigure(param.ClipX + 5, param.ClipY + 5);
            path.LineTo(param.ClipX + param.ClipWidth -5, param.ClipY + param.ClipHeight - 5);
            path.End();
            param.Context.Stroke(path, brush, sp);
            path.Free();

            brush = Brushes.Blue;
            brush.B = 0.75;
            path = new Path(FillMode.Winding);
            path.NewFigure(param.ClipX, param.ClipY);
            path.LineTo(param.ClipX + param.ClipWidth, param.ClipY);
            path.LineTo(50, 150);
            path.LineTo(50, 50);
            path.CloseFigure();
            path.End();
            sp.Thickness = 5;
            sp.LineJoin = LineJoin.Round;
            param.Context.Stroke(path, brush, sp);
            path.Free();

            brush = Brushes.Green;
            brush.G = 0.75;
            brush.A = 0.5;
            path = new Path(FillMode.Winding);
            path.AddRectangle(120, 80, 50, 50);
            path.End();
            param.Context.Fill(path, brush);
            path.Free();

            brush.G = 0.5;
            brush.A = 1;
            path = new Path(FillMode.Winding);
            path.NewFigure(5.5, 10.5);
            path.LineTo(5.5, 50.5);
            path.End();
            sp.LineJoin = LineJoin.Miter;
            sp.Thickness = 1;
            param.Context.Stroke(path, brush, sp);
            path.Free();

            brush.R = 0.5;
            brush.G = 0.75;
            path = new Path(FillMode.Winding);
            path.NewFigure(400, 100);
            path.ArcTo(400, 100, 50, 30 * (Math.PI/180), 300 * (Math.PI / 180), false);
            path.LineTo(400, 100);
            path.NewFigureWithArc(510, 100, 50, 30 * (Math.PI / 180), 300 * (Math.PI / 180), false);
            path.CloseFigure();
            path.NewFigure(400, 210);
            path.ArcTo(400, 210, 50, 30 * (Math.PI / 180), 330 * (Math.PI / 180), false);
            path.LineTo(400, 210);
            path.NewFigureWithArc(510, 210, 50, 30 * (Math.PI / 180), 330 * (Math.PI / 180), false);
            path.CloseFigure();
            path.End();
            param.Context.Stroke(path, brush, sp);
            path.Free();

            brush.R = 0;
            brush.G = 0.5;
            brush.B = 0.75;
            path = new Path(FillMode.Winding);
            path.NewFigure(300, 300);
            path.BezierTo(350, 320, 310, 390, 435, 372);
            path.End();
            param.Context.Stroke(path, brush, sp);
            path.Free();
        }

        public static void PopulateComboboxWithTests(ComboBox comboBox)
        {
            foreach (var func in Funcs)
            {
                comboBox.Add(func.Key);
            }
        }

        public static void RunDrawTest(int index, ref AreaDrawParams param)
        {
            if (index < 0)
            {
                return;
            }
            Funcs.Values.ElementAt(index)(ref param);
        }
    }
}
