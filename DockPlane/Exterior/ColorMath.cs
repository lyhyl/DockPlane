using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPlane.Exterior
{
    internal static class ColorMath
    {
        public static Color LighterColor(Color col)
        {
            return ColorMath.LighterColor(col, 16);
        }
        public static Color LighterColor(Color col, int step)
        {
            return Color.FromArgb(Math.Min((int)col.R + step, 255), Math.Min(col.G + step, 255), Math.Min(col.B + step, 255));
        }

        public static Color DrakerColor(Color col)
        {
            return ColorMath.DrakerColor(col, 16);
        }
        public static Color DrakerColor(Color col, int step)
        {
            return Color.FromArgb(Math.Max((int)col.R - step, 0), Math.Max(col.G - step, 0), Math.Max(col.B - step, 0));
        }

        public static Color OppositeColor(Color col)
        {
            return Color.FromArgb(255 - col.R, 255 - col.G, 255 - col.B);
        }
    }
}
