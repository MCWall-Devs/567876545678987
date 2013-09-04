
    using System;
    namespace MCForge.Commands
    {
       public class CmdOp : Command
       {
          public override string name { get { return "op"; } }
          public override string shortcut { get { return ""; } }
          public override string type { get { return "mod"; } }
          public override bool museumUsable { get { return false; } }
          public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
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
                  string operatorRank = Group.findPerm(LevelPermission.Operator).name;
                    Command.all.Find("setrank").Use(p, who.PublicName + " " +operatorRank);
                    Player.GlobalMessage(who.color + who.name + Server.DefaultColor + " was ranked to Operator!");
                    }
                 
                }             

          public override void Help(Player p)
          {
             Player.SendMessage(p, "/op - Rank a player an op.");
          }
       }
    }
