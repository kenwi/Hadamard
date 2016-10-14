using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hadamard.UI.Presenter;

namespace Hadamard.UI.View
{
    public partial class MapView : Form, IMapView
    {
        public IMapPresenter Presenter { get; set; }

        public MapView()
        {
            InitializeComponent();

            worldMap.MouseHover += WorldMap_MouseHover;
        }

        private void WorldMap_MouseHover(object sender, EventArgs e)
        {
            
        }

        public void Run()
        {
            Application.Run(this);
        }

        private void worldMap_MouseMove(object sender, MouseEventArgs e)
        {
            var latitude = 70.37;
            var longtitude = 31.08;
            var mapWidth = worldMap.Width;
            var mapHeight = worldMap.Height;

            var x = (longtitude + 180) * (mapWidth / 360);
            var latRad = latitude * Math.PI / 180;
            var mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));
            var y = (mapHeight / 2) - (mapWidth * mercN / (2 * Math.PI));

            var graphics = worldMap.CreateGraphics();
            graphics.DrawRectangle(new Pen(Color.Red), (float)(x-2.5), (float)(y-2.5), 5, 5);

            toolStripStatusLabel1.Text = $"X: {e.X} Y: {e.Y} x: {x} y: {y}";
        }
    }
}
