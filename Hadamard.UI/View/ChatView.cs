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

namespace Hadamard.UI.View
{
    public partial class ChatView : Form, IChatView
    {
        private readonly ChatViewPresenter Presenter;
        public event EventHandler Initialize;
        public event PropertyChangedEventHandler PropertyChanged;

        public string BotNick { get; } = "Hadamard";
        public string Channel { get; } = "#da8Q_9RnPjm";
        public string Server { get; } = "chat.freenode.net";

        private List<string> _messages = new List<string>();

        public string Messages => string.Join(Environment.NewLine, _messages.Select(x => x + Environment.NewLine).ToArray());
        
        public ChatView()
        {
            InitializeComponent();
            Presenter = new ChatViewPresenter(this);
            btnConnect.Click += (s, e) => Presenter.Connect();

            Presenter.ClientRegistered += (s, e) => SetText("Client registered: " + e.LocalUser.Client, txtChat);
            Presenter.ChannelJoined += (s, e) => SetText("Client joined channel: " + e.Channel.Name, txtChat);
            Presenter.Connecting += (s, server) => SetText("Connecting to server: " + server, txtChat);
            Presenter.Connected += (s, client) => SetText("Connected to server:" + client.LocalUser.Client, txtChat);

            Presenter.MessageReceived += (s, e) =>
            {
                SetText("Message received: " + e.Text, txtChat);
                _messages.Add(e.Text);
            };
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
                control.Text += text + Environment.NewLine;
        }
    }
}

/*
public class ChatMessages : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ChatMessages(string text)
    {
        this.Text = text;
    }

    private string _text;
    public string Text
    {
        get { return _text; }
        set
        {
            _text = value + Environment.NewLine;
            OnPropertyChanged("Text");
        }
    }
}*/
