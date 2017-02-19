using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevZH.UI.Drawing;

namespace DevZH.UI.SimpleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application(false);
            var window = new MainWindow("libui Control Gallery", 640, 480, true);
            window.AllowMargins = true;
            app.Run(window);
        }
    }
}
