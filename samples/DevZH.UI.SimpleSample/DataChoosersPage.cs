using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI.SimpleSample
{
    public class DataChoosersPage : TabPage
    {
        private HorizontalBox _hBox;
        private VerticalBox _vBox;
        private Grid _grid;
        private Button _button;
        private Entry _entry;
        private Grid _msgGrid;
        private Entry _entry2;

        public DataChoosersPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _hBox = new HorizontalBox() {AllowPadding = true};
            this.Child = _hBox;

            _vBox = new VerticalBox() {AllowPadding = true};
            _hBox.Children.Add(_vBox);

            _vBox.Children.Add(new DatePicker());
            _vBox.Children.Add(new TimePicker());
            _vBox.Children.Add(new DateTimePicker());
            _vBox.Children.Add(new FontPicker());
            _vBox.Children.Add(new ColorPicker());

            _hBox.Children.Add(new Separator(Orientation.Vertical));

            _vBox = new VerticalBox() { AllowPadding = true };
            _hBox.Children.Add(_vBox);

            _grid = new Grid() {AllowPadding = true};
            _vBox.Children.Add(_grid);

            _button = new Button("Open File");
            _entry = new Entry() {IsReadOnly = true};

            _button.Click += (sender, args) =>
            {
                var dialog = new OpenFileDialog();
                if (!dialog.Show())
                {
                    _entry.Text = "(cancelled)";
                    return;
                };
                _entry.Text = dialog.Path;
            };

            _grid.Children.Add(_button, 0, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
            _grid.Children.Add(_entry, 1, 0, 1, 1, 1, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

            _button = new Button("Save File");
            _entry2 = new Entry() { IsReadOnly = true };

            _button.Click += (sender, args) =>
            {
                var dialog = new SaveFileDialog();
                if (!dialog.Show())
                {
                    _entry2.Text = "(cancelled)";
                    return;
                };
                _entry2.Text = dialog.Path;
            };

            _grid.Children.Add(_button, 0, 1, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
            _grid.Children.Add(_entry2, 1, 1, 1, 1, 1, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

            _msgGrid = new Grid() {AllowPadding = true};
            _grid.Children.Add(_msgGrid, 0, 2, 2, 1, 0, HorizontalAlignment.Center, 0, VerticalAlignment.Top);

            _button = new Button("Message Box");
            _button.Click += (sender, args) =>
            {
                MessageBox.Show("This is a normal message box.", "More detailed information can be shown here.");
            };
            _msgGrid.Children.Add(_button, 0, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);

            _button = new Button("Error Box");
            _button.Click += (sender, args) =>
            {
                MessageBox.Show("This message box describes an error.", "More detailed information can be shown here.", MessageBoxTypes.Error);
            };
            _msgGrid.Children.Add(_button, 1, 0, 1, 1, 0, HorizontalAlignment.Stretch, 0, VerticalAlignment.Stretch);
        }
    }
}
