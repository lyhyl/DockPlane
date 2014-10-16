using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    internal class Dockable : Control, Draggable
    {
        private Point prevMouseLocation;
        private Control target;
        public void BeginDrag(Control ctrl, Point location)
        {
            prevMouseLocation = PointToScreen(location);
            target = ctrl;
            target.MouseMove += DoDrag;
        }

        private void DoDrag(object sender, MouseEventArgs e)
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
    }
}
