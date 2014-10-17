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
        private Dockable activeDockable;

        public DockPlane()
        {
            MouseDown += DockPlane_MouseDown;
        }

        void DockPlane_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeDockable != null)
            {
                activeDockable.IsActive = false;
                activeDockable = null;
            }
        }

        public void AddForm(DockForm form)
        {
            AddForm(form, new Point());
        }
        public void AddForm(DockForm form, Point location)
        {
            Plane plane = new Plane(form);
            plane.Location = location;
            form.Plane = plane;
            Controls.Add(plane);
            RegisterListener(plane);
        }

        public void RemoveForm(DockForm form)
        {
            UnregisterListener(form.Plane);
            Controls.Remove(form.Plane);
            form.Plane = null;
        }

        private void RegisterListener(Dockable dockable)
        {
            dockable.Active += dockable_Active;
            dockable.Dragging += dockable_Dragging;
            dockable.Dragged += dockable_Dragged;
        }
        private void UnregisterListener(Dockable dockable)
        {
            dockable.Active -= dockable_Active;
            dockable.Dragging -= dockable_Dragging;
            dockable.Dragged -= dockable_Dragged;
        }

        void dockable_Active(Dockable sender, DockableEventArgs e)
        {
            if (activeDockable != null)
                activeDockable.IsActive = false;
            activeDockable = sender;
        }

        void dockable_Dragging(Dockable sender, DockableEventArgs e)
        {
        }
        void dockable_Dragged(Dockable sender, DockableEventArgs e)
        {
        }
    }
}
