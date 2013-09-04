using System;

namespace MCForge
{
    public class CmdWelcome : Command
    {
        public override string name { get { return "welcome"; } }
        public override string shortcut { get { return "w"; } }
        public override string type { get { return "custom"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            {
                if (message != "")
                {
                    if (p.name == who.name)
                    {
                        Player.SendMessage(p, "You cant welcome yourself dummie");
                        return;
                    }
                    else
                    {
                        Player.GlobalMessage(p.color + p.name + " &eWelcomes " + who.color + who.name + " &eTo The Server");
                    }
                }
                else
                {
                    Player.GlobalMessage(p.color + p.name + " &eWelcomes You To The Server.");
                }
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/welcome <name> - if no name is givin it will show the default welcome.");

        }
    }
}