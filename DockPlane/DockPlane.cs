using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    public class DockPlane : Control
    {
        public DockPlane()
        {
        }

        public void AddForm(DockForm form)
        {
            Plane plane = new Plane(form);
            form.Tag = plane;
            Controls.Add(plane);
        }
        public void RemoveForm(DockForm form)
        {
            Controls.Remove(form.Tag as Control);
            form.Tag = null;
        }
    }
}
