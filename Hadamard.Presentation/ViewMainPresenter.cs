using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Presentation
{
    public class ViewMainPresenter : IViewMainPresenter
    {
        private readonly IViewMain _view;
        public IViewMain View => _view;

        public ViewMainPresenter(IViewMain view)
        {
            _view = view;
            _view.Presenter = this;
        }
    }
}
