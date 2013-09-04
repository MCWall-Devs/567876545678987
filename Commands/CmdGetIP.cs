using System;
using System.IO;
using MCForge;

namespace MCForge
{
    public class CmdGetIP : Command
    {
        public override string name { get { return "getip"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "custom"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdGetIP() { }

        public override void Use(Player p, string message)
        {
            Player who = null;
            if (message == "") { who = p; message = p.name; } else { who = Player.Find(message); }
            if (who != null && !who.hidden)
            {
                bool skip = false;
                if (p != null) if (p.group.Permission <= LevelPermission.AdvBuilder) skip = true;
                if (!skip)
                {
                    string givenIP;
                    if (Server.bannedIP.Contains(who.ip)) givenIP = "&8" + who.ip + ", which is banned";
                    else givenIP = who.ip;
                    Player.SendMessage(p, who.color + who.prefix + who.name + Server.DefaultColor + " has an IP of " + givenIP);

                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/getip - Displays a player's IP address");
        }
    }
}
