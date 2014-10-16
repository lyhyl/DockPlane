using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    interface Draggable
    {
        void BeginDrag(Control target, Point location);
        void EndDrag();
    }

    interface DrawablePlane
    {
        void Draw();
        string Title { set; get; }
    }
}
