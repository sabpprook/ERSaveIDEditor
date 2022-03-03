using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ERSaveIDEditor
{
    internal class Steam
    {
        private static RegistryKey SteamRegkey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Valve\Steam", true);
        private static string SteamPath = SteamRegkey.GetValue("SteamPath", "") as string;

        public static List<(string id, string account_name, string persona_name)> GetLoginUsers()
        {
            var list = new List<(string id, string account_name, string persona_name)>();

            if (!Directory.Exists(SteamPath))
                return list;

            var loginusers = SteamPath + "\\config\\loginusers.vdf";
            if (!File.Exists(loginusers))
                return list;

            try
            {
                var text = File.ReadAllText(loginusers);
                var steam_id_matches = Regex.Matches(text, "\"(\\d{12,20})\"");
                var account_name_matches = Regex.Matches(text, "\"AccountName\"[\\t ]+\"([^\"^\\t^\\n]+)\"");
                var persona_name_matches = Regex.Matches(text, "\"PersonaName\"[\\t ]+\"([^\"^\\t^\\n]+)\"");
                for (int i = 0; i < steam_id_matches.Count; i++)
                {
                    var id = steam_id_matches[i].Groups[1].Value;
                    var account_name = account_name_matches[i].Groups[1].Value;
                    var persona_name = persona_name_matches[i].Groups[1].Value;
                    list.Add((id, account_name, persona_name));
                }
            }
            catch { }

            return list;
        }
    }
}
