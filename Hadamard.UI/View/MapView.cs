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
using Hadamard.Common.Model;

namespace Hadamard.UI.View
{
    public partial class MapView : Form, IMapView
    {
        private Point _mouseClickMove;
        private IList<Satellite> _satelliteList;

        public IMapPresenter Presenter { get; set; }

        public IList<Satellite> SatelliteList
        {
            get { return _satelliteList; }
            set { _satelliteList= value; }
        }

        public void UpdateGUI()
        {
            drawSatellites();
        }

        public MapView()
        {
            InitializeComponent();

            worldMap.MouseMove += (s, e) => DrawOverlay();
            worldMap.Resize += (s, e) => DrawOverlay();
            worldMap.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    _mouseClickMove = e.Location;
            };
            worldMap.MouseMove += (s, e) =>
            {
                if (e.Button != MouseButtons.Left)
                    return;
                Point dt = new Point(e.Location.X - _mouseClickMove.X, e.Location.Y - _mouseClickMove.Y);
                panel1.AutoScrollPosition = new Point(-panel1.AutoScrollPosition.X - dt.X, -panel1.AutoScrollPosition.Y - dt.Y);
            };
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

        private void drawSatellites()
        {
            var graphics = worldMap.CreateGraphics();
            var mapWidth = worldMap.Image.Height;
            var mapHeight = worldMap.Image.Width;

            SatelliteList?.ToList().ForEach(satellite =>
            {
                var merc = latLongToMerc(satellite.Latitude, satellite.Longitude, mapWidth, mapHeight);
                drawSquare(merc);
            });
        }

        private void drawLatitude()
        {
            var graphics = worldMap.CreateGraphics();
            var mapWidth = worldMap.Image.Height;
            var mapHeight = worldMap.Image.Width;

            var longitude = 0;
            var list = Enumerable.Range(0, 90).Where((x, i) => i % 10 == 0).ToList();
            list.ForEach(latitude =>
            {
                var merc = latLongToMerc(latitude, longitude, mapWidth, mapHeight);
                drawSquare(merc);
            });

            list.ForEach(latitude =>
            {
                latitude *= -1;
                var merc = latLongToMerc(latitude, longitude, mapWidth, mapHeight);
                drawSquare(merc);
            });
        }

        private void drawLongitude()
        {
            var graphics = worldMap.CreateGraphics();
            var mapWidth = worldMap.Image.Height;
            var mapHeight = worldMap.Image.Width;

            var latitude = 0;
            var list =  Enumerable.Range(0, 181).Where((x, i) => i % 10 == 0).ToList();
            list.ForEach(longitude =>
            {
                var merc = latLongToMerc(latitude, longitude, mapWidth, mapHeight);
                drawSquare(merc);
            });
            list.ForEach(longitude =>
            {
                longitude *= -1;
                var merc = latLongToMerc(latitude, longitude, mapWidth, mapHeight);
                drawSquare(merc);
            });
        }

        private void drawSquare(PointF position)
        {
            var graphics = worldMap.CreateGraphics();
            graphics.DrawRectangle(new Pen(Color.Red), (float)(position.X - 2.5), (float)(position.Y - 2.5), 5, 5);
        }

        private PointF latLongToMerc(double latitude, double longitude, int width, int height)
        {
            double pixelsPerDegree = (double)width / 360;
            double x = width / 2 +  pixelsPerDegree * longitude;
            double latRad = (latitude * Math.PI) / 180;
            double mercN = Math.Log(Math.Tan((Math.PI / 4) + (latRad / 2)));
            double y = (height / 2) - (width * mercN / (2 * Math.PI));

            return new PointF((float)x, (float)y);
        }

        private void DrawOverlay()
        {
            var width = worldMap.Image.Width;
            var height = worldMap.Image.Height;

            //drawSquare(latLongToMerc(70.37, 31.13, width, height));

            drawLatitude();
            drawLongitude();
        }
    }
}