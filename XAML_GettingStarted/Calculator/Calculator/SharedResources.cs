using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public static class SharedResources
    {
        public static Color OpButtonBkColor
        {
            get { return Color.FromRgb(0, 0xa5, 0); }
        }

        public static double ButtonFontSize
        {
            get { return 36; }
        }
    }
}
