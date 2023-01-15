using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WorldLoader.OtherLibraries;
using WorldLoader.Utils;

namespace FriendLogger
{
    internal class ConfigVals
    {
        public bool autoLog { get; set; } = false;
    }
    internal class Config
    {
        public static WorldConfig<ConfigVals> Inst;

        internal Config()
        {
            Directory.CreateDirectory(AppStart.FriendsFile);
            Inst = new(Directory.CreateDirectory(Environment.CurrentDirectory + $"\\Friends").FullName + "\\Config.json");

        }
        internal static void ConfigLoop()
        {
            Loop().Start();
            IEnumerator Loop()
            {
                for (; ; )
                {
                    yield return new WaitForSeconds(15f);
                    Config.Inst.Save();
                }
            }
        }
    }
}
