using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    internal class PlaneCombination : Dockable
    {
        private List<Plane> planes = new List<Plane>();

        public override void DockTo(DockState ds)
        {
        }

        public override bool IsActive
        {
            get
            {
                throw new NotImplementedException();
            }
            internal set
            {
                throw new NotImplementedException();
            }
        }
    }
}
