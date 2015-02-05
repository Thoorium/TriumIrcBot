using Meebey.SmartIrc4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TriumIrcBot.Tool;

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
                    ConsolePlus.WriteLine(ConsoleColor.DarkGreen, "Loaded {0}:{1}", _Plugin.Key, Path.GetFileName(_Plugin.Value));
                }
            }
        }

        public void RegisterIrcClient(IrcClient aIrcClient)
        {
            fPluginList.Keys.ToList().ForEach(a => a.Initialize(aIrcClient));
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