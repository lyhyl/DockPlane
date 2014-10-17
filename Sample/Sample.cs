using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Sample : Form
    {
        TestForm testForm0 = new TestForm();
        TestForm testForm1 = new TestForm();

        public Sample()
        {
            InitializeComponent();

            dockPlane.AddForm(testForm0);
            dockPlane.AddForm(testForm1);
        }
    }
}
