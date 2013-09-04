using MCForge;
using System.Timers;
public class CmdVotejail : Command
{
    // Methods
    public override string type { get { return "voting"; } }
    public override void Help(Player p)
    {
        p.SendMessage("/votejail <player> - Calls a 30sec vote to jail <player>");
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
                Player.GlobalChat(p, p.color + p.name + " " + Server.DefaultColor + "tried to votejail " + who.color + who.name + " " + Server.DefaultColor + "and failed!", false);
            }
            else
            {
                Player.GlobalMessageOps(p.color + p.name + Server.DefaultColor + " used &a/votejail");
                Player.GlobalMessage("&4A vote to jail " + who.color + who.name + " " + Server.DefaultColor + "has been called!");
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
                    Server.s.Log(string.Concat(new object[] { "Votejail results for ", who.name, ": ", votesYes, " yes and ", votesNo, " no votes." }), false);
                    if ((votesYes + votesNo) < Server.voteKickVotesNeeded)
                    {
                        Player.GlobalMessage("Not enough votes were made. " + who.color + who.name + " " + Server.DefaultColor + "shall remain where they were!");
                    }
                    else if (num > 0)
                    {
                        if ((message.ToLower() == "set") && (p != null))
                        {
                            p.level.jailx = p.pos[0];
                            p.level.jaily = p.pos[1];
                            p.level.jailz = p.pos[2];
                            p.level.jailrotx = p.rot[0];
                            p.level.jailroty = p.rot[1];
                            Player.SendMessage(p, "Set Jail point.");
                        }
                        else
                        {
                            Player from = Player.Find(message);
                            if (from != null)
                            {
                                if (!from.jailed)
                                {
                                    if ((p != null) && (from.group.Permission >= p.group.Permission))
                                    {
                                        Player.SendMessage(p, "Cannot jail someone of equal or greater rank.");
                                    }
                                    else
                                    {
                                        Player.GlobalDie(from, false);
                                        Player.GlobalSpawn(from, p.level.jailx, p.level.jaily, p.level.jailz, p.level.jailrotx, p.level.jailroty, true, "");
                                        from.jailed = true;
                                        Player.GlobalChat(null, "%4A crowd of people riot! " + from.color + from.name + Server.DefaultColor + " was &8jailed", false);
                                    }
                                }
                                else
                                {
                                    from.jailed = false;
                                    Player.GlobalChat(null, "%4A crowd of people riot! " + from.color + from.name + Server.DefaultColor + " was &afreed" + Server.DefaultColor + " from jail", false);
                                }
                            }
                            else
                            {
                                Player.SendMessage(p, "Could not find specified player.");
                            }
                        }


                    }
                    else
                    {
                        Player.GlobalMessage(who.color + who.name + " " + Server.DefaultColor + "shall remain where they were!");
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
            return "votejail";
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