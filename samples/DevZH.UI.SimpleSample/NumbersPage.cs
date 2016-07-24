using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI.SimpleSample
{
    public class NumbersPage : TabPage
    {
        private HorizontalBox _hBox;
        private Group _group;
        private VerticalBox _vBox;
        private ProgressBar _ip;
        private ComboBox _comboBox;
        private EditableComboBox _editableComboBox;
        private RadioButtonList _radioButtons;

        private SpinBox _spinBox;
        private Slider _slider;
        private ProgressBar _progressBar;

        public NumbersPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _hBox = new HorizontalBox() {AllowPadding = true};
            this.Child = _hBox;

            _group = new Group("Numbers") {AllowMargins = true};
            _hBox.Children.Add(_group, true);

            _vBox = new VerticalBox() {AllowPadding = true};
            _group.Child = _vBox;

            _spinBox = new SpinBox(0, 100);
            _slider = new Slider(0, 100);

            _progressBar = new ProgressBar();

            _spinBox.ValueChanged += (sender, args) =>
            {
                var value = _spinBox.Value;
                _slider.Value = value;
                _progressBar.Value = value;
            };

            _slider.ValueChanged += (sender, args) =>
            {
                var value = _slider.Value;
                _spinBox.Value = value;
                _progressBar.Value = value;
            };

            _vBox.Children.Add(_spinBox);
            _vBox.Children.Add(_slider);
            _vBox.Children.Add(_progressBar);

            _ip = new ProgressBar();
            _ip.Value = -1;
            _vBox.Children.Add(_ip);

            _group = new Group("Lists") {AllowMargins = true};
            _hBox.Children.Add(_group, true);

            _vBox = new VerticalBox() {AllowPadding = true};
            _group.Child = _vBox;

            _comboBox = new ComboBox();
            _comboBox.Add("Combobox Item 1", "Combobox Item 2", "Combobox Item 3");
            _vBox.Children.Add(_comboBox);

            _editableComboBox = new EditableComboBox();
            _editableComboBox.Add("Editable Item 1", "Editable Item 2", "Editable Item 3");
            _vBox.Children.Add(_editableComboBox);

            _radioButtons = new RadioButtonList();
            _radioButtons.Add("Radio Button 1", "Radio Button 2", "Radio Button 3");
            _vBox.Children.Add(_radioButtons);
        }
    }
}
