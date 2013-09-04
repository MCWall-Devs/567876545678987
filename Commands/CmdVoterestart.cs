using System;
using System.Threading;
using System.Diagnostics;

namespace MCForge
{
    public class CmdVoterestart : Command
    {
        public override string name { get { return "voterestart"; } }
        public override string shortcut { get { return "vr"; } }
        public override string type { get { return "voting"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdVoterestart() { }

        public override void Use(Player p, string message)
        {

            if (!Server.voting)
            {
                // string temp = message.Substring(0, 1) == "%" ? "" : Server.DefaultColor;
                Server.restarting = true;
                Server.voting = true;
                Server.NoVotes = 0;
                Server.YesVotes = 0;
                Player.GlobalMessage(c.yellow + "A vote to Restart the Server has been called. " + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                System.Threading.Thread.Sleep(15000);
                Server.voting = false;
                Player.GlobalMessage("The vote is in! " + c.green + "Y: " + Server.YesVotes + c.red + " N: " + Server.NoVotes);


                Player.players.ForEach(delegate(Player winners)
                {
                    winners.voted = false;
                }
                );
                if (Server.YesVotes >= 1)
                {
                    Player.GlobalMessage(c.maroon + "The Server is now Restarting........");
                    Thread.Sleep(1000);
                    int time = 10;
                    while (time != 0)
                    {
                        Player.GlobalMessage(c.maroon + "Server Restarting" + Server.DefaultColor + " in %2" + time);
                        time--;
                        Thread.Sleep(1000);
                    }

                    Command.all.Find("restart").Use(null, "");

                }
                if (Server.NoVotes >= 1)
                { Player.GlobalMessage(c.lime + "The Vote to Restart the Server has been rejected by players."); return; }
                if (Server.YesVotes < 1 && Server.NoVotes < 1)
                { Player.GlobalMessage(c.lime + "Nobody on the server voted, so the Server will remain online."); return; }
                if (Server.NoVotes == Server.YesVotes)
                { Player.GlobalMessage(c.lime + "Server cannot be restarted if votes are equal."); return; }

                int voterestart_votes_needed = (int)(Player.players.Count / 3) + 1;
                if (Server.NoVotes + Server.YesVotes < voterestart_votes_needed)
                { Player.GlobalMessage(c.lime + "Not enough votes were made, so the Server will remain online."); return; }
                // int asdf = (int)(Player.players.Count / 3) + 1;

                //  int subtracted_votes = Server.YesVotes - Server.NoVotes;

            }
            else
            {
                p.SendMessage("A vote is in progress!");
            }
        }

        public override void Help(Player p)
        {
            p.SendMessage("/voterestart - Casts a vote to restart the server!");
        }
    }
}


