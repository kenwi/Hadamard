using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public interface IGroundStationRepository
    {
        void Add(GroundStation groundStation);
        IEnumerable<GroundStation> All();
        GroundStation Single(int id);
    }
}
