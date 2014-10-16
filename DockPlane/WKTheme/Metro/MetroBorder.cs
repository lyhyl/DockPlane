using DockPlane.Exterior;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane.WKTheme.Metro
{
    internal class MetroBorder : Border
    {
        public override BorderOrientation Orientation
        {
            get { return base.Orientation; }
            set
            {

                if (base.Orientation == value)
                    return;
                base.Orientation = value;
                Invalidate();
            }
        }

        public override Size FormSize
        {
            get { return base.FormSize; }
            set
            {
                if (base.FormSize == value)
                    return;
                base.FormSize = value;
                Width = FormSize.Width + MetroThemeCfg.Thickness * 2;
                Height = FormSize.Height + MetroThemeCfg.Thickness * 2;
            }
        }

        public MetroBorder(Color color)
        {
            Color = color;
            FormOffset = new Point(MetroThemeCfg.Thickness, MetroThemeCfg.Thickness);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color), 0, 0, Width, Height);
            switch (Orientation)
            {
                case BorderOrientation.Left:
                    e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, MetroThemeCfg.Thickness,
                        Width, Height - MetroThemeCfg.Thickness);
                    break;
                case BorderOrientation.Right:
                    break;
                case BorderOrientation.Top:
                    break;
                case BorderOrientation.Bottom:
                    break;
            }
        }
    }
}
