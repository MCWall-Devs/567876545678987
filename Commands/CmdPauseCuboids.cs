using System;

namespace MCForge.Commands
{
    public class CmdPauseCuboids : Command
    {
        public override string name { get { return "pausecuboids"; } }
        public override string shortcut { get { return new string[] { "pc", "pcuboids" }; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdPauseCuboids() { }

        public override void Use(Player p, string message)
        {
            if (Server.throttle == 0) { Player.SendMessage(p, "Building commands throttling is currently off."); return; }
            if (!Server.pauseCuboids)
            {
                Server.pauseCuboids = true;
                Player.SendMessage(p, "Paused all active cuboids. Type /pausecuboids again to resume.");
            }
            else
            {
                Server.pauseCuboids = false;
                Player.SendMessage(p, "Resumed all paused cuboids.");
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/pausecuboids - Pause/resume all active cuboids.");
        }
    }
}
