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
        public override bool Active
        {
            get { return base.Active; }
            internal set
            {
                base.Active = value;
                Invalidate();
            }
        }

        public MetroBorder(Color color)
        {
            Color = color;
            FormOffset = new Point(MetroThemeCfg.Thickness, MetroThemeCfg.Thickness);
            Orientation = BorderOrientation.Top;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, Width, Height);

            if (Active)
            {
                int x = 0, y = 0;
                int w = 0, h = 0;
                switch (Orientation)
                {
                    case BorderOrientation.Right:
                    case BorderOrientation.Left:
                        break;
                    case BorderOrientation.Bottom:
                        y = Height - MetroThemeCfg.Thickness;
                        goto case BorderOrientation.Top;
                    case BorderOrientation.Top:
                        w = Width;
                        h = MetroThemeCfg.Thickness;
                        break;
                }
                e.Graphics.FillRectangle(new SolidBrush(Color), x, y, w, h);
            }
        }
    }
}
