using Meebey.SmartIrc4net;
using TriumIrcBot.Plugin;

namespace PluginSamples
{
    public class ReplyTest : IrcPlugin
    {
        public override void AfterConnectionComplete(IrcClient aIrcClient)
        {
            
        }

        public override void Initialize(IrcClient aIrcClient)
        {
            aIrcClient.OnChannelMessage += aIrcClient_OnChannelMessage;
        }

        void aIrcClient_OnChannelMessage(object sender, IrcEventArgs e)
        {
            e.Data.Irc.SendMessage(SendType.Message, e.Data.Channel, "Test");
        }

        public override void Terminate(IrcClient aIrcClient)
        {
            
        }
    }
}