using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;

namespace Histogram
{
    public class MainWindow : Window
    {
        private HorizontalBox _hBox;
        private VerticalBox _vBox;
        private List<SpinBox> _spinBoxs;

        private Area _histogram;

        private ColorPicker _colorPicker;

        public MainWindow(string title, int width = 500, int height = 200, bool hasMenubar = false) : base(title, width, height, hasMenubar)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _hBox = new HorizontalBox() {AllowPadding = true};
            this.Child = _hBox;

            _vBox = new VerticalBox() {AllowPadding = true};
            _hBox.Children.Add(_vBox);

            _spinBoxs = new List<SpinBox>();
            for (int i = 0; i < 10; i++)
            {
                var _spinBox = new SpinBox(0, 100);
                _spinBox.Value = new Random(DateTime.Now.Millisecond).Next(0, 101);
                _spinBox.ValueChanged += SpinBoxOnValueChanged;
                _vBox.Children.Add(_spinBox);
                _spinBoxs.Add(_spinBox);
            }

            _colorPicker = new ColorPicker();
            _colorPicker.Color = (Color)Brushes.Blue;
            _colorPicker.ColorChanged += (sender, args) =>
            {
                _histogram.QueueReDrawAll();
            };

            _vBox.Children.Add(_colorPicker);

            _histogram = new Area(new AreaHandler(_colorPicker, _spinBoxs));
            _hBox.Children.Add(_histogram, true);
        }

        private void SpinBoxOnValueChanged(object sender, EventArgs eventArgs)
        {
            _histogram.QueueReDrawAll();
        }
    }
}
