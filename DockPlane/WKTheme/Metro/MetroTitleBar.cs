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
    internal class MetroTitleBar : TitleBar
    {
        public override TitleBarOrientation Orientation
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

        public override string Title
        {
            get { return base.Title; }
            set
            {
                if (base.Title == value)
                    return;
                base.Title = value;
                FitTitleSize(CreateGraphics());
                Invalidate();
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

        public override bool Hover
        {
            get { return base.Hover; }
            internal set
            {
                base.Hover = value;
                Invalidate();
            }
        }

        public override int MinLength
        {
            get { return base.MinLength; }
            internal set
            {
                if (base.MinLength == value)
                    return;
                if (value > MaxLength)
                    throw new ArgumentException("minimum is greater than maximum");
                base.MinLength = value;
                switch (Orientation)
                {
                    case TitleBarOrientation.Left:
                    case TitleBarOrientation.Right:
                        Height = MathX.Clamp(Height, MinLength, MaxLength);
                        break;
                    case TitleBarOrientation.Top:
                    case TitleBarOrientation.Bottom:
                        Width = MathX.Clamp(Width, MinLength, MaxLength);
                        break;
                }
            }
        }
        public override int MaxLength
        {
            get { return base.MaxLength; }
            internal set
            {
                if (base.MaxLength == value)
                    return;
                if (MinLength > value)
                    throw new ArgumentException("minimum is greater than maximum");
                base.MaxLength = value;
                switch (Orientation)
                {
                    case TitleBarOrientation.Left:
                    case TitleBarOrientation.Right:
                        Height = MathX.Clamp(Height, MinLength, MaxLength);
                        break;
                    case TitleBarOrientation.Top:
                    case TitleBarOrientation.Bottom:
                        Width = MathX.Clamp(Width, MinLength, MaxLength);
                        break;
                }
            }
        }

        SizeF titleSize = new SizeF(0, 0);

        public MetroTitleBar(Color color)
        {
            Width = MetroThemeCfg.WidthSpace * 2;
            Height = MetroThemeCfg.HeightSpace * 2;
            Orientation = TitleBarOrientation.Top;
            Color = color;
        }

        private void FitTitleSize(Graphics graphics)
        {
            titleSize = graphics.MeasureString(Title, Font);

            switch (Orientation)
            {
                case TitleBarOrientation.Left:
                case TitleBarOrientation.Right:
                    Width = (int)titleSize.Height + MetroThemeCfg.HeightSpace * 2;
                    Height = MathX.Clamp((int)titleSize.Width + MetroThemeCfg.WidthSpace * 2, MinLength, MaxLength);
                    break;
                case TitleBarOrientation.Top:
                case TitleBarOrientation.Bottom:
                    Width = MathX.Clamp((int)titleSize.Width + MetroThemeCfg.WidthSpace * 2, MinLength, MaxLength);
                    Height = (int)titleSize.Height + MetroThemeCfg.HeightSpace * 2;
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color bgc = Color.White;
            int bgct = (Active ? (1 << 0) : 0) | (Hover ? (1 << 1) : 0);
            switch (bgct)
            {
                case 0://
                    bgc = Color.Gray; break;
                case 1://Active
                case 3://Active Hover
                    bgc = Color; break;
                case 2://Hover
                    bgc = ColorMath.LighterColor(Color); break;
            }

            FitTitleSize(e.Graphics);
            e.Graphics.FillRectangle(new SolidBrush(bgc), 0, 0, Width, Height);

            switch (Orientation)
            {
                case TitleBarOrientation.Left:
                    e.Graphics.TranslateTransform(
                        titleSize.Height + MetroThemeCfg.HeightSpace,
                        MetroThemeCfg.WidthSpace);
                    e.Graphics.RotateTransform(90);
                    break;
                case TitleBarOrientation.Right:
                    e.Graphics.TranslateTransform(
                        MetroThemeCfg.HeightSpace,
                        titleSize.Width + MetroThemeCfg.WidthSpace);
                    e.Graphics.RotateTransform(-90);
                    break;
                case TitleBarOrientation.Top:
                case TitleBarOrientation.Bottom:
                    e.Graphics.TranslateTransform(MetroThemeCfg.WidthSpace,
                        MetroThemeCfg.HeightSpace);
                    break;
            }
            e.Graphics.DrawString(Title, Font, Brushes.Black, 0, 0);
        }
    }
}
