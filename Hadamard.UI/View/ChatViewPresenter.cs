using System;
using System.Threading;
using Hadamard.Common;
using Hadamard.UI.Presenter;
using IrcDotNet;

namespace Hadamard.UI.View
{
    public class ChatViewPresenter : BasePresenter<IChatView>
    {
        private readonly StandardIrcClient _client;

        public event EventHandler<string> Connecting;
        public event EventHandler<StandardIrcClient> Connected;
        public event EventHandler<StandardIrcClient> ClientRegistered;
        public event EventHandler<IrcChannelEventArgs> ChannelJoined;
        public event EventHandler<IrcMessageEventArgs> MessageReceived;

        public IrcRegistrationInfo RegistrationInfo => new IrcUserRegistrationInfo()
        {
            NickName = View.BotNick,
            UserName = View.BotNick,
            RealName = View.BotNick
        };

        public ChatViewPresenter(IChatView view) : base(view)
        {
            _client = new StandardIrcClient() {
                FloodPreventer = new IrcStandardFloodPreventer(30, 2000)
            };

            _client.Registered += (sender, eventArgs) => {
                ClientRegistered?.Invoke(this, sender as StandardIrcClient);
                _client.Channels.Join(view.Channel);
                _client.LocalUser.JoinedChannel += (o, ircChannelEventArgs) =>
                {
                    ChannelJoined?.Invoke(this, ircChannelEventArgs);
                    ircChannelEventArgs.Channel.MessageReceived += (sender1, ircMessageEventArgs) =>
                    {
                        MessageReceived?.Invoke(this, ircMessageEventArgs);
                    };
                };
            };
        }

        public void Connect()
        {
            var server = View.Server;
            var registrationInfo = this.RegistrationInfo;
            Connecting?.Invoke(this, server);

            using (var connectedEvent = new ManualResetEventSlim(false))
            {
                _client.Connected += (s, e) =>
                {
                    connectedEvent.Set();
                    Connected?.Invoke(this, _client);
                };
                _client.Connect(server, false, registrationInfo);

                if (!connectedEvent.Wait(30000))
                {
                    _client.Dispose();
                    return;
                }
            }
        }
    }
}