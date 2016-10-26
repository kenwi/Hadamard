using System;
using Hadamard.UI.View;

namespace Hadamard.UI.Presenter
{
    public class BasePresenter<TView> where TView : class, IView
    {
        public TView View { get; private set; }

        public BasePresenter(TView view)
        {
            View = view;
            View.Initialize += OnViewInitialize;
            View.Load += OnViewLoad;
        }

        protected virtual void OnViewInitialize(object sender, EventArgs e) { }
        protected virtual void OnViewLoad(object sender, EventArgs e) { }
    }
}