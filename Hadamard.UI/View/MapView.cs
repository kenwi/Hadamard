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

            worldMap.MouseMove += (s, e) => DrawOverlay();
            worldMap.Resize += (s, e) => DrawOverlay();
            DrawOverlay();
        }
        
        public void Run()
        {
            Application.Run(this);
        }

        private double projDegToRad(float deg)
        {
            return (deg / 180.0 * Math.PI);
        }

        private double projRadToDeg(float rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private void DrawOverlay()
        {
            var width = worldMap.ClientRectangle.Width;
            var height = worldMap.ClientRectangle.Height;
            /*
            var lat = 70;
            var lon = 30;
            var lon0 = 0;

            var sm_a = 6378137.0;
            var sm_b = 6356752.314;

            var latitude = projDegToRad(lat);
            var longitude = projDegToRad(lon);

                        
            var x = sm_a * (lon - lon0);
            var y = sm_a * Math.Log(Math.Sin(lat) + 1) / Math.Cos(lat);
            */
            /*
            var centerX = width / 2;
            var centerY = height / 2;

            var graphics = worldMap.CreateGraphics();
            graphics.DrawRectangle(new Pen(Color.Red), (float)(centerX - 2.5), (float)(centerY - 2.5), 5, 5);

            var latitude = 70;
            var longitude = 30;

            var x = (longitude + 180) * (width / 360);
            var latRad = latitude * Math.PI / 180;
            var mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));
            var y = (height / 2) - (width * mercN / (2 * Math.PI));
            graphics.DrawRectangle(new Pen(Color.Red), (float)(x - 2.5), (float)(y - 2.5), 5, 5);
            */
            
            for (int i = -89; i < 89; i += 10)
            {
                for (int j = -89; j < 89; j += 10)
                {
                    var latitude = i;
                    var longtitude = j;
                    var mapWidth = worldMap.Width;
                    var mapHeight = worldMap.Height;

                    var x = (longtitude + 180) * (mapWidth / 360);
                    var latRad = latitude * Math.PI / 180;
                    var mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));
                    var y = (mapHeight / 2) - (mapWidth * mercN / (2 * Math.PI));

                    var graphics = worldMap.CreateGraphics();
                    graphics.DrawRectangle(new Pen(Color.Red), (float)(x - 2.5), (float)(y - 2.5), 5, 5);
                }
            }
        }
    }
}
