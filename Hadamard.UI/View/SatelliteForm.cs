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
    public partial class SatelliteForm : Form, ISatelliteView
    {
        public ISatellitePresenter Presenter { private get; set; }

        public IList<Satellite> SatelliteList
        {
            get { return (IList<Satellite>) this.satelliteListBox.DataSource; }
            set { this.satelliteListBox.DataSource = value; }
        }

        public int SelectedSatellite
        {
            get { return this.satelliteListBox.SelectedIndex; }
            set { this.satelliteListBox.SelectedIndex = value; }
        }

        public int Id
        {
            get { return int.Parse(this.noradIdTextBox.Text); }
            set { this.noradIdTextBox.Text = value.ToString(); }
        }

        public string Latitude
        {
            get { return this.latitudeTextBox.Text; }
            set { this.latitudeTextBox.Text = value; }
        }

        public string Longtitude
        {
            get { return this.longtitudeTextBox.Text; }
            set { this.longtitudeTextBox.Text = value; }
        }

        public string Elevation
        {
            get { return this.elevationTextBox.Text; }
            set { this.elevationTextBox.Text = value; }
        }

        public SatelliteForm()
        {
            InitializeComponent();            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var satellite = new Satellite(Id);
            Presenter.AddSatellite(satellite);
        }

        private void satelliteListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Presenter.UpdateSatelliteListView(satelliteListBox.SelectedIndex);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Presenter.ShowSatelliteList();
        }

        public void Run()
        {
            Application.Run(this);
        }
    }
}
