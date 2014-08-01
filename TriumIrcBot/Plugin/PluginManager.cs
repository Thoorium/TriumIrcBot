using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TriumIrcBot.Plugin
{
    public static class PluginManager
    {
        private static readonly Dictionary<IrcPlugin, string> fPluginList = new Dictionary<IrcPlugin, string>();
        private static AppDomain fPluginAppDomain;//TODO: Load plugins into a different appdomain

        public static void LoadPluginFiles(IEnumerable<string> aPluginFiles)
        {
            foreach (string _PluginFileName in aPluginFiles)
            {
                foreach (var _Plugin in LoadPluginFile(_PluginFileName))
                {
                    fPluginList.Add(_Plugin.Key, _Plugin.Value);
                }
            }
        }

        public static void RegisterIrcClient(IrcClient aIrcClient)
        {
            aIrcClient.OnChannelMessage += aIrcClient_OnChannelMessage;
            //TODO: All the other events
        }

        private static void LoadPluginClass(string aFileName, Dictionary<IrcPlugin, string> aServerPluginList, Type aType, Assembly aAssembly)
        {
            if (typeof(IrcPlugin).IsAssignableFrom(aType))
            {
                IrcPlugin _ServerPlugin = aAssembly.CreateInstance(aType.FullName) as IrcPlugin;
                aServerPluginList.Add(_ServerPlugin, aFileName);
            }
        }

        private static Dictionary<IrcPlugin, string> LoadPluginFile(string aFileName)
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
        private static void LoadServerPluginConfiguration(string aPluginFileName, Assembly aAssembly)
        {
        }

        #region IrcClientEvents

        private static void aIrcClient_OnChannelMessage(object sender, IrcEventArgs e)
        {
            foreach (var _Plugin in fPluginList)
            {
                _Plugin.Key.OnChannelMessage(e);
            }
        }

        #endregion IrcClientEvents
    }
}