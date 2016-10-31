using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrcDotNet;
using System.Threading;

namespace Hadamard.Common
{
    public abstract class IrcBot
    {
        public abstract IrcRegistrationInfo RegistrationInfo { get; set; }

        protected abstract void InitializeCommandProcessors();
        //protected abstract void InitializeChatCommandProcessors();

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
                Console.WriteLine(@"+ Client connected");
                OnClientConnected(c as IrcClient);
            };
            
            client.Registered += (c, e) =>
            {
                _isRegistered = true;
                Console.WriteLine(@"+ Client connected");
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
                
                ReadCommand(GetCommandKeyWord(line), GetCommandParameters(line));
            }
        }

        protected string[] GetCommandParameters(string line)
        {
            return line.Split(' ').Skip(1).ToArray();
        }

        protected string GetCommandKeyWord(string line)
        {
            return line.Split(' ')[0].ToLower();
        }

        protected void ReadCommand(string command, string[] parameters)
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

        private void ReadChatCommand(IrcClient client, IIrcMessageSource source, IList<IIrcMessageTarget> targets, string command, string[] parameters)
        {

        }
    }
}
