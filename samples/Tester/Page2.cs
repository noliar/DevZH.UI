using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;

namespace Tester
{
    public class Page2 : TabPage
    {
        private Tab _mainTab;
        private HorizontalBox _mainBox;
        private Page1 _page1;

        private BoxContainer[] _movingBoxes = new BoxContainer[2];
        private const string MoveOutText = "Move Page 1 Out";
        private const string MoveBackText = "Move Page 1 Back";

        private VerticalBox _container;
        private Group _group;
        private VerticalBox _vBox;
        private HorizontalBox _hBox;
        private Button _button;
        private Label _movingLabel;

        private HorizontalBox _nestedBox;
        private HorizontalBox _innerhbox;
        private HorizontalBox _innerhbox2;
        private HorizontalBox _innerhbox3;

        private Tab _disabledTab;

        private Entry _entry;
        private Entry _readonly;

        private Button _button2;

        private int _movingCurrent;
        private bool _moveBack;


        public Page2(string name, Tab tab, HorizontalBox main, Page1 page1) : base(name)
        {
            _mainTab = tab;
            _mainBox = main;
            _page1 = page1;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _container = new VerticalBox();
            this.Child = _container;

            _group = new Group("Moving Label");
            _container.Children.Add(_group);

            _vBox = new VerticalBox();
            _group.Child = _vBox;

            _hBox = new HorizontalBox();
            _button = new Button("Move the Label!");
            _button.Click += (sender, args) =>
            {
                var to = _movingCurrent == 0 ? 1 : 0;
                _movingBoxes[_movingCurrent].Children.RemoveAt(0);
                _movingBoxes[to].Children.Add(_movingLabel);
                _movingCurrent = to;
            };
            _hBox.Children.Add(_button, true);
            _hBox.Children.Add(new Label(""), true);
            _vBox.Children.Add(_hBox);

            _hBox = new HorizontalBox();
            _movingBoxes[0] = new VerticalBox();
            _hBox.Children.Add(_movingBoxes[0], true);
            _movingBoxes[1] = new VerticalBox();
            _hBox.Children.Add(_movingBoxes[1], true);
            _vBox.Children.Add(_hBox);

            _movingLabel = new Label("This label moves!");
            _movingBoxes[0].Children.Add(_movingLabel);

            _hBox = new HorizontalBox();
            _button = new Button(MoveOutText);
            _button.Click += (sender, args) =>
            {
                var btn = sender as Button;
                if(btn == null) return;
                if (_moveBack)
                {
                    _mainBox.Children.RemoveAt(1);
                    _mainTab.Children.Insert(0, _page1);
                    btn.Text = MoveOutText;
                    _moveBack = false;
                }
                else
                {
                    _mainTab.Children.RemoveAt(0);
                    _mainBox.Children.Add(_page1, true);
                    btn.Text = MoveBackText;
                    _moveBack = true;
                }
            };
            _hBox.Children.Add(_button);
            _container.Children.Add(_hBox);

            _hBox = new HorizontalBox();
            _hBox.Children.Add(new Label("Label Alignment Test"));
            _button = new Button("Open Menued Window");
            _button.Click += (sender, args) =>
            {
                OpenAnotherWindow(true);
            };
            _hBox.Children.Add(_button);

            _button = new Button("Open Menuless Window");
            _button.Click += (sender, args) =>
            {
                OpenAnotherWindow(false);
            };
            _hBox.Children.Add(_button);

            _button = new Button("Disabled Menued");
            _button.Click += (sender, args) =>
            {
                OpenAnotherDisabledWindow(true);
            };
            _hBox.Children.Add(_button);

            _button = new Button("Disabled Menuless");
            _button.Click += (sender, args) =>
            {
                OpenAnotherDisabledWindow(false);
            };
            _hBox.Children.Add(_button);

            _container.Children.Add(_hBox);

            _nestedBox = new HorizontalBox();
            _innerhbox = new HorizontalBox();
            _innerhbox.Children.Add(new Button("These"));
            _innerhbox.Children.Add(new Button("buttons") {Enabled = false});
            _nestedBox.Children.Add(_innerhbox);

            _innerhbox = new HorizontalBox();
            _innerhbox.Children.Add(new Button("are"));
            _innerhbox2 = new HorizontalBox();
            _innerhbox2.Children.Add(new Button("in") { Enabled = false });
            _innerhbox.Children.Add(_innerhbox2);
            _nestedBox.Children.Add(_innerhbox);

            _innerhbox = new HorizontalBox();
            _innerhbox2 = new HorizontalBox();
            _innerhbox2.Children.Add(new Button("nested"));
            _innerhbox3 = new HorizontalBox();
            _innerhbox3.Children.Add(new Button("boxes") { Enabled = false });
            _innerhbox2.Children.Add(_innerhbox3);
            _innerhbox.Children.Add(_innerhbox2);
            _nestedBox.Children.Add(_innerhbox);
            _container.Children.Add(_nestedBox);

            _hBox = new HorizontalBox();
            _button = new Button("Enable Nested Box");
            _button.Click += (sender, args) =>
            {
                _nestedBox.Enabled = true;
            };
            _hBox.Children.Add(_button);
            _button = new Button("Disable Nested Box");
            _button.Click += (sender, args) =>
            {
                _nestedBox.Enabled = false;
            };
            _hBox.Children.Add(_button);
            _container.Children.Add(_hBox);

            _disabledTab = new Tab();
            _disabledTab.Children.Add(new TabPage("Disabled", new Button("Button")));
            _disabledTab.Children.Add(new TabPage("Tab", new Label("Label")));
            _disabledTab.Enabled = false;
            _container.Children.Add(_disabledTab, true);

            _entry = new Entry();
            _readonly = new Entry();
            _entry.TextChanged += (sender, args) =>
            {
                _readonly.Text = args.Text;
            };
            _readonly.Text = "If you can see this, uiEntryReadOnly() isn't working properly.";
            _readonly.IsReadOnly = true;
            if (_readonly.IsReadOnly)
            {
                _readonly.Text = "";
            }
            _container.Children.Add(_entry);
            _container.Children.Add(_readonly);

            _hBox = new HorizontalBox();
            _button = new Button("Show Button 2");
            _button2 = new Button("Button 2");
            _button.Click += (sender, args) =>
            {
                _button2.Show();
            };
            _button2.Hide();
            _hBox.Children.Add(_button, true);
            _hBox.Children.Add(_button2);
            _container.Children.Add(_hBox);
        }

        private void OpenAnotherWindow(bool hasMenu)
        {
            var w = new Window("Another Window", 100, 100, hasMenu) {AllowMargins = true};
            if (hasMenu)
            {
                var b = new VerticalBox() {AllowPadding = true};
                b.Children.Add(new Entry());
                b.Children.Add(new Button("Button"));
                w.Child = b;
            }
            else
            {
                w.Child = new Page6("Page 6");
            }
            w.Show();
        }

        private void OpenAnotherDisabledWindow(bool hasMenu)
        {
            var w = new Window("Another Window", 100, 100, hasMenu) { AllowMargins = true };
            w.Enabled = false;
            w.Show();
        }
    }
}
