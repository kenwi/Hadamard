using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Presentation
{
    public interface IView<TPresenter>
    {
        TPresenter Presenter { get; set; }
    }
}
