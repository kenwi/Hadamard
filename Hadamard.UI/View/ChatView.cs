using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hadamard.Presentation;
using Hadamard.UI.Presenter;

namespace Hadamard.UI.View
{
    public partial class ChatView : Form, IChatView
    {
        private readonly BasePresenter<IChatView> Presenter;
        public event EventHandler Initialize;

        public string BotNick { get; } = "Hadamard";
        public string Channel { get; } = "#da8Q_9RnPjm";

        public void Connect()
        {
            
        }

        public ChatView()
        {
            InitializeComponent();
            Presenter = new ChatViewPresenter(this);
        }
    }
}
