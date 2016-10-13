using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hadamard.UI.Presenter;
using Hadamard.Common.Model;

namespace Hadamard.UI.View
{
    public interface ISatelliteView
    {
        IList<Satellite> SatelliteList { get; set; }
        ISatellitePresenter Presenter { set; }

        int SelectedSatellite { get; set; }
        int Id { get; set; }
        
        string Latitude { get; set; }
        string Longtitude { get; set; }
        string Elevation { get; set; }

        void Run();
    }
}
