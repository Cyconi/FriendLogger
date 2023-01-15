using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAPI;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Groups;
using WorldAPI.ButtonAPI.MM;
using WorldAPI.ButtonAPI.Wing.Buttons;
using WorldAPI.ButtonAPI.Wing;
using WorldLoader.Utils;
using UnityEngine;
using VRC.Core;
using System.Collections;
using System.IO;
using WorldAPI.ButtonAPI.WIng.Buttons;

namespace FriendLogger
{
    internal class WingMenu
    {
        internal static void WingButtons()
        {
            var wingPage = new WPage("Friend Logger", APIBase.WingSide.Left);
            new WButton(APIBase.WingSide.Left, "Friend Logger", () => wingPage.OpenMenu(), "Friend Button");

            new WButton(wingPage, "Log Friends", () => 
            {
                ManualLogFriendsToFile().Start();
            }, "Log friends to text file");
            new WToggle(wingPage, "Auto Log Friends", (val) => 
            {
                Con.Log(val ? "Auto Log Friends - On" : "Auto Log Friends - Off");
                Config.Inst.Config.autoLog = val;
            });
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
            foreach (string text in APIUser.CurrentUser.friendIDs)
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
            foreach (string text in APIUser.CurrentUser.friendIDs)
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
