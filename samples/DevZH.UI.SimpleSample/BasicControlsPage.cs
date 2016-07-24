using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI.SimpleSample
{
    public class BasicControlsPage : TabPage
    {
        private VerticalBox _verticalBox;
        private HorizontalBox _horizontalBox;
        private Group _group;
        private Form _form;

        private Button _button;
        private CheckBox _checkBox;
        private Label _label;

        private Separator _horizontalSeparator;

        private Entry _entry;
        private PasswordEntry _passwordEntry;
        private SearchEntry _searchEntry;
        private MultilineEntry _multilineEntry;
        private MultilineEntry _multilineNoWrappingEntry;

        public BasicControlsPage(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _verticalBox = new VerticalBox {AllowPadding = true};
            this.Child = _verticalBox;
            _horizontalBox = new HorizontalBox {AllowPadding = true};
            _verticalBox.Children.Add(_horizontalBox);
            _button = new Button("Button");
            _horizontalBox.Children.Add(_button);
            _checkBox = new CheckBox("CheckBox");
            _horizontalBox.Children.Add(_checkBox);
            _label = new Label("This is a label. Right now, labels can only span one line.");
            _verticalBox.Children.Add(_label);
            _horizontalSeparator = new Separator();
            _verticalBox.Children.Add(_horizontalSeparator);
            _group = new Group("Entries") {AllowMargins = true};
            _verticalBox.Children.Add(_group, true);
            _form = new Form {AllowPadding = true};
            _group.Child = _form;
            _entry = new Entry();
            _form.Children.Add("Entry", _entry);
            _passwordEntry = new PasswordEntry();
            _form.Children.Add("Password Entry", _passwordEntry);
            _searchEntry = new SearchEntry();
            _form.Children.Add("Search Entry", _searchEntry);
            _multilineEntry = new MultilineEntry();
            _form.Children.Add("Multiline Entry", _multilineEntry, true);
            _multilineNoWrappingEntry = new MultilineEntry(false);
            _form.Children.Add("Multiline Entry No Wrap", _multilineNoWrappingEntry, true);

        }
    }
}
