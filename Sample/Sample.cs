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
        TestForm testForm = new TestForm();

        public Sample()
        {
            InitializeComponent();

            dockPlane.AddForm(testForm);
        }
    }
}
