using Meebey.SmartIrc4net;
using TriumIrcBot.Plugin;

namespace PluginSamples
{
    public class ReplyTest : IrcPlugin
    {
        public override void Initialize(IrcClient aIrcClient)
        {
        }

        public override void OnAutoConnectError(AutoConnectErrorEventArgs e)
        {
        }

        public override void OnAway(AwayEventArgs e)
        {
        }

        public override void OnBan(BanEventArgs e)
        {
        }

        public override void OnBanException(BanEventArgs e)
        {
        }

        public override void OnBounce(BounceEventArgs e)
        {
        }

        public override void OnChannelAction(ActionEventArgs e)
        {
        }

        public override void OnChannelActiveSynced(IrcEventArgs e)
        {
        }

        public override void OnChannelAdmin(ChannelAdminEventArgs e)
        {
        }

        public override void OnChannelMessage(IrcEventArgs e)
        {
            e.Data.Irc.SendMessage(SendType.Message, e.Data.Channel, "Test");
        }

        public override void OnChannelModeChange<TEventArgs>(TEventArgs e)
        {
        }

        public override void OnChannelNotice(IrcEventArgs e)
        {
        }

        public override void OnChannelPassiveSynced(IrcEventArgs e)
        {
        }

        public override void OnConnected(System.EventArgs e)
        {
        }

        public override void OnConnecting(System.EventArgs e)
        {
        }

        public override void OnConnectionError(System.EventArgs e)
        {
        }

        public override void OnCtcpReply(CtcpEventArgs e)
        {
        }

        public override void OnCtcpRequest(CtcpEventArgs e)
        {
        }

        public override void OnDeChannelAdmin(DeChannelAdminEventArgs e)
        {
        }

        public override void OnDehalfop(DehalfopEventArgs e)
        {
        }

        public override void OnDeop(DeopEventArgs e)
        {
        }

        public override void OnDeowner(DeownerEventArgs e)
        {
        }

        public override void OnDevoice(DevoiceEventArgs e)
        {
        }

        public override void OnDisconnected(System.EventArgs e)
        {
        }

        public override void OnDisconnecting(System.EventArgs e)
        {
        }

        public override void OnError(ErrorEventArgs e)
        {
        }

        public override void OnErrorMessage(IrcEventArgs e)
        {
        }

        public override void OnHalfop(HalfopEventArgs e)
        {
        }

        public override void OnInvite(InviteEventArgs e)
        {
        }

        public override void OnInviteException(BanEventArgs e)
        {
        }

        public override void OnJoin(JoinEventArgs e)
        {
        }

        public override void OnKick(KickEventArgs e)
        {
        }

        public override void OnList(ListEventArgs e)
        {
        }

        public override void OnModeChange(IrcEventArgs e)
        {
        }

        public override void OnMotd(MotdEventArgs e)
        {
        }

        public override void OnNames(NamesEventArgs e)
        {
        }

        public override void OnNickChange(NickChangeEventArgs e)
        {
        }

        public override void OnNowAway(IrcEventArgs e)
        {
        }

        public override void OnOp(OpEventArgs e)
        {
        }

        public override void OnOwner(OwnerEventArgs e)
        {
        }

        public override void OnPart(PartEventArgs e)
        {
        }

        public override void OnPing(PingEventArgs e)
        {
        }

        public override void OnPong(PongEventArgs e)
        {
        }

        public override void OnQueryAction(ActionEventArgs e)
        {
        }

        public override void OnQueryMessage(IrcEventArgs e)
        {
        }

        public override void OnQueryNotice(IrcEventArgs e)
        {
        }

        public override void OnQuit(QuitEventArgs e)
        {
        }

        public override void OnRawMessage(IrcEventArgs e)
        {
        }

        public override void OnRegistered(System.EventArgs e)
        {
        }

        public override void OnTopic(TopicEventArgs e)
        {
        }

        public override void OnTopicChange(TopicChangeEventArgs e)
        {
        }

        public override void OnUnAway(IrcEventArgs e)
        {
        }

        public override void OnUnban(UnbanEventArgs e)
        {
        }

        public override void OnUnBanException(UnbanEventArgs e)
        {
        }

        public override void OnUnInviteException(UnbanEventArgs e)
        {
        }

        public override void OnUserModeChange(IrcEventArgs e)
        {
        }

        public override void OnVoice(VoiceEventArgs e)
        {
        }

        public override void OnWho(WhoEventArgs e)
        {
        }

        public override void Terminate(IrcClient aIrcClient)
        {
        }
    }
}