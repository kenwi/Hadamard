using System;

namespace Hadamard.UI.View
{
    public interface IView
    {
        event EventHandler Initialize;
        event EventHandler Load;
    }
}