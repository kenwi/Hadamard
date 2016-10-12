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
        }

        public Satellite GetSatellite(int id)
        {
            return _satellites.Value[id];
        }
    }
}
