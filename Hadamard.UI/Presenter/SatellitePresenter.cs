using System;
using Hadamard.Common.Model;
using Hadamard.UI.View;
using System.Linq;

namespace Hadamard.UI.Presenter
{
    public class SatellitePresenter : ISatellitePresenter
    {
        private ISatelliteRepository repository;
        private ISatelliteView view;

        public SatellitePresenter(ISatelliteView view, ISatelliteRepository repository)
        {
            this.view = view;
            view.Presenter = this;
            this.repository = repository;
        }

        public void AddSatellite(Satellite satellite)
        {
            satellite.Refresh();
            repository.Add(satellite);
            
            UpdateSatelliteListView();
        }

        public void Run()
        {
            view.Run();
        }

        public void ShowSatelliteList()
        {
            var satellites = new SatelliteListForm();
            var presenter = new SatellitePresenter(satellites, repository);

            satellites.SatelliteList = repository.GetAllSatellites().ToList();
            satellites.Show();
        }

        public void UpdateSatelliteListView()
        {
            var satellites = repository.GetAllSatellites();
            int selectedSatellite = view.SelectedSatellite >= 0 ? view.SelectedSatellite : 0;

            view.SatelliteList = satellites.ToList();
            view.SelectedSatellite = selectedSatellite;
        }

        public void UpdateSatelliteListView(int selectedIndex)
        {
            var satellite = repository.GetSatellite(selectedIndex);
            satellite.Refresh();

            view.Id = satellite.Id;
            view.Longtitude = satellite.Longtitude;
            view.Latitude = satellite.Latitude;
            view.Elevation = satellite.Elevation;
        }
    }
}