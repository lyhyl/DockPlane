using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPlane
{
    static class MathX
    {
        public static int Clamp(int val, int min, int max)
        {
            return Math.Min(Math.Max(val, min), max);
        }
    }
}
