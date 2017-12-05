using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevZH.UI;
using DevZH.UI.Drawing;

namespace Tester
{
    public class Page6 : TabPage
    {
        private class AreaHandler : IAreaHandler
        {
            private Page6 _owner;

            public AreaHandler(Page6 page6)
            {
                _owner = page6;
            }

            public void Draw(AreaBase area, ref AreaDrawParams param)
            {
                var index = _owner._which.SelectedIndex;
                DrawTests.RunDrawTest(index, ref param);
            }

            public void MouseEvent(AreaBase area, ref AreaMouseEvent mouseEvent)
            {
                Console.WriteLine($"mouse ({mouseEvent.X},{mouseEvent.Y}):({mouseEvent.AreaWidth},{mouseEvent.AreaHeight}) down:{mouseEvent.Down} up:{mouseEvent.Up} count:{mouseEvent.Count} mods:{mouseEvent.Modifiers} held:0x{mouseEvent.Held1To64:X}");
            }

            public void MouseCrossed(AreaBase area, bool left)
            {
                Console.WriteLine($"mouse crossed {left}");
            }

            public void DragBroken(AreaBase area)
            {
                Console.WriteLine("drag broken");
            }

            public bool KeyEvent(AreaBase area, ref AreaKeyEvent keyEvent)
            {
                byte[] k = {
                    (byte)'\'', keyEvent.Key,(byte)'\'',(byte)'\0'
                };
                if (keyEvent.Key == 0)
                {
                    k[0] = (byte) '0';
                    k[1] = (byte) '\0';
                    k[2] = (byte)'\0';
                }
                Console.WriteLine($"key key:{Encoding.UTF8.GetString(k)} extkey:{keyEvent.ExtKey} mod:{keyEvent.Modifier} mods:{keyEvent.Modifiers} up:{keyEvent.Up}");
                return _owner._swallowKeys.IsChecked;
            }
        }

        private VerticalBox _container;
        private HorizontalBox _hBox;
        private ComboBox _which;
        private CheckBox _swallowKeys;
        private Area _area;
        private Button _button;

        public Page6(string name) : base(name)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _container = new VerticalBox();
            this.Child = _container;

            _hBox = new HorizontalBox();
            _container.Children.Add(_hBox);

            _which = new ComboBox();
            DrawTests.PopulateComboboxWithTests(_which);
            _which.SelectedIndex = 0;
            _which.Selected += (sender, args) =>
            {
                _area.QueueReDrawAll();
            };
            _hBox.Children.Add(_which);

            _area = new Area(new AreaHandler(this));
            _container.Children.Add(_area, true);

            _hBox = new HorizontalBox();
            _container.Children.Add(_hBox);

            _swallowKeys = new CheckBox("Consider key events handled");
            _hBox.Children.Add(_swallowKeys, true);

            _button = new Button("Enable");
            _button.Click += (sender, args) =>
            {
                EnableArea(true);
            };
            _hBox.Children.Add(_button);

            _button = new Button("Disable");
            _button.Click += (sender, args) =>
            {
                EnableArea(false);
            };
            _hBox.Children.Add(_button);
        }

        private void EnableArea(bool enable)
        {
            _area.Enabled = enable;
        }
    }
}
