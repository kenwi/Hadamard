﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public class Satellite
    {
        private int _id;
        private float _latitude, _longtitude, _azimuth, _elevation;

        public int AutoUpdateInterval { get; set; }
        public DateTime LastUpdated { get; set; }

        public int Id => _id;
        public int Index { get; set; }
        public float Latitude => _latitude;
        public float Longitude => _longtitude;
        public float Azimuth => _azimuth;
        public float Elevation => _elevation;
        
        public event EventHandler<OnSatelliteValuesUpdatedArgs> OnSatelliteValuesUpdated;

        public Satellite() { }

        public Satellite(int id)
        {
            _id = id;
        }

        private static Satellite GetSatelliteFromId(int id)
        {
            return new Satellite(id);
        }

        public void Update()
        {
            Refresh();
            OnSatelliteValuesUpdated?.Invoke(this, new OnSatelliteValuesUpdatedArgs(this));
        }

        public void Refresh()
        {
            using (var webClient = new WebClient())
            {
                var downloadString = $"http://www.n2yo.com/sat/instant-tracking.php?s={Id}&hlat=70.07436&hlng=29.74872&d=300&r=139203158747.09302&tz=GMT+02:00&O=n2yocom&rnd_str=5b53a06e197ed03f2075e8c1d85fa6d6";
                var response = webClient.DownloadString(downloadString);

                dynamic model = JsonConvert.DeserializeObject(response);
                _id = model[0].id;
                if (model[0].pos.First == null)
                    throw new Exception($@"Could not find satellite with id '{_id}'");

                try
                {
                    var dataLine = model[0].pos.First.d.Value.ToString().Split('|');
                    _latitude = float.Parse(dataLine[0], CultureInfo.InvariantCulture.NumberFormat);
                    _longtitude = float.Parse(dataLine[1], CultureInfo.InvariantCulture.NumberFormat);
                    _azimuth = float.Parse(dataLine[2], CultureInfo.InvariantCulture.NumberFormat);
                    _elevation = float.Parse(dataLine[3], CultureInfo.InvariantCulture.NumberFormat);
                    LastUpdated = DateTime.Now;
                }
                catch (Exception e)
                {
                    Trace.WriteLine($"Satellite data conversion error: {e.Message}");
                    //throw new Exception($"Satellite data conversion error: {e.Message}");
                    return;
                }
            }



            //Task.Run(() =>
            //           {
            /*using (var webClient = new WebClient())
            {
                var downloadString = $"http://www.n2yo.com/sat/instant-tracking.php?s={Id}&hlat=70.07436&hlng=29.74872&d=300&r=139203158747.09302&tz=GMT+02:00&O=n2yocom&rnd_str=5b53a06e197ed03f2075e8c1d85fa6d6";
                var response = webClient.DownloadString(downloadString);

                dynamic model = JsonConvert.DeserializeObject(response);
              */
            /*
                _id = model[0].id;
                if (model[0].pos.First == null)
                    throw new Exception($@"Could not find satellite with id '{_id}'");



                _latitude = double.Parse(model[0].pos.First.d.ToString().Split('|')[0]);
                _longtitude = double.Parse(model[0].pos.First.d.ToString().Split('|')[1]);
                _azimuth = double.Parse(model[0].pos.First.d.ToString().Split('|')[2]);
                _elevation = double.Parse(model[0].pos.First.d.ToString().Split('|')[3]);
            }*/
            //}).Wait();
        }
    }
}
