using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane.Exterior
{
    public abstract class TitleBar : Control
    {
        public virtual TitleBarOrientation Orientation { set; get; }
        public virtual bool Active { internal set; get; }
        public virtual bool Hover { internal set; get; }
        public virtual int MinLength { internal set; get; }
        public virtual int MaxLength { internal set; get; }
        public virtual string Title { set; get; }
        public Color Color { protected set; get; }

        public TitleBar()
        {
            MinLength = 0;
            MaxLength = int.MaxValue;
        }
    }

    public enum TitleBarOrientation
    {
        Left, Right, Top, Bottom
    }
}
