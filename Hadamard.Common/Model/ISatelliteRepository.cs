using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public interface ISatelliteRepository
    {
        void Add(Satellite satellite);
        void Add(Satellite satellite, bool updateData);
        void UpdateAll();

        IEnumerable<Satellite> GetAllSatellites();
        Satellite GetSatelliteByIndex(int index);
        Satellite GetSatelliteById(int id);

        event EventHandler<OnSatelliteValuesUpdatedArgs> OnSatelliteValuesUpdated;
        event EventHandler<OnSatelliteAddedArgs> OnSatelliteAdded;
        int Count { get; }
    }
}
