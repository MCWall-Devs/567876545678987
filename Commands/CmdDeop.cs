
    using System;
    namespace MCForge.Commands
    {
       public class CmdAdmin : Command
       {
          public override string name { get { return "admin"; } }
          public override string shortcut { get { return ""; } }
          public override string type { get { return "mod"; } }
          public override bool museumUsable { get { return false; } }
          public override LevelPermission defaultRank { get { return LevelPermission.Nobody; } }
          public override void Use(Player p, string message)
          {
                     if (message == "") { Help(p); return; }

             Player who = Player.Find(message.Split(' ')[0]);
                            if (who == null)
    {
       Player.SendMessage(p, "Player is not online.");
       return;
    }
    else
          {
                  string operatorRank = Group.findPerm(LevelPermission.Admin).name;
                    Command.all.Find("setrank").Use(p, who.Name + " " +adminRank);
                    Player.GlobalMessage(who.color + who.name + Server.DefaultColor + " was ranked to the Admin rank!");
                    }
                 
                }             

          public override void Help(Player p)
          {
             Player.SendMessage(p, "/deop - Deops an op.");
          }
       }
    }
