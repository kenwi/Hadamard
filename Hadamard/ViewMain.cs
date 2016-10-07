using System;
using Hadamard.Presentation;

namespace Hadamard
{
    public class ViewMain : IViewMain
    {
        private IViewMainPresenter _presenter;
        public IViewMainPresenter Presenter
        {
            get { return _presenter; }
            set { if (_presenter == null) _presenter = value; }
        }

        public ViewMain()
        {

        }                
    }
}