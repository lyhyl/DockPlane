using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPlane.Exterior
{
    public interface Theme
    {
        Border CreateBorder();
        TitleBar CreateTitleBar();
    }
}
