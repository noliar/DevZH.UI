using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevZH.UI.SimpleSample
{
    public class MainWindow : Window
    {
        private Tab _tab;
        private BasicControlsPage _basicControlsPage;
        private NumbersPage _numbersPage;
        private DataChoosersPage _dataChoosersPage;

        public MainWindow(string title = "DevZH.UI", int width = 500, int height = 200, bool hasMenubar = false) : base(title, width, height, hasMenubar)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this._tab = new Tab();
            this.Child = this._tab;

            this._basicControlsPage = new BasicControlsPage("Basic Controls") {AllowMargins = true};
            this._tab.Children.Add(this._basicControlsPage);

            this._numbersPage = new NumbersPage("Numbers and Lists") {AllowMargins = true};
            this._tab.Children.Add(this._numbersPage);

            this._dataChoosersPage = new DataChoosersPage("Data Choosers") {AllowMargins = true};
            this._tab.Children.Add(this._dataChoosersPage);
        }
    }
}
