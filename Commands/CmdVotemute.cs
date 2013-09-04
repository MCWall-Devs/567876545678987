using MCForge;
using System.Timers;
public class CmdVotemute : Command
{
    // Methods
    public override string type { get { return "voting"; } }
    public override void Help(Player p)
    {
        p.SendMessage("/votemute <player> - Calls a 30sec vote to mute <player>");
    }

    public override void Use(Player p, string message)
    {
        Player who;
        Timer voteTimer;
        if ((message == "") || (message.IndexOf(' ') != -1))
        {
            this.Help(p);
        }
        else if (Server.voteKickInProgress)
        {
            p.SendMessage("Please wait for the current vote to finish!");
        }
        else
        {
            who = Player.Find(message);
            if (who == null)
            {
                Player.SendMessage(p, "Could not find player specified!");
            }
            else if (who.group.Permission >= p.group.Permission)
            {
                Player.GlobalChat(p, p.color + p.name + " " + Server.DefaultColor + "tried to votemute " + who.color + who.name + " " + Server.DefaultColor + "and failed!", false);
            }
            else
            {
                Player.GlobalMessageOps(p.color + p.name + Server.DefaultColor + " used &a/votemute");
                Player.GlobalMessage("&6A vote to mute " + who.color + who.name + " " + Server.DefaultColor + "has been called!");
                Player.GlobalMessage("&9Type &aY " + Server.DefaultColor + "or &cN &fto vote.");
                Server.voteKickVotesNeeded = (Player.players.Count / 3) + 1;
                Server.voteKickInProgress = true;
                voteTimer = new Timer(30000.0);
                voteTimer.Elapsed += delegate
                {
                    voteTimer.Stop();
                    Server.voteKickInProgress = false;
                    int votesYes = 0;
                    int votesNo = 0;
                    Player.players.ForEach(delegate(Player pl)
                    {
                        if (pl.voteKickChoice == VoteKickChoice.Yes)
                        {
                            votesYes++;
                        }
                        if (pl.voteKickChoice == VoteKickChoice.No)
                        {
                            votesNo++;
                        }
                        pl.voteKickChoice = VoteKickChoice.HasntVoted;
                    });
                    int num = votesYes - votesNo;
                    Player.GlobalMessageOps(string.Concat(new object[] { "Vote Ended.  Results: &aY: ", votesYes, " &cN: ", votesNo }));
                    Server.s.Log(string.Concat(new object[] { "Votemute results for ", who.name, ": ", votesYes, " yes and ", votesNo, " no votes." }), false);
                    if ((votesYes + votesNo) < Server.voteKickVotesNeeded)
                    {
                        Player.GlobalMessage("Not enough votes were made. " + who.color + who.name + " " + Server.DefaultColor + "shall keep their same voice");
                    }
                    else if (num > 0)
                    {
                        if ((message == "") || (message.Split(new char[] { ' ' }).Length > 2))
                        {
                            this.Help(p);
                        }
                        else
                        {
                            Player player = Player.Find(message);
                            if (player == null)
                            {
                                Player.SendMessage(p, "The player entered is not online.");
                            }
                            else if (player.muted)
                            {
                                player.muted = false;
                                Player.GlobalChat(null, "%aA crowd of people riot! " + player.color + player.name + Server.DefaultColor + " has been &bun-muted", false);
                            }
                            else if (((p != null) && (player != p)) && (player.group.Permission > p.group.Permission))
                            {
                                Player.SendMessage(p, "Cannot mute someone of a higher rank.");
                            }
                            else
                            {
                                player.muted = true;
                                Player.GlobalChat(null, "%4A crowd of people riot! " + player.color + player.name + Server.DefaultColor + " has been &8muted", false);
                            }
                        }


                    }
                    else
                    {
                        Player.GlobalMessage(who.color + who.name + " " + Server.DefaultColor + "shall keep their same voice!");
                    }
                    voteTimer.Dispose();
                };
                voteTimer.Start();
            }
        }
    }

    // Properties
    public override LevelPermission defaultRank
    {
        get
        {
            return LevelPermission.Operator;
        }
    }

    public override bool museumUsable
    {
        get
        {
            return false;
        }
    }

    public override string name
    {
        get
        {
            return "votemute";
        }
    }

    public override string shortcut
    {
        get
        {
            return "";
        }
    }

}