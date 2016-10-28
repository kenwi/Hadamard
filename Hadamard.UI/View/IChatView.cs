﻿namespace Hadamard.UI.View
{
    public interface IChatView : IView
    {
        string BotNick { get; }
        string Channel { get; }

        void Connect();
    }
}