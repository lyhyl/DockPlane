using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane.Exterior
{
    public abstract class Border : Control
    {
        public virtual BorderOrientation Orientation { set; get; }
        public virtual bool Active { internal set; get; }
        public virtual bool Hover { internal set; get; }
        public virtual Size FormSize { set; get; }
        public Color Color { protected set; get; }
        public Point FormOffset { protected set; get; }

        public Border() { }
    }
    public enum BorderOrientation
    {
        Left, Right, Top, Bottom
    }
}
