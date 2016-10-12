using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrcDotNet;

namespace Hadamard.Common
{
    public class ConsoleIOHandler : IInputOutput
    {
        public bool IsRegistered => true;

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public void Send(string message, params object[] arg)
        {
            Console.WriteLine(message, arg);
        }

        public void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
