//coded by tommyz_
using System;

namespace MCForge
{
    public class Cmdkiss : Command
    {
        public override string name { get { return "kiss"; } }
        public override string shortcut { get { return "k"; } }
        public override string type { get { return "fun"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public Cmdkiss() { }

        public override void Use(Player p, string message)
        {
            if (message == "")
            {
                Help(p);
            }
            else
            {
                Player who = Player.Find(message);
                if (who == null)
                {
                    Player.SendMessage(p, "The player you entered does not exist!"); return;
                }


                if (!Server.voting)
                {

                    Server.voting = true;
                    Server.NoVotes = 0;
                    Server.YesVotes = 0;
                    Player.SendMessage(p, "You have just sent a kiss request to: " + c.red + who.name);
                    Player.SendMessage(who, p.name + c.red + " is trying to kiss you, would you like to kiss" + (p.name + p.color) + "back?" + "(" + c.green + "Yes " + Server.DefaultColor + "/" + c.red + "No" + Server.DefaultColor + ")");
                    System.Threading.Thread.Sleep(15000);
                    Server.voting = false;
                    //  Player.GlobalMessage("The vote is in! " + c.green + "Y: " + Server.YesVotes + c.red + " N: " + Server.NoVotes);

                    Player.players.ForEach(delegate(Player winners)
                    {
                        winners.voted = false;
                    });

                    if (Server.YesVotes >= 1)
                    { Player.GlobalMessage(c.green + p.name + c.pink + " has just kissed " + c.red + who.name + "!"); return; }
                    if (Server.NoVotes >= 1)
                    { Player.SendMessage(p, c.red + who.name + c.lime + " has refused to kiss you!"); return; }
                    if (Server.YesVotes < 1 && Server.NoVotes < 1)
                    { Player.SendMessage(p, c.red + who.name + c.lime + " never said she wanted to kiss you, so the answer is no."); return; }
                }
                else
                {
                    p.SendMessage("A vote is in progress!");
                }
            }
        }
        public override void Help(Player p)
        {
            p.SendMessage("/kiss [name] - Lets you ask someone to kiss them!");
        }
    }
}


