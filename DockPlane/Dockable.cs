using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    public abstract class Dockable : Control, Draggable
    {
        private Point prevMouseLocation;
        private Control target;

        public bool IsCombined
        {
            protected internal set;
            get;
        }

        private DockState _state = DockState.Floating;
        public DockState State
        {
            protected set { _state = value; }
            get { return _state; }
        }

        public event DockableEventHandler Dragging;
        public event DockableEventHandler Dragged;
        public event DockableEventHandler Active;

        public abstract bool IsActive { internal set; get; }

        public void BeginDrag(Control ctrl, Point location)
        {
            prevMouseLocation = PointToScreen(location);
            target = ctrl;
            target.MouseMove += DoDrag;
        }

        protected void DoDrag(object sender, MouseEventArgs e)
        {
            Point cp = PointToScreen(e.Location);
            Location += new Size(cp.X - prevMouseLocation.X, cp.Y - prevMouseLocation.Y);
            prevMouseLocation = cp;
        }

        public void EndDrag()
        {
            target.MouseMove -= DoDrag;
            target = null;
        }

        /// <summary>
        /// rasie plane[combination] Dragging event
        /// </summary>
        protected void OnDragging()
        {
            if(Dragging!=null)
            {
                DockableEventArgs e = new DockableEventArgs();
                Dragging(this, e);
            }
        }

        /// <summary>
        /// rasie plane[combination] Dragged event
        /// </summary>
        protected void OnDragged()
        {
            if(Dragged!=null)
            {
                DockableEventArgs e = new DockableEventArgs();
                Dragged(this, e);
            }
        }

        /// <summary>
        /// rasie plane[combination] Active event
        /// </summary>
        protected void OnActive()
        {
            if(Active!=null)
            {
                DockableEventArgs e = new DockableEventArgs();
                Active(this, e);
            }
        }

        public abstract void DockTo(DockState ds);
    }

    public class DockableEventArgs
    {
        public DockableEventArgs()
        {
        }
    }
    public delegate void DockableEventHandler(Dockable sender, DockableEventArgs e);
}
