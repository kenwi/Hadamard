﻿using System;
using Hadamard.Common.Model;
using Hadamard.UI.View;
using System.Linq;

namespace Hadamard.UI.Presenter
{
    public class SatellitePresenter_old : ISatellitePresenter
    {
        private ISatelliteRepository repository;
        private ISatelliteView_old view;

        public SatellitePresenter_old(ISatelliteView_old view, ISatelliteRepository repository)
        {
            this.view = view;
            view.Presenter = this;
            this.repository = repository;
            this.repository.OnSatelliteValuesUpdated += (s, e) => view.UpdateGUI();
            
            //this.repository.OnSatelliteValuesUpdated += (s, e) => 
            //OnSatelliteAdded?.Invoke(this, new OnSatelliteAddedArgs(satellite));

            UpdateSatelliteListView();
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
            var presenter = new SatellitePresenter_old(satellites, repository);

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
            var satellite = repository.GetSatelliteByIndex(selectedIndex);
            satellite.Refresh();

            view.Id = satellite.Id;
            view.Longtitude = satellite.Longitude.ToString();
            view.Latitude = satellite.Latitude.ToString();
            view.Elevation = satellite.Elevation.ToString();
        }
    }
}