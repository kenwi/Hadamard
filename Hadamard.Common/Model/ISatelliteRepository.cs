using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public interface ISatelliteRepository
    {
        Satellite GetSatellite(int id);
        void Add(Satellite satellite);
        void Update();
        IEnumerable<Satellite> GetAllSatellites();
    }
}
