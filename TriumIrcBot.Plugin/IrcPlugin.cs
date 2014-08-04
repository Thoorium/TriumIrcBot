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

        public abstract void OnAutoConnectError(AutoConnectErrorEventArgs e);

        public abstract void OnAway(AwayEventArgs e);

        public abstract void OnBan(BanEventArgs e);

        public abstract void OnBanException(BanEventArgs e);

        public abstract void OnBounce(BounceEventArgs e);

        public abstract void OnChannelAction(ActionEventArgs e);

        public abstract void OnChannelActiveSynced(IrcEventArgs e);

        public abstract void OnChannelAdmin(ChannelAdminEventArgs e);

        public abstract void OnChannelMessage(IrcEventArgs e);

        public abstract void OnChannelModeChange<TEventArgs>(TEventArgs e);

        public abstract void OnChannelNotice(IrcEventArgs e);

        public abstract void OnChannelPassiveSynced(IrcEventArgs e);

        public abstract void OnConnected(EventArgs e);

        public abstract void OnConnecting(EventArgs e);

        public abstract void OnConnectionError(EventArgs e);

        public abstract void OnCtcpReply(CtcpEventArgs e);

        public abstract void OnCtcpRequest(CtcpEventArgs e);

        public abstract void OnDeChannelAdmin(DeChannelAdminEventArgs e);

        public abstract void OnDehalfop(DehalfopEventArgs e);

        public abstract void OnDeop(DeopEventArgs e);

        public abstract void OnDeowner(DeownerEventArgs e);

        public abstract void OnDevoice(DevoiceEventArgs e);

        public abstract void OnDisconnected(EventArgs e);

        public abstract void OnDisconnecting(EventArgs e);

        public abstract void OnError(ErrorEventArgs e);

        public abstract void OnErrorMessage(IrcEventArgs e);

        public abstract void OnHalfop(HalfopEventArgs e);

        public abstract void OnInvite(InviteEventArgs e);

        public abstract void OnInviteException(BanEventArgs e);

        public abstract void OnJoin(JoinEventArgs e);

        public abstract void OnKick(KickEventArgs e);

        public abstract void OnList(ListEventArgs e);

        public abstract void OnModeChange(IrcEventArgs e);

        public abstract void OnMotd(MotdEventArgs e);

        public abstract void OnNames(NamesEventArgs e);

        public abstract void OnNickChange(NickChangeEventArgs e);

        public abstract void OnNowAway(IrcEventArgs e);

        public abstract void OnOp(OpEventArgs e);

        public abstract void OnOwner(OwnerEventArgs e);

        public abstract void OnPart(PartEventArgs e);

        public abstract void OnPing(PingEventArgs e);

        public abstract void OnPong(PongEventArgs e);

        public abstract void OnQueryAction(ActionEventArgs e);

        public abstract void OnQueryMessage(IrcEventArgs e);

        public abstract void OnQueryNotice(IrcEventArgs e);

        public abstract void OnQuit(QuitEventArgs e);

        public abstract void OnRawMessage(IrcEventArgs e);

        public abstract void OnRegistered(EventArgs e);

        public abstract void OnTopic(TopicEventArgs e);

        public abstract void OnTopicChange(TopicChangeEventArgs e);

        public abstract void OnUnAway(IrcEventArgs e);

        public abstract void OnUnban(UnbanEventArgs e);

        public abstract void OnUnBanException(UnbanEventArgs e);

        public abstract void OnUnInviteException(UnbanEventArgs e);

        public abstract void OnUserModeChange(IrcEventArgs e);

        public abstract void OnVoice(VoiceEventArgs e);

        public abstract void OnWho(WhoEventArgs e);

        public abstract void Terminate(IrcClient aIrcClient);
    }
}