/*
   makes people crap their pants :D
* Made by jthebigman1
*/

using System;

namespace MCForge
{
    public class Cmdcrap : Command
    {

        public override string name { get { return "crap"; } }


        public override string shortcut { get { return ""; } }


        public override string type { get { return "fun"; } }


        public override bool museumUsable { get { return false; } }




        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }



        public override void Use(Player p, string message)
        {
            Player.GlobalMessage (p.color + p.name + Server.DefaultColor + "&e just crapped their pants! "); 
        }


        public override void Help(Player p)
        {
            Player.SendMessage(p, "/crap [player] - makes someone crap their pants (:<");
        }
    }
}