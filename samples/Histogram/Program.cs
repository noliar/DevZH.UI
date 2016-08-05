using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevZH.UI;

namespace Histogram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application();
            var window = new MainWindow("libui Histogram Gallery", 640, 480, true);
            window.AllowMargins = true;
            app.Run(window);
        }

        
    }
}
