using System;
using System.Collections.Generic;
using System.Linq;
using Hadamard.Common.Model;
using Hadamard.UI.View;

namespace Hadamard.UI.Presenter
{
    public class SatellitePresenter : BasePresenter<ISatelliteView>
    {
        private readonly ISatelliteRepository _repository;

        public SatellitePresenter(ISatelliteView view, ISatelliteRepository repository) : base(view)
        {
            if (repository == null)
                throw new ArgumentNullException($"Repository");
            _repository = repository;
            _repository.OnSatelliteAdded += (s, e) => View.Update();
        }
        
        public IList<Satellite> GetAllSatellites()
        {
            return _repository.GetAllSatellites().ToList();
        }

        public void AddSatellite(Satellite satellite)
        {
            _repository.Add(satellite);
            satellite.Refresh();
        }
    }
}