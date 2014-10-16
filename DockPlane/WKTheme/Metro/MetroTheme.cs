using DockPlane.Exterior;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPlane.WKTheme.Metro
{
    public class MetroTheme : Theme
    {
        private Color color = Color.CornflowerBlue;
        public MetroTheme() { }
        public MetroTheme(Color color) { this.color = color; }

        public Border CreateBorder()
        {
            Border be = new MetroBorder(color);
            return be;
        }

        public TitleBar CreateTitleBar()
        {
            TitleBar tb = new MetroTitleBar(color);
            return tb;
        }
    }
}
