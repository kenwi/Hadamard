using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public class OnSatelliteValuesUpdatedArgs : EventArgs
    {
        private readonly Satellite _satellite;

        public OnSatelliteValuesUpdatedArgs(Satellite satellite)
        {
            _satellite = satellite;
        }

        public Satellite Satellite => _satellite;
    }

    public class OnSatelliteAddedArgs : EventArgs
    {
        private readonly Satellite _satellite;

        public OnSatelliteAddedArgs(Satellite satellite)
        {
            _satellite = satellite;
        }

        public Satellite Satellite => _satellite;
    }

    public class SatelliteRepository : ISatelliteRepository
    {
        private readonly Lazy<List<Satellite>> _satellites;
        private readonly Task _satelliteUpdater;

        public event EventHandler<OnSatelliteValuesUpdatedArgs> OnSatelliteValuesUpdated;
        public event EventHandler<OnSatelliteAddedArgs> OnSatelliteAdded;
        public int Count => _satellites.Value.Count;

        public SatelliteRepository()
        {
            _satellites = new Lazy<List<Satellite>>();
            createDefaultTrackedSatellites();

            _satelliteUpdater = Task.Run( () =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    if (Count <= 0)
                        continue;

                    var sats =
                      GetAllSatellites()
                          .Where(
                              satellite =>
                                  new TimeSpan(DateTime.Now.Ticks - satellite.LastUpdated.Ticks).TotalSeconds >
                                  satellite.AutoUpdateInterval);

                    sats.ToList().ForEach(satellite => satellite.Update());
                }
            });
        }

        private void createDefaultTrackedSatellites()
        {
            new int[] { 25544, 36516, 33591, 29155, 28654, 25338 }.ToList().ForEach(id => this.Add(new Satellite(id)));
        }

        public void Add(Satellite satellite)
        {
            if (GetSatelliteById(satellite.Id) != null)
                throw new Exception($"Satellite with id '{satellite.Id}' is already tracked");

            satellite.AutoUpdateInterval = 5;
            satellite.Index = Count;
            satellite.OnSatelliteValuesUpdated += (s, e) => OnSatelliteValuesUpdated?.Invoke(this, new OnSatelliteValuesUpdatedArgs(e.Satellite));

            _satellites.Value.Add(satellite);
            OnSatelliteAdded?.Invoke(this, new OnSatelliteAddedArgs(satellite));
        }

        public void Add(Satellite satellite, bool updateData)
        {
            Add(satellite);

            if(updateData)
                satellite.Refresh();
        }

        public IEnumerable<Satellite> GetAllSatellites()
        {
            return _satellites?.Value;
        }

        public Satellite GetSatelliteByIndex(int index)
        {
            return _satellites.Value.Find(satellite => satellite.Index == index);
        }

        public Satellite GetSatelliteById(int id)
        {
            return _satellites.Value.Find(satellite => satellite.Id == id);
        }

        public void UpdateAll()
        {
            _satellites.Value.ForEach( satellite =>
            {
                satellite.Refresh();
                OnSatelliteValuesUpdated?.Invoke(this, new OnSatelliteValuesUpdatedArgs(satellite));
            });
        }
    }
}
