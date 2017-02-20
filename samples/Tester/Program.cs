using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;

namespace Tester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application(false);
            InitMenus(app);
            var window = new MainWindow("Main Window", 320, 240, true);
            window.AllowMargins = true;
			// libui bug for gtk3: https://github.com/andlabs/libui/issues/183
			//window.StartPosition = WindowStartPosition.CenterScreen;
			app.Run(window);
        }

        private static void InitMenus(Application app)
        {
            var file = new Menu("File");
            file.Add("New");
            file.Add("Open");
            file.AddSeparator();
            var shouldQuitItem = file.Add("Should Quit", MenuItemTypes.Check);
            var quitItem = file.Add(MenuItemTypes.Quit);
            app.OnShouldExit += (sender, args) =>
            {
                args.Cancel = !shouldQuitItem.IsChecked;
            };

            var edit = new Menu("Edit");
            var undo = edit.Add("Undo");
            undo.Enabled = false;
            edit.AddSeparator();
            var checkItem = edit.Add("Check Me\tTest", MenuItemTypes.Check);
            edit.Add("A&ccele&&rator T_es__t");
            var prefsItem = edit.Add(MenuItemTypes.Preferences);

            var test = new Menu("Test");
            var enabledItem = test.Add("Enable Below Item", MenuItemTypes.Check);
            enabledItem.IsChecked = true;
            var enableThisItem = test.Add("This Will Be Enabled");
            enabledItem.Click += (sender, args) =>
            {
                EnableItemTest(enabledItem, enableThisItem);
            };
            test.Add("Force Above Checked", MenuItemTypes.Common, (obj) =>
            {
                enabledItem.IsChecked = true;
            });
            test.Add("Force Above Unchecked", MenuItemTypes.Common, (obj) =>
            {
                enabledItem.IsChecked = false;
            });
            test.AddSeparator();
            test.Add("What Window?", MenuItemTypes.Common, (obj) =>
            {
                Console.WriteLine($"menu item clicked on window {obj.ToString("X")}");
            });

            var more = new Menu("More Tests");
            var quitEnabledItem = more.Add("Quit Item Enabled", MenuItemTypes.Check);
            quitEnabledItem.IsChecked = true;
            var prefsEnabledItem = more.Add("Preferences Item Enabled", MenuItemTypes.Check);
            prefsEnabledItem.IsChecked = true;
            var aboutEnabledItem = more.Add("About Item Enabled", MenuItemTypes.Check);
            aboutEnabledItem.IsChecked = true;
            more.AddSeparator();
            var checkEnabledItem = more.Add("Check Me Item Enabled", MenuItemTypes.Check);
            checkEnabledItem.IsChecked = true;

            var multi = new Menu("Multi");
            multi.AddSeparator();
            multi.AddSeparator();
            multi.Add("Item && Item && Item");
            multi.AddSeparator();
            multi.AddSeparator();
            multi.Add("Item __ Item __ Item");
            multi.AddSeparator();
            multi.AddSeparator();

            var help = new Menu("Help");
            help.Add("Help");
            var aboutItem = help.Add(MenuItemTypes.About);

            quitEnabledItem.Click += (sender, args) =>
            {
                EnableItemTest(quitEnabledItem, quitItem);
            };

            prefsEnabledItem.Click += (sender, args) => EnableItemTest(prefsEnabledItem, prefsItem);
            aboutEnabledItem.Click += (sender, args) => EnableItemTest(aboutEnabledItem, aboutItem);
            checkEnabledItem.Click += (sender, args) => EnableItemTest(checkEnabledItem, checkItem);
        }

        private static void EnableItemTest(MenuItem item, MenuItem data)
        {
            data.Enabled = item.IsChecked;
        }
    }
}
