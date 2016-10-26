using System;
using System.Collections.Generic;
using System.Linq;
using Hadamard.Common.Model;
using Hadamard.UI.View;

namespace Hadamard.UI.Presenter
{
    public class SatellitePresenter : BasePresenter<ISatelliteView>
    {
        private ISatelliteRepository _repository;

        public SatellitePresenter(ISatelliteView view, ISatelliteRepository repository) : base(view)
        {
            if (repository == null)
                throw new ArgumentNullException("Repository");
            _repository = repository;
        }

        protected override void OnViewInitialize(object sender, EventArgs e)
        {
            base.OnViewInitialize(sender, e);

            View.UpdateGui += View_UpdateGui;
        }

        private void View_UpdateGui(object sender, EventArgs e)
        {
            
        }

        public IList<Satellite> GetAllSatellites()
        {
            return _repository.GetAllSatellites().ToList();
        }
    }
}