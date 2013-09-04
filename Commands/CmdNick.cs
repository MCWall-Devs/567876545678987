using System;

namespace MCForge
{
    public class CmdNick : Command
    {
        public override string name { get { return "nick"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public override bool museumUsable { get { return true; } }
        public CmdNick() { }

        public override void Use(Player p, string message)
        {
            if (message.Split(' ').Length > 2 || message == "") { Help(p); return; }
            Player who = null; String newName = null;

            int pos = message.IndexOf(' ');
            if (pos != -1)
            {
                newName = message.Substring(pos + 1);
                who = Player.Find(message.Substring(0, pos)); if (who == null) { Player.SendMessage(p, "The player you entered does not exist."); return; }
                if (Server.devs.Contains(message)) { Player.SendMessage(p, "You cannot have that as your nickname!"); }
            }
            else
            {
                newName = message;
                who = p;
            }

            Player.GlobalChat(p, who.color + who.name + Server.DefaultColor + "'s name was changed to " + who.color + newName, false);
            who.name = newName;
            Player.GlobalDie(who, false);
            Player.GlobalSpawn(who, who.pos[0], who.pos[1], who.pos[2], who.rot[0], who.rot[1], false);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/nick [player] <newName> - Changes the person's name.");
        }
    }
}