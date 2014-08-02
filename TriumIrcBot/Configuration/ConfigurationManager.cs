using System;
using System.Configuration;

namespace TriumIrcBot.Configuration
{
    public static class ConfigurationManager
    {
        private static System.Configuration.Configuration fConfiguration;

        public static string GetValue(string aKey)
        {
            KeyValueConfigurationElement _Element = fConfiguration.AppSettings.Settings[aKey];
            if (_Element != null)
            {
                string _Value = _Element.Value;
                if (!string.IsNullOrEmpty(_Value))
                    return _Value;
            }
            return null;
        }

        public static void Load(object aLibrary)
        {
            if (fConfiguration != null)
                return;

            string _ExeConfigPath = aLibrary.GetType().Assembly.Location;
            try
            {
                fConfiguration = System.Configuration.ConfigurationManager.OpenExeConfiguration(_ExeConfigPath);
            }
            catch (Exception _Ex)
            {
                //TODO: Handle error
                throw;
            }
        }
    }
}