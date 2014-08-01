using Meebey.SmartIrc4net;
using TriumIrcBot.Plugin;

namespace PluginSamples
{
    public class ReplyTest : IrcPlugin
    {
        public override void OnChannelMessage(IrcEventArgs e)
        {
            e.Data.Irc.SendMessage(SendType.Message, e.Data.Channel, "Test");
        }
    }
}