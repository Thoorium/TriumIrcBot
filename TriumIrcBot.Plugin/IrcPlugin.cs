using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriumIrcBot.Plugin
{
    public abstract class IrcPlugin
    {
        public abstract void AfterConnectionComplete(IrcClient aIrcClient);

        public abstract void Initialize(IrcClient aIrcClient);

        public abstract void Terminate(IrcClient aIrcClient);
    }
}