using Hadamard.UI.View;

namespace Hadamard.UI.Presenter
{
    public interface IMapPresenter
    {
        IMapView View { get; set; }
        void Run();
    }
}