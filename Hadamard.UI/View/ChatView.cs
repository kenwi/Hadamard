using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hadamard.Presentation;
using Hadamard.UI.Presenter;
using IrcDotNet;
using IrcDotNet.Collections;

namespace Hadamard.UI.View
{
    public partial class ChatView : Form, IChatView, INotifyPropertyChanged
    {
        private readonly ChatViewPresenter Presenter;
        public event EventHandler Initialize;
        public event PropertyChangedEventHandler PropertyChanged;

        public string BotNick { get; } = "Hadamard";
        public string Channel { get; } = "#da8Q_9RnPjm";
        public string Server { get; } = "chat.freenode.net";
        public List<string> Users { get; set; }

        public ChatView()
        {
            InitializeComponent();
            Presenter = new ChatViewPresenter(this);
            Presenter.ClientRegistered += (s, e) => SetText("Client registered: " + e.LocalUser.Client, txtChat);
            Presenter.ChannelJoined += (s, e) => SetText("Client joined channel: " + e.Channel.Name, txtChat);
            Presenter.Connecting += (s, e) => SetText("Connecting to server: " + e, txtChat);
            Presenter.Connected += (s, e) => SetText("Connected to server:" + e.LocalUser.Client, txtChat);
            Presenter.MessageReceived += (s, e) => SetText("Message received: " + e.Text, txtChat);
            Presenter.UsersListReceived += (s, e) =>
            {
                Users = e.Select(irc => irc.User.NickName).ToList();
                Users.ForEach(user => SetText(user, txtUsers));
                SetText($@"Users in channel: {string.Join(", ", Users)}", txtChat);
            };
            btnConnect.Click += (s, e) => Presenter.Connect();
            //txtChat.DataBindings.Add("Text", this, "Messages", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private delegate void SetTextCallback(string text, Control control);
        private void SetText(string text, Control control)
        {
            if (control.InvokeRequired)
            {
                var callback = new SetTextCallback(SetText);
                this.Invoke(callback, new object[] {text, control});
            }
            else
            {
                control.Text += $@"{text}{Environment.NewLine}";
                NotifyPropertyChanged("Messages");
            }
        }
    }
}
