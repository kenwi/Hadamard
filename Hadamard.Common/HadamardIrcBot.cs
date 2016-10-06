using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrcDotNet;

namespace Hadamard.Common
{
    public class HadamardIrcBot : IrcBot
    {
        private static string _channel = "#da8Q_9RnPjm";

        public HadamardIrcBot() : base()
        {

            Connect("orwell.freenode.net", RegistrationInfo);
            _commandProcessors = CommandProcessors;
        }

        public override IrcRegistrationInfo RegistrationInfo
        {
            get
            {
                return new IrcUserRegistrationInfo()
                {
                    NickName = "Hadamard",
                    UserName = "Hadamard",
                    RealName = "isReal"
                };
            }
        }

        protected IDictionary<string, CommandProcessor> CommandProcessors
        {
            get
            {
                return _commandProcessors == null ?
                    new Dictionary<string, CommandProcessor>
                    {
                        {
                            "join", (command, parameters) => {
                                if(parameters.Count < 1 )
                                    throw new ArgumentException("Not enough arguments");
                                var channel = parameters[0].StartsWith("#") ? parameters[0] : $"#{parameters[0]}";
                                _client.Channels.Join(channel);
                            }
                        },
                        {
                            "quit", (command, parameters) =>
                            {
                                Quit();
                            }
                        }

                    } : _commandProcessors;
            }
        }

        protected override void InitializeCommandProcessors()
        {

        }

        protected override void OnClientRegistered(IrcClient client)
        {
            base.OnClientRegistered(client);
            client.Channels.Join(_channel);
        }

        protected override void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e)
        {
            base.OnChannelMessageReceived(channel, e);
            channel.Client.LocalUser.SendMessage(channel.Name, e.Text.GetHashCode().ToString());
        }
    }

}
