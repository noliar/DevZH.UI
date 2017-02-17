using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;

namespace Tester
{
    public class MainTabPage : TabPage
    {
        private Tab _mainTab;
        private HorizontalBox _mainBox;
        private MainWindow _mainWindow;

        private Page2 _page2;
        private Page1 _page1;
        private Page6 _page6;

        private Page15 _page15;

        public MainTabPage(string name, HorizontalBox main, MainWindow window) : base(name)
        {
            _mainBox = main;
            _mainWindow = window;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _mainTab = new Tab();
            this.Child = _mainTab;

            _page1 = new Page1("Page 1");
            _page2 = new Page2("Page 2", _mainTab, _mainBox, _page1);

            _page6 = new Page6("Page 6");

            _page15 = new Page15("Page 15", _mainWindow);

            _mainTab.Children.Add(_page1);
            _mainTab.Children.Add(_page2);
            _mainTab.Children.Add(_page6);
            _mainTab.Children.Add(_page15);
        }
    }
}
