/*
* /////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
* \\\\\\\\                  Created by: SharpForge                   ////////
* ////////               Project Title: McLawl Economics             \\\\\\\\
* \\\\\\\\             Current Version: 3.1                          ////////
* ////////             Update Features: Added the ability to block   \\\\\\\\
* \\\\\\\\             skipping ranks. For any bugs and or comments  ////////
* ////////             message me in the mclawl forums :: shade2010  \\\\\\\\
* \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\//////////////////////////////////////
*/

//Special thanks to TheMusiKid

using System;
using System.IO;

namespace MCForge.Commands
{
   public class CmdBuyrank : Command
   {

      public override string name { get { return "buyrank"; } }
      public override string shortcut { get { return "br"; } }
      public override string type { get { return "other"; } }
      public override bool museumUsable { get { return true; } }
      public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }



        public override void Use(Player p, string message)
        {

            //Warning!! If files/directories required for the economy system to work
            //do not exist, the following script will automatically create the default
            //files!
            if (!Directory.Exists("text/Economy"))
            {
                p.SendMessage("%4Could not locate the 'text/Economy' folder, creating one now.");
                Directory.CreateDirectory("text/Economy");
                Directory.CreateDirectory("text/Economy/Jobs");
                Directory.CreateDirectory("text/Economy/Purchasables");
                p.SendMessage("%2Adding the 'Jobs' directory within 'text/Economy'!");
                p.SendMessage("%2Adding the 'Purchasables' directory within 'text/Economy'!");
                p.SendMessage("%2'text/Economy/Jobs' directories successfully created!");
            }

            if (!Directory.Exists("text/Economy/Purchasables"))
            {
                p.SendMessage("%4Could not locate the 'text/Economy/Purchasables' folder, creating one now.");
                Directory.CreateDirectory("text/Economy/Purchasables");
                p.SendMessage("%2Adding the 'Purchasables' directory within 'text/Economy'!");
                p.SendMessage("%2'text/Economy/Jobs' directory successfully created!");
            }

            if (!File.Exists("text/Economy/Purchasables/ranks.properties"))
            {
                p.SendMessage("%4The 'ranks.properties' file could not be located, generating default file now.");
                StreamWriter SW;
                SW = File.CreateText("text/Economy/Purchasables/ranks.properties");
                SW.WriteLine("!Skipable-ranks!False!");
                SW.WriteLine("!guest!0!");
                SW.WriteLine("!builder!10!");
                SW.WriteLine("!advbuilder!100!");
                SW.WriteLine("!operator!1000!");
                SW.Close();
                p.SendMessage("%2Adding the 'ranks.properties' file within ");
                p.SendMessage("%2'text/Economy/Purchasables'");
                p.SendMessage("%2'ranks.properties' file successfully created!");
            }

            if (message == "")
            {
                Help(p);
                return;
            }
            string rank = message;
            String[] strArray_rankFileDetails = File.ReadAllLines("text/Economy/Purchasables/ranks.properties");
            if (strArray_rankFileDetails[0].IndexOf("false") > 0)
            {
                for (int x = 1; x < strArray_rankFileDetails.Length; x++)
                {
                    String[] strArray_rankDetails = strArray_rankFileDetails[x].Split('!');
                    if (rank == strArray_rankDetails[1])
                    {
                        Group group = Group.Find(rank);
                        if (group.Permission > p.group.Permission)
                        {
                            int y = x - 1;
                            String[] strArray_currRankDetails = strArray_rankFileDetails[y].Split('!');
                            if (strArray_currRankDetails[1] == p.group.name)
                            {
                                if (p.money >= int.Parse(strArray_rankDetails[2]))
                                {

                                    p.money = p.money - int.Parse(strArray_rankDetails[2]);
                                    p.group.playerList.Remove(p.name);
                                    p.group.playerList.Save();
                                    group.playerList.Add(p.name);
                                    group.playerList.Save();
                                    p.SendMessage(strArray_rankDetails[2].ToString() + " " + Server.moneys + " have been removed from your savings!");
                                    p.SendMessage("%3Transaction complete! Thank you for your purchase.");
                                    p.group = group;
                                    p.color = group.color;
                                    Player.GlobalMessage(string.Concat((string[])new string[] { p.color, p.name, Server.DefaultColor, " %3just purchased the " + group.color + group.name + " %3rank!" }));
                                    Player.GlobalMessage(string.Concat((string[])new string[] { "%3Be sure to congradulate them!" }));
                                    return;
                                }
                                else
                                {
                                    p.SendMessage("%3Insufficient " + Server.moneys + " to buy rank :: " + strArray_rankDetails[1]);
                                    p.SendMessage("%3You lack, %2" + (int.Parse(strArray_rankDetails[2]) - p.money) + " %3" + Server.moneys + "!");
                                    return;
                                }
                            }
                            else
                            {

                                Group nextRank = Group.Find(strArray_rankDetails[1]);
                                p.SendMessage("%3You may not skip ranks!");
                                p.SendMessage("%3Your next buyable rank is " + nextRank.color + nextRank.name + " for :: &a" + strArray_rankDetails[2] + " %3" + Server.moneys + "!");
                                return;
                            }
                        }
                        else
                        {
                            p.SendMessage("%3You cannot buy a rank that is lower or equal to that of your current!");
                        }
                    }
                    else
                    {
                        if (x == (strArray_rankFileDetails.Length - 1) && rank != strArray_rankDetails[1])
                        {
                            p.SendMessage("The rank specified does not exist!");
                        }
                    }
                }
            }
            else
            {

                for (int x = 0; x < strArray_rankFileDetails.Length; x++)
                {
                    String[] strArray_rankDetails = strArray_rankFileDetails[x].Split('!');
                    if (rank == strArray_rankDetails[1])
                    {
                        Group group = Group.Find(rank);
                        if (group.Permission > p.group.Permission)
                        {
                            if (p.money >= int.Parse(strArray_rankDetails[2]))
                            {

                                p.money = p.money - int.Parse(strArray_rankDetails[2]);
                                p.group.playerList.Remove(p.name);
                                p.group.playerList.Save();
                                group.playerList.Add(p.name);
                                group.playerList.Save();
                                p.SendMessage(strArray_rankDetails[2].ToString() + " " + Server.moneys + " have been removed from your savings!");
                                p.SendMessage("%3Transaction complete! Thank you for your purchase.");
                                p.group = group;
                                p.color = group.color;
                                Player.GlobalMessage(string.Concat((string[])new string[] { p.color, p.name, Server.DefaultColor, " %3just purchased the " + group.color + group.name + " %3rank!" }));
                                Player.GlobalMessage(string.Concat((string[])new string[] { "%3Be sure to congradulate them!" }));
                                return;
                            }
                            else
                            {
                                p.SendMessage("%3Insufficient " + Server.moneys + " to buy rank :: " + strArray_rankDetails[1]);
                                p.SendMessage("%3You lack, %2" + (int.Parse(strArray_rankDetails[2]) - p.money) + " %3" + Server.moneys + "!");
                                return;
                            }
                        }
                        else
                        {
                            p.SendMessage("%3You cannot buy a rank that is lower or equal to that of your current!");
                        }
                    }
                    else
                    {
                        if (x == (strArray_rankFileDetails.Length - 1) && rank != strArray_rankDetails[1])
                        {
                            p.SendMessage("The rank specified does not exist!");
                        }
                    }
                }
            }
        }

      // This one controls what happens when you use /help [commandname].
      public override void Help(Player p)
      {
         Player.SendMessage(p, "/buyrank <rankname> - purchases the rank specified.");
      }
   }
}

/*
    Things to come :: Will implement the ability to add a time variable to the
    conditions for the buyrank command. This will mean that a person will need
    both the funds and the time spent on the server in order to buy the rank.
    If you wish for a person to not be able to buy the rank, remove it from the
    properties file!

    To view the properties file, just open it with notepad, wordpad, or any other
    generic text viewing software.
*/
