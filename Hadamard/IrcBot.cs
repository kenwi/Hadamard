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
        public HadamardIrcBot() : base()
        {
            Connect("efnet.port80.se", RegistrationInfo);
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
                                _isRunning = false;
                            }
                        }

                    } : _commandProcessors;
            }
        }

        protected override void InitializeCommandProcessors()
        {
            
        }
    }

    public abstract class IrcBot
    {
        public abstract IrcRegistrationInfo RegistrationInfo { get; }
        protected abstract void InitializeCommandProcessors();

        protected virtual void OnClientConnect(IrcClient client) { }
        protected virtual void OnClientRegistered(IrcClient client) { }
        protected virtual void OnLocalUserMessageReceived(IrcLocalUser localUser, IrcMessageEventArgs e) { }
        protected virtual void OnChannelMessageReceived(IrcChannel channel, IrcMessageEventArgs e) { }

        public  bool _isRunning;
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
            client.Connected += Client_Connected;
            client.Registered += Client_Registered;

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

        private void Client_Connected(object sender, EventArgs e)
        {
            var client = sender as IrcClient;
            Console.WriteLine($"Client connected: {sender.ToString()}");
            OnClientConnect(client);
        }

        private void Client_Registered(object sender, EventArgs e)
        {
            var client = sender as IrcClient;
            Console.WriteLine("Client registered.");
            _isRegistered = true;

            client.LocalUser.JoinedChannel += LocalUser_JoinedChannel;
                        
            OnClientRegistered(client);
        }

        private void LocalUser_JoinedChannel(object sender, IrcChannelEventArgs e)
        {
            var localUser = sender as IrcLocalUser;
            e.Channel.MessageReceived += Channel_MessageReceived;
        }

        private void Channel_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            var channel = sender as IrcChannel;
            if(e.Source is IrcUser)
            {

            }
            OnChannelMessageReceived(channel, e);
        }

        private void LocalUser_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            var localUser = sender as IrcLocalUser;

            OnLocalUserMessageReceived(localUser, e);
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
            if (this._commandProcessors.TryGetValue(command, out processor))
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
