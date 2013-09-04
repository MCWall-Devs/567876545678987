/*
   Auto-generated command skeleton class.

   Use this as a basis for custom commands implemented via the MCLawl scripting framework.
   File and class should be named a specific way.  For example, /update is named 'CmdUpdate.cs' for the file, and 'CmdUpdate' for the class.
*/

// Add any other using statements you need up here, of course.
// As a note, MCLawl is designed for .NET 3.5.
using System;
using MCForge;

namespace MCForge
{
    public class Cmdslapall : Command
    {
        // The command's name, in all lowercase.  What you'll be putting behind the slash when using it.
        public override string name { get { return "slapall"; } }

        // Command's shortcut (please take care not to use an existing one, or you may have issues.
        public override string shortcut { get { return ""; } }

        // Determines which submenu the command displays in under /help.
        public override string type { get { return "fun"; } }

        // Determines whether or not this command can be used in a museum.  Block/map altering commands should be made false to avoid errors.
        public override bool museumUsable { get { return false; } }

        // Determines the command's default rank.  Valid values are:
        // LevelPermission.Nobody, LevelPermission.Banned, LevelPermission.Admin
        // LevelPermission.Builder, LevelPermission.AdvBuilder, LevelPermission.Operator, LevelPermission.Admin
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }

        // This is where the magic happens, naturally.
        // p is the player object for the player executing the command.  message is everything after the command invocation itself.
        public override void Use(Player p, string message)
        {
            if (message == "") { Help(p); return; }
            Player who = Player.Find(message);
            if (message.ToLower() == "all")
            {
                foreach (Player pl in Player.players)
                {
                    if (pl.name == "elvisap" | p.group.Permission <= pl.group.Permission)
                    {
                        Player.SendMessage(p, "You slapped them half way to space");
                    }
                    else
                    {
                        Command.all.Find("slap").Use(p, pl.name);
                    }
                }
            }



        }

        // This one controls what happens when you use /help [commandname].
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/slapall - slaps everyone in the server, no matter the rank.");
        }
    }
}
