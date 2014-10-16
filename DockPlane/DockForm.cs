using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DockPlane
{
    public class DockForm : Form
    {
        internal FormBorderStyle DesignFormBorderStyle;
        internal bool DesignTopMost;
        internal Font DesignFont;
        internal Size DesignSize;

        internal void BeginEmbed()
        {
            //save
            DesignTopMost = TopMost;
            DesignFont = Font;
            DesignFormBorderStyle = FormBorderStyle;
            DesignSize = Size;

            //set
            TopMost = false;
            FormBorderStyle = FormBorderStyle.None;

            //xset
            TopLevel = false;
            Visible = true;
        }

        internal void EndEmbed()
        {
            TopMost = DesignTopMost;
            Font = DesignFont;
            FormBorderStyle = DesignFormBorderStyle;
            Size = DesignSize;
        }

        internal void ResetFloatingSettings()
        {
            Size = DesignSize;
            Font = DesignFont;
        }
    }
}
