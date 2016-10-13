using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadamard.Common.Model;

namespace Hadamard.UI.Presenter
{
    public interface ISatellitePresenter
    {
        void UpdateSatelliteListView();
        void AddSatellite(Satellite satellite);
        void UpdateSatelliteListView(int selectedIndex);
    }
}
