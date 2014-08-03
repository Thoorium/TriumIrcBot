using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TriumIrcBot.Configuration;
using TriumIrcBot.Plugin;

namespace TriumIrcBot
{
    public class IrcBot
    {
        private const string REALNAME = "TriumIrcBot";

        private IrcClient fIrcClient = new IrcClient();
        private PluginManager fPluginManager = new PluginManager();

        public IrcBot()
        {
            ConfigurationManager.Load(this);
        }

        public void Join(string aChannel)
        {
            if (!fIrcClient.IsConnected)
                return;

            if (!aChannel.StartsWith("#"))
                aChannel = "#" + aChannel;

            if (!fIrcClient.JoinedChannels.Contains(aChannel))
                fIrcClient.RfcJoin(aChannel);
        }

        public void Start(string aServerAddress, int aPort, string aNickname, string aUserName)
        {
            fIrcClient.AutoRejoinOnKick = true;
            fIrcClient.AutoJoinOnInvite = false;
            fIrcClient.AutoReconnect = true;
            fIrcClient.AutoRetry = true;
            fIrcClient.ActiveChannelSyncing = true;//TODO: Configurable
            fIrcClient.AutoRejoin = true;
            fIrcClient.AutoRelogin = true;
            fIrcClient.SendDelay = 500;

            fIrcClient.Connect(aServerAddress, aPort);
            fIrcClient.Login(aNickname, REALNAME, 0, aUserName);

            new Thread(Listen).Start();

            string _PluginDirectory = ConfigurationManager.GetValue("PluginDirectory");

            if (!string.IsNullOrWhiteSpace(_PluginDirectory))
            {
                fPluginManager.LoadPluginFiles(Directory.EnumerateFiles(_PluginDirectory, "*.dll"));
            }
            //Maybe move into the if above?
            fPluginManager.RegisterIrcClient(fIrcClient);
        }

        public void Stop()
        {
            fPluginManager.UnRegisterIrcClient(fIrcClient);
            fIrcClient.Disconnect();
        }

        /// <summary>
        /// Listen to all incoming irc communications
        /// </summary>
        private void Listen()
        {
            fIrcClient.Listen();//Threadblock here

            if (fIrcClient.IsConnected)
                fIrcClient.Disconnect();
        }
    }
}