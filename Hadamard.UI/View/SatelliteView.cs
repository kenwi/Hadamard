using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hadamard.Common.Model;
using Hadamard.UI.Presenter;

namespace Hadamard.UI.View
{
    public partial class SatelliteView : Form, ISatelliteView
    {
        public IList<Satellite> SatelliteList => Presenter.GetAllSatellites();
        public event EventHandler Initialize;
        public event EventHandler UpdateGui;

        private readonly SatellitePresenter Presenter;

        public SatelliteView()
        {
            Presenter = new SatellitePresenter(this, new SatelliteRepository());
            InitializeComponent();
            Initialize?.Invoke(this, new EventArgs());

            dataGridView1.DataSource = SatelliteList;
        }
    }
}
