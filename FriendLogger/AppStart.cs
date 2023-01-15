using Il2CppInterop.Runtime.Injection;
using Il2CppSystem.Runtime.Remoting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.UIR;
using VRC.Core;
using VRC.UI.Elements;
using WorldAPI;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Buttons;
using WorldAPI.ButtonAPI.Extras;
using WorldAPI.ButtonAPI.Groups;
using WorldAPI.Buttons;
using WorldLoader.Attributes;
using WorldLoader.HookUtils;
using WorldLoader.Mods;
using WorldLoader.Utils;

namespace FriendLogger
{
    [Mod("Friend", "[Logger]", "Cyconi")]
    public class AppStart : UnityMod
    {
        public static string FriendsFile = Path.Combine(Environment.CurrentDirectory, "Friends");
        private Config config;

        [HandleProcessCorruptedStateExceptions]
        public override void OnInject()
        {
            if (!Directory.Exists(FriendsFile))
                Directory.CreateDirectory(FriendsFile);
            if (!File.Exists("Friends/FriendList.txt"))
            {
                Con.Log("Friends File Doesnt Exist... Making Friends Files...");
                File.Create("Friends/FriendList.txt");
                Con.Log("File Has Been Made!");
            }

            config = new Config();
            Config.ConfigLoop();

            Init().Start();
            IEnumerator Init()
            {
                while (GameObject.Find("Canvas_QuickMenu(Clone)") == null) yield return null;

                WingMenu.WingButtons();

                yield break;
            }
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (Config.Inst.Config.autoLog)
                WingMenu.LogFriendsToFile().Start();
         
        }
        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {           
            if (Config.Inst.Config.autoLog)
                WingMenu.LogFriendsToFile().Start();
        }        
    }
}
