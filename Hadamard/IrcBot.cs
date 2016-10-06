using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrcDotNet;
using System.Threading;

namespace Hadamard
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

    public abstract class IrcBot
    {
        public abstract IrcRegistrationInfo RegistrationInfo { get; }
        protected abstract void InitializeCommandProcessors();

        protected virtual void OnClientConnected(IrcClient client) { }
        protected virtual void OnClientRegistered(IrcClient client) { }
        protected virtual void OnLocalUserMessageReceived(IrcLocalUser localUser, IrcMessageEventArgs e) { }
        protected virtual void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e) { }

        private bool _isRunning;
        private bool _isRegistered;
        protected StandardIrcClient _client;
        protected IDictionary<string, CommandProcessor> _commandProcessors;
        protected IDictionary<string, ChatCommandProcessor> _chatCommandProcessors;

        protected delegate void ChatCommandProcessor(IrcClient client, IIrcMessageSource source, IList<IIrcMessageTarget> targets, string command, IList<string> parameters);
        protected delegate void CommandProcessor(string command, IList<string> parameters);

        public IrcBot()
        {
            _isRunning = false;
            _isRegistered = false;
            _commandProcessors = null;//new Dictionary<string, CommandProcessor>(StringComparer.OrdinalIgnoreCase);
            _chatCommandProcessors = new Dictionary<string, ChatCommandProcessor>(StringComparer.OrdinalIgnoreCase);

            InitializeCommandProcessors();
        }

        public void Connect(string server, IrcRegistrationInfo registrationInfo)
        {
            var client = new StandardIrcClient()
            {
                FloodPreventer = new IrcStandardFloodPreventer(30, 2000)
            };
            client.Connected += (c, e) =>
            {
                Console.WriteLine("+ Client Connected");
                OnClientConnected(c as IrcClient);
            };
            
            client.Registered += (c, e) =>
            {
                _isRegistered = true;
                Console.WriteLine("+ Client registered");
                (c as IrcClient).LocalUser.JoinedChannel += (localUser, channelArgs) =>                {
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
                
                if(!connectedEvent.Wait(30000))
                {
                    client.Dispose();
                    return;
                }
            }

            _client = client;
        }

        public void Quit()
        {
            _isRunning = false;
        }

        public void Run()
        {
            _isRunning = true;
            while(_isRunning)
            {
                if (!_isRegistered)
                    continue;

                Console.Write("> ");
                var line = Console.ReadLine();
                if (line == null)
                    break;
                if (line.Length == 0)
                    continue;

                var parts = line.Split(' ');
                var command = parts[0].ToLower();
                var parameters = parts.Skip(1).ToArray();

                ReadCommand(command, parameters);
            }
        }

        private void ReadCommand(string command, string[] parameters)
        {
            CommandProcessor processor;
            if (_commandProcessors.TryGetValue(command, out processor))
            {
                try
                {
                    processor(command, parameters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            else
                Console.WriteLine($"+ Command '{command}' not recognized", command);
        }
    }
}
