using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;

namespace Tester
{
    public class Page1 : TabPage
    {
        private VerticalBox _container;
        private Entry _entry;
        private Form _form;
        private EntryBase _entryBase;
        private MultilineEntry _multilineEntry;
        private Group _group;
        private VerticalBox _vBox;
        private Button _button;

        public Page1(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _container = new VerticalBox();
            this.Child = _container;

            _entry = new Entry();
            _entry.TextChanged += (sender, args) =>
            {
                Console.WriteLine("onChanged()");
            };
            _container.Children.Add(_entry);

            _form = new Form();
            _entryBase = new PasswordEntry();
            _entryBase.TextChanged += (sender, args) =>
            {
                EntryChanged("password", args.Text);
            };
            _form.Children.Add("Password Entry", _entryBase);

            _entryBase = new SearchEntry();
            _entryBase.TextChanged += (sender, args) =>
            {
                EntryChanged("search", args.Text);
            };
            _form.Children.Add("Search Box", _entryBase);
            _container.Children.Add(_form, false);

            _group = new Group("Font Families");
            _container.Children.Add(_group, true);
            _vBox = new VerticalBox();
            _group.Child = _vBox;
            _multilineEntry = new MultilineEntry();
            _vBox.Children.Add(_multilineEntry, true);

            _button = new Button("List Font Families");
            _button.Click += (sender, args) =>
            {
                _multilineEntry.Text = "";
                var fonts = new FontFamilies();
                var num = fonts.Count;
                for (int i = 0; i < num; i++)
                {
                    var value = fonts[i];
                    _multilineEntry.Append(value + "\n");
                }
                fonts.Free();
            };
            _vBox.Children.Add(_button);
        }

        private void EntryChanged(string tag, string text)
        {
            Console.WriteLine($"{tag} entry changed: {text}");
        }
    }
}
