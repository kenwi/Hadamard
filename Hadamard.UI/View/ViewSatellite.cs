using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hadamard.Common;
using Hadamard.Common.Model;

namespace Hadamard.UI.View
{
    public partial class ViewSatellite : Form
    {
        public Satellite Satellite { get; set; }

        public ViewSatellite()
        {
            InitializeComponent();
        }
    }
}
