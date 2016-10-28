using Hadamard.Common;
using Hadamard.UI.Presenter;
using IrcDotNet;

namespace Hadamard.UI.View
{
    public class ChatViewPresenter : BasePresenter<IChatView>
    {
        private readonly Common.HadamardIrcBot _ircbot;

        public ChatViewPresenter(IChatView view) : base(view)
        {
            //var ioHandler = new IrcIOHandler();
            _ircbot = new Common.HadamardIrcBot()
            {
                RegistrationInfo = new IrcUserRegistrationInfo()
                {
                    NickName = view.BotNick
                },
                Channel = view.Channel
            };
        }

        public void Connect()
        {
            
        }
    }
}