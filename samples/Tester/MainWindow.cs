using System;
using DevZH.UI;

namespace Tester
{
    public class MainWindow : Window
    {
        private HorizontalBox _mainBox;
        private Tab _outerTab;
        private MainTabPage _mainTabPage;

        public MainWindow(string title, int width = 500, int height = 200, bool hasMenubar = false) : base(title, width, height, hasMenubar)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            _mainBox = new HorizontalBox();
            this.Child = _mainBox;

            _outerTab = new Tab();
            _mainBox.Children.Add(_outerTab, true);

            _mainTabPage = new MainTabPage("Pages 1-5", _mainBox);
            _outerTab.Children.Add(_mainTabPage);
        }

        
    }
}