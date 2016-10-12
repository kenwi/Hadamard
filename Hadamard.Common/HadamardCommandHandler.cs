using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common
{
    public class HadamardCommandHandler : ChatCommandHandler
    {
        private readonly string _ircServer = "";
        private readonly string _ircChannel = "";

        public HadamardCommandHandler(IInputOutput ioHandler) : base(ioHandler)
        {
            
        }        
    }
}
