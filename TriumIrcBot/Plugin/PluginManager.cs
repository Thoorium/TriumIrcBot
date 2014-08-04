using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TriumIrcBot.Plugin
{
    internal class PluginManager
    {
        private readonly Dictionary<IrcPlugin, string> fPluginList = new Dictionary<IrcPlugin, string>();
        private AppDomain fPluginAppDomain;//TODO: Load plugins into a different appdomain

        public void AfterConnectionComplete(IrcClient aIrcClient)
        {
            fPluginList.Keys.ToList().ForEach(a => a.AfterConnectionComplete(aIrcClient));
        }

        public void LoadPluginFiles(IEnumerable<string> aPluginFiles)
        {
            foreach (string _PluginFileName in aPluginFiles)
            {
                foreach (var _Plugin in LoadPluginFile(_PluginFileName))
                {
                    fPluginList.Add(_Plugin.Key, _Plugin.Value);
                    Console.WriteLine("Loaded {0}:{1}", _Plugin.Key, Path.GetFileName(_Plugin.Value));
                }
            }
        }

        public void RegisterIrcClient(IrcClient aIrcClient)
        {
            fPluginList.Keys.ToList().ForEach(a => a.Initialize(aIrcClient));

            #region IrcClientEvents

            aIrcClient.OnAutoConnectError += (object sender, AutoConnectErrorEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnAutoConnectError(e)); };

            aIrcClient.OnAway += (object sender, AwayEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnAway(e)); };

            aIrcClient.OnBan += (object sender, BanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnBan(e)); };

            aIrcClient.OnBanException += (object sender, BanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnBanException(e)); };

            aIrcClient.OnBounce += (object sender, BounceEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnBounce(e)); };

            aIrcClient.OnChannelAction += (object sender, ActionEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelAction(e)); };

            aIrcClient.OnChannelActiveSynced += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelActiveSynced(e)); };

            aIrcClient.OnChannelAdmin += (object sender, ChannelAdminEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelAdmin(e)); };

            aIrcClient.OnChannelMessage += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelMessage(e)); };

            aIrcClient.OnChannelModeChange += (object sender, ChannelModeChangeEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelModeChange(e)); };

            aIrcClient.OnChannelNotice += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelNotice(e)); };

            aIrcClient.OnChannelPassiveSynced += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnChannelPassiveSynced(e)); };

            aIrcClient.OnConnected += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnConnected(e)); };

            aIrcClient.OnConnecting += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnConnecting(e)); };

            aIrcClient.OnConnectionError += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnConnectionError(e)); };

            aIrcClient.OnCtcpReply += (object sender, CtcpEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnCtcpReply(e)); };

            aIrcClient.OnCtcpRequest += (object sender, CtcpEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnCtcpRequest(e)); };

            aIrcClient.OnDeChannelAdmin += (object sender, DeChannelAdminEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDeChannelAdmin(e)); };

            aIrcClient.OnDehalfop += (object sender, DehalfopEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDehalfop(e)); };

            aIrcClient.OnDeop += (object sender, DeopEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDeop(e)); };

            aIrcClient.OnDeowner += (object sender, DeownerEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDeowner(e)); };

            aIrcClient.OnDevoice += (object sender, DevoiceEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDevoice(e)); };

            aIrcClient.OnDisconnected += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDisconnected(e)); };

            aIrcClient.OnDisconnecting += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnDisconnecting(e)); };

            aIrcClient.OnError += (object sender, Meebey.SmartIrc4net.ErrorEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnError(e)); };

            aIrcClient.OnErrorMessage += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnErrorMessage(e)); };

            aIrcClient.OnHalfop += (object sender, HalfopEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnHalfop(e)); };

            aIrcClient.OnInvite += (object sender, InviteEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnInvite(e)); };

            aIrcClient.OnInviteException += (object sender, BanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnInviteException(e)); };

            aIrcClient.OnJoin += (object sender, JoinEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnJoin(e)); };

            aIrcClient.OnKick += (object sender, KickEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnKick(e)); };

            aIrcClient.OnList += (object sender, ListEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnList(e)); };

            aIrcClient.OnModeChange += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnModeChange(e)); };

            aIrcClient.OnMotd += (object sender, MotdEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnMotd(e)); };

            aIrcClient.OnNames += (object sender, NamesEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnNames(e)); };

            aIrcClient.OnNickChange += (object sender, NickChangeEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnNickChange(e)); };

            aIrcClient.OnNowAway += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnNowAway(e)); };

            aIrcClient.OnOp += (object sender, OpEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnOp(e)); };

            aIrcClient.OnOwner += (object sender, OwnerEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnOwner(e)); };

            aIrcClient.OnPart += (object sender, PartEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnPart(e)); };

            aIrcClient.OnPing += (object sender, PingEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnPing(e)); };

            aIrcClient.OnPong += (object sender, PongEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnPong(e)); };

            aIrcClient.OnQueryAction += (object sender, ActionEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnQueryAction(e)); };

            aIrcClient.OnQueryMessage += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnQueryMessage(e)); };

            aIrcClient.OnQueryNotice += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnQueryNotice(e)); };

            aIrcClient.OnQuit += (object sender, QuitEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnQuit(e)); };

            aIrcClient.OnRawMessage += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnRawMessage(e)); };

            aIrcClient.OnRegistered += (object sender, EventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnRegistered(e)); };

            aIrcClient.OnTopic += (object sender, TopicEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnTopic(e)); };

            aIrcClient.OnTopicChange += (object sender, TopicChangeEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnTopicChange(e)); };

            aIrcClient.OnUnAway += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnUnAway(e)); };

            aIrcClient.OnUnban += (object sender, UnbanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnUnban(e)); };

            aIrcClient.OnUnBanException += (object sender, UnbanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnUnBanException(e)); };

            aIrcClient.OnUnInviteException += (object sender, UnbanEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnUnInviteException(e)); };

            aIrcClient.OnUserModeChange += (object sender, IrcEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnUserModeChange(e)); };

            aIrcClient.OnVoice += (object sender, VoiceEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnVoice(e)); };

            aIrcClient.OnWho += (object sender, WhoEventArgs e) => { fPluginList.Keys.ToList().ForEach(a => a.OnWho(e)); };

            #endregion IrcClientEvents
        }

        public void UnRegisterIrcClient(IrcClient aIrcClient)
        {
            fPluginList.Keys.ToList().ForEach(a => a.Terminate(aIrcClient));
        }

        private void LoadPluginClass(string aFileName, Dictionary<IrcPlugin, string> aServerPluginList, Type aType, Assembly aAssembly)
        {
            if (typeof(IrcPlugin).IsAssignableFrom(aType))
            {
                IrcPlugin _ServerPlugin = aAssembly.CreateInstance(aType.FullName) as IrcPlugin;
                aServerPluginList.Add(_ServerPlugin, aFileName);
            }
        }

        private Dictionary<IrcPlugin, string> LoadPluginFile(string aFileName)
        {
            Assembly _Assembly = null;

            try
            {
                _Assembly = Assembly.LoadFile(aFileName);
            }
            catch (Exception _Ex)
            {
                string _Message = string.Format("Fail to load server plugin file [{0}] with error\r\n{1}]", aFileName, _Ex);
                //TODO: Logs
                throw;
            }

            LoadServerPluginConfiguration(aFileName, _Assembly);

            Dictionary<IrcPlugin, string> _ServerPluginList = new Dictionary<IrcPlugin, string>();

            Type[] _ExportedTypes = _Assembly.GetExportedTypes();

            foreach (Type _Type in _ExportedTypes)
            {
                LoadPluginClass(aFileName, _ServerPluginList, _Type, _Assembly);
            }

            return _ServerPluginList;
        }

        /// <summary>
        /// TODO: PLANNED
        /// </summary>
        /// <param name="aPluginFileName"></param>
        /// <param name="aAssembly"></param>
        private void LoadServerPluginConfiguration(string aPluginFileName, Assembly aAssembly)
        {
        }
    }
}