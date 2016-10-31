using IrcDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hadamard.Common
{
    public class IrcIOHandler : IInputOutput
    {
        public virtual void OnClientConnected(IrcClient client) { }
        public virtual void OnClientRegistered(IrcClient client) { }
        public virtual void OnLocalUserMessageReceived(IrcLocalUser localUser, IrcMessageEventArgs e) { }
        public virtual void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e) { }

        private bool _isRegistered = false;
        public bool IsRegistered => _isRegistered;

        public IrcIOHandler()
        {
            
        }

        public string GetInput()
        {
            throw new NotImplementedException();
        }

        public void Connect(string server, IrcRegistrationInfo registrationInfo)
        {
            var client = new StandardIrcClient()
            {
                FloodPreventer = new IrcStandardFloodPreventer(30, 2000)
            };

            client.Connected += (c, e) =>
            {
                Console.WriteLine(@"+ Client connected");
                OnClientConnected(c as IrcClient);
            };

            client.Registered += (c, e) =>
            {
                _isRegistered = true;
                Console.WriteLine(@"+ Client connected");
                (c as IrcClient).LocalUser.JoinedChannel += (localUser, channelArgs) => {
                    Console.WriteLine("+ Client joined channel " + channelArgs.Channel.Name);

                    channelArgs.Channel.MessageReceived += (channel, messageArgs) =>
                    {
                        Console.WriteLine("+ Received channel message: " + messageArgs.Text);
                        OnChannelMessageReceived(channelArgs.Channel, messageArgs);
                    };
                };

                OnClientRegistered(c as IrcClient);
            };

            using (var connectedEvent = new ManualResetEventSlim(false))
            {
                client.Connected += (s, e) => connectedEvent.Set();
                client.Connect(server, false, registrationInfo);

                if (!connectedEvent.Wait(30000))
                {
                    client.Dispose();
                    return;
                }
            }
        }

        public void Send(string message, params object[] arg)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
