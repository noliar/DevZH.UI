using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI.Events;
using DevZH.UI.Interop;
using DevZH.UI.Utils;

namespace DevZH.UI
{
    public class Menu : Control
    {
        public List<MenuItem> Items { get; }
        public Menu(string name)
        {
            ControlHandle = NativeMethods.NewMenu(StringUtil.GetBytes(name));
            Items = new List<MenuItem>();
        }

        public MenuItem Add(string name, MenuItemTypes type = MenuItemTypes.Common, Action<IntPtr> click = null)
        {
            ControlHandle handler = null;
            var nb = StringUtil.GetBytes(name);
            switch (type)
            {
                case MenuItemTypes.Common:
                    handler = NativeMethods.MenuAppendItem(ControlHandle, nb);
                    break;
                case MenuItemTypes.Check:
                    handler = NativeMethods.MenuAppendCheckItem(ControlHandle, nb);
                    break;
                case MenuItemTypes.Quit:
                    handler = NativeMethods.MenuAppendQuitItem(ControlHandle);
                    break;
                case MenuItemTypes.Preferences:
                    handler = NativeMethods.MenuAppendPreferencesItem(ControlHandle);
                    break;
                case MenuItemTypes.About:
                    handler = NativeMethods.MenuAppendAboutItem(ControlHandle);
                    break;
            }
            var item = new MenuItem(handler, type);
            if (click != null)
            {
                item.Click += (sender, e) =>
                {
                    var args = e as DataEventArgs;
                    if (args != null)
                    {
                        click(args.Data);
                    }
                };
            }
            Items.Add(item);
            return item;
        }

        public MenuItem Add(MenuItemTypes type = MenuItemTypes.Quit, Action<IntPtr> click = null)
        {
            ControlHandle handler = null;
            switch (type)
            {
                case MenuItemTypes.Quit:
                    handler = NativeMethods.MenuAppendQuitItem(ControlHandle);
                    break;
                case MenuItemTypes.Preferences:
                    handler = NativeMethods.MenuAppendPreferencesItem(ControlHandle);
                    break;
                case MenuItemTypes.About:
                    handler = NativeMethods.MenuAppendAboutItem(ControlHandle);
                    break;
                default:
                    throw new InvalidOperationException("Cannot add Common or Check Menu without name");
            }
            var item = new MenuItem(handler, type);
            if (click != null)
            {
                item.Click += (sender, e) =>
                {
                    var args = e as DataEventArgs;
                    if (args != null)
                    {
                        click(args.Data);
                    }
                };
            }
            Items.Add(item);
            return item;
        }

        public void AddSeparator()
        {
            NativeMethods.MenuAppendSeparator(ControlHandle);
        }
    }
}
