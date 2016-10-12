using IrcDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadamard.Common
{
    public interface IInputOutput
    {
        string GetInput();
        void Send(string message, params object[] arg);
        void Initialize();

        bool IsRegistered { get; }

        void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e);
    }
}
