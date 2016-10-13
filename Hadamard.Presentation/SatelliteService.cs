using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hadamard.Presentation;

namespace Hadamard
{
    public class SatelliteService : ISatelliteService
    {
        private readonly string _defaultNoradId = "00000";

        public Satellite GetSatelliteById(string Id)
        {
            return new Satellite();
        }
    }
}
