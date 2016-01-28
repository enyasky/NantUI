using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using NantUI.Util;

namespace NantUI
{
    public class Config
    {
        private static List<Property> properties = new List<Property>();

        public static List<Property> Properties
        {
            get { return properties; }
        }
        public static string DefaultFile { get; set; }
        public static string NantPath { get; set; }

        public static void LoadConfig()
        {
            // try to load data from the config file
            try
            {
                var keys = ConfigurationManager.AppSettings.AllKeys;

                foreach (var key in keys)
                    LoadConfigItem(key, ConfigurationManager.AppSettings[key]);
            }
            catch { } // swallow - allow app to be used 100% stand alone
        }

        public static void LoadArgs(string[] args) 
        {
            for (int i = 0; i < args.Length; i += 2)
                LoadConfigItem(args[i], args[i+1]);
        }

        private static void LoadConfigItem(string key, string val)
        {
            switch (key)
            {
                case "nantPath":
                case "-n":
                    NantPath = val;
                    return;
                case "defaultFile":
                case "-f":
                    DefaultFile = val;
                    return;
                case "-p":
                    var s = val.Split('=');
                    if (s.Length != 2)
                        return;

                    key = s[0];
                    val = s[1];
                    break;
            }

            Properties.Add(new Property(key, val));
        }

    }
}
