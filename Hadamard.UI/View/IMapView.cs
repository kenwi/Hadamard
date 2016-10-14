using Hadamard.UI.Presenter;

namespace Hadamard.UI.View
{
    public interface IMapView
    {
        IMapPresenter Presenter { get; set; }
        void Run();
    }
}
