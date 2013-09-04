
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace MCForge.Commands
{
    public class CmdMake : Command
    {
        public override string name { get { return "make"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Nobody; } }
        public override void Use(Player p, string message)
        {
            Player player = Player.Find(message.Split(' ')[0]);
            if (player == null)
            {
                Player.SendMessage(p, "Error: Player is not online.");
            }
            else
            {
                if (p == null) { }
                else { if (player.group.Permission >= p.group.Permission) { Player.SendMessage(p, "Cannot use this on someone of equal or greater rank."); return; } }
                string command;
                string command2;
                try
                {
                    command = message.Split(' ')[1];
                    command2 = message.Split(' ')[2];
                    Command.all.Find(command).Use(player, command2);
                }
                catch
                {
                    Player.SendMessage(p, "I didn't find any parameter! Making player use command by itself...");
                    command = message.Split(' ')[1];
                    Command.all.Find(command).Use(player, "");
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/make - Make another user use a command, (/make player command parameter)");
            Player.SendMessage(p, "ex: /make hetal tp notch");
        }
    }
}
