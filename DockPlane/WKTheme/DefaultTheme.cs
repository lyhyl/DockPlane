using DockPlane.Exterior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPlane.WKTheme
{
    public sealed class DefaultTheme
    {
        private static Theme _default = null;
        public static Theme Default
        {
            set { _default = value; }
            get
            {
                if (_default == null)
                    _default = new Metro.MetroTheme();
                return _default;
            }
        }
    }
}
