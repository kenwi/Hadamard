using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public class SatelliteRepository : ISatelliteRepository
    {
        private  Lazy<List<Satellite>> _satellites;

        public SatelliteRepository()
        {
            _satellites = new Lazy<List<Satellite>>();

            new int[] { 25544, 36516, 33591, 29155, 28654, 25338 }.ToList().ForEach(id => this.Add(new Satellite(id)));
            GetAllSatellites().ToList().ForEach(satellite => satellite.Refresh());
        }

        public void Add(Satellite satellite)
        {
            _satellites.Value.Add(satellite);
        }

        public IEnumerable<Satellite> GetAllSatellites()
        {
            return _satellites.Value;
        }

        public Satellite GetSatellite(int id)
        {
            return _satellites.Value[id];
        }

        public void Update()
        {
            _satellites.Value.ForEach( s => s.Refresh() );
        }
    }
}
