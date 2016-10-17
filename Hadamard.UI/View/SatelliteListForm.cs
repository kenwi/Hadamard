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
    public partial class SatelliteListForm : Form, ISatelliteView
    {
        public SatelliteListForm()
        {
            InitializeComponent();
        }

        public string Elevation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Latitude
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string Longtitude
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ISatellitePresenter Presenter { private get; set; }

        public IList<Satellite> SatelliteList
        {
            get
            {
                return (IList<Satellite>)this.dataGridView1.DataSource;
            }

            set
            {
                this.dataGridView1.DataSource = value;
            }
        }

        private int _selectedSatellite;
        public int SelectedSatellite
        {
            get
            {
                return _selectedSatellite;
            }

            set
            {
                _selectedSatellite = value;
            }
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}
