using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Hadamard.Common;
using Hadamard.Presentation;

namespace Hadamard
{
    class Program
    {
        static void Main(string[] args)
        {
            //var view = new ViewMain();
            //var presenter = new ViewMainPresenter(view);

            var hadamard = new HadamardIrcBot();
            hadamard.Run();            
        }
    }
}
