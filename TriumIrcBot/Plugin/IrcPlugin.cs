using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriumIrcBot.Plugin
{
    public abstract class IrcPlugin
    {
        //TODO: the rest

        public abstract void OnChannelMessage(IrcEventArgs e);
    }
}