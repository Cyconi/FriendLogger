using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WorldAPI.ButtonAPI.Groups;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Wing;
using WorldAPI.ButtonAPI.Wing.Buttons;
using WorldAPI.ButtonAPI.WIng.Buttons;
using WorldLoader.Utils;
using WorldAPI.ButtonAPI.MM;

namespace FriendLogger
{
    internal class WingMenu
    {
        public static VRCPage MainPage;

        public static WPage wingPage;
        internal static void WingButtons()
        {
            MainPage = new("FOR SOME REASON IF A QM PAGE DOESNT EXIST YOU CANT MAKE A WING PAGE WTF I SPENT LIKE 5 FUCKING DAYYS TRYING TO FIGURE THIS OUT!!!!!!!!!", true);

            wingPage = new("Friend Logger", WorldAPI.APIBase.WingSide.Left);
            new WButton(WorldAPI.APIBase.WingSide.Left, "Friend Logger", () => wingPage.OpenMenu(), "Friend Button");

            new WButton(wingPage, "Log Friends", () => 
            {
                ManualLogFriendsToFile().Start();
            }, "Log friends to text file");
            new WToggle(wingPage, "Auto Log Friends", (val) => 
            {
                Con.Log(val ? "Auto Log Friends - On" : "Auto Log Friends - Off");
                Config.Inst.Config.autoLog = val;
            }, Config.Inst.Config.autoLog);
            Con.Log("Wings Made!");
        }
        internal static IEnumerator LogFriendsToFile()
        {
            if (!Directory.Exists(AppStart.FriendsFile))
                Directory.CreateDirectory(AppStart.FriendsFile);
            if (!File.Exists("Friends/FriendList.txt"))
            {
                Con.Log("Friends File Doesnt Exist... Making Friends Files...");
                File.Create("Friends/FriendList.txt");
                Con.Log("File Has Been Made!");
                yield break;
            }
            yield return new WaitForSeconds(1f);
            foreach (string text in VRC.Core.APIUser.CurrentUser.friendIDs)
            {
                if (!File.ReadLines("Friends/FriendList.txt").Contains(text))
                {
                    File.AppendAllText("Friends/FriendList.txt", text + "\n");
                    "[".WriteToConsole(ConsoleColor.White)
                        .WriteToConsole("Friend Logger", ConsoleColor.Magenta)
                        .WriteToConsole("] ", ConsoleColor.White)
                        .WriteToConsole("Added ", ConsoleColor.DarkYellow)
                        .WriteToConsole(text, ConsoleColor.White)
                        .WriteLineToConsole(" to the list.", ConsoleColor.DarkYellow);
                }
            }
            yield break;
        }
        internal static IEnumerator ManualLogFriendsToFile()
        {
            if (!Directory.Exists(AppStart.FriendsFile))
                Directory.CreateDirectory(AppStart.FriendsFile);
            if (!File.Exists("Friends/FriendList.txt"))
            {
                Con.Log("Friends File Doesnt Exist... Making Friends Files...");
                File.Create("Friends/FriendList.txt");
                Con.Log("File Has Been Made, Please Retry");
                yield break;
            }
            yield return new WaitForSeconds(1f);
            foreach (string text in VRC.Core.APIUser.CurrentUser.friendIDs)
            {
                if (!File.ReadLines("Friends/FriendList.txt").Contains(text))
                {
                    File.AppendAllText("Friends/FriendList.txt", text + "\n");
                    "[".WriteToConsole(ConsoleColor.White)
                        .WriteToConsole("Friend Logger", ConsoleColor.Magenta)
                        .WriteToConsole("] ", ConsoleColor.White)
                        .WriteToConsole("Added ", ConsoleColor.DarkYellow)
                        .WriteToConsole(text, ConsoleColor.White)
                        .WriteLineToConsole(" to the list.", ConsoleColor.DarkYellow);
                }
                else
                    "[".WriteToConsole(ConsoleColor.White)
                        .WriteToConsole("Friend Logger", ConsoleColor.Magenta)
                        .WriteToConsole("] ", ConsoleColor.White)
                        .WriteToConsole("Friend ", ConsoleColor.DarkYellow)
                        .WriteToConsole(text, ConsoleColor.White)
                        .WriteLineToConsole(" is already in the list!", ConsoleColor.DarkYellow);

            }
            yield break;
        }
    }
}
