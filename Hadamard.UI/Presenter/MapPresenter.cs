using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hadamard.UI.View;
using Hadamard.Common.Model;

namespace Hadamard.UI.Presenter
{
    public class MapPresenter : IMapPresenter
    {
        private IMapView _view;
        public IMapView View
        {
            get { return _view;}
            set { _view = value; }
        }

        public MapPresenter(IMapView view)
        {
            _view = view;
            view.Presenter = this;
        }

        public void Run()
        {
            _view.Run();

            ISatelliteRepository repository = new SatelliteRepository();
            var view = new SatelliteForm();
            var presenter = new SatellitePresenter(view, repository);
            presenter.Run();
        }
    }
}
