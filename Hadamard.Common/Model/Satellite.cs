using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public class Satellite
    {
        private int _id;
        private string _latitude, _longtitude, _azimuth, _elevation;

        public int Id => _id;
        public string Latitude => _latitude;
        public string Longitude => _longtitude;
        public string Azimuth => _azimuth;
        public string Elevation => _elevation;

        public Satellite() { }

        public Satellite(int id)
        {
            _id = id;
        }

        private static Satellite GetSatelliteFromId(int id)
        {
            var sat = new Satellite(id);
            //sat.Refresh();

            return sat;
        }

        public void Refresh()
        {
            using (var webClient = new WebClient())
            {
                var downloadString = $"http://www.n2yo.com/sat/instant-tracking.php?s={Id}&hlat=70.07436&hlng=29.74872&d=300&r=139203158747.09302&tz=GMT+02:00&O=n2yocom&rnd_str=5b53a06e197ed03f2075e8c1d85fa6d6";
                var response = webClient.DownloadString(downloadString);
                dynamic model = JsonConvert.DeserializeObject(response);
                
                _id = model[0].id;
                _latitude = model[0].pos.First.d.ToString().Split('|')[0];
                _longtitude = model[0].pos.First.d.ToString().Split('|')[1];
                _azimuth = model[0].pos.First.d.ToString().Split('|')[2];
                _elevation = model[0].pos.First.d.ToString().Split('|')[3];
            }
        }
    }
}
