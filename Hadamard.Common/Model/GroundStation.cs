using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common.Model
{
    public class GroundStation
    {
        public float Id { get; set; }
        public float Latitude { get; set; }
        public float Longtitude { get; set; }

        /// <summary>
        /// Meters above sea level
        /// </summary>
        public float MASL { get; set; }
    }
}
