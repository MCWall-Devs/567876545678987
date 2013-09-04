using MCForge;
using System.Timers;
public class CmdVotepromote : Command
{
    // Methods
    public override string type { get { return "voting"; } }
    public override void Help(Player p)
    {
        p.SendMessage("/votepromote <player> - Calls a 30sec vote to promote <player>");
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
                Player.GlobalChat(p, p.color + p.name + " " + Server.DefaultColor + "tried to votepromote " + who.color + who.name + " " + Server.DefaultColor + "and failed!", false);
            }
            else
            {
                Player.GlobalMessageOps(p.color + p.name + Server.DefaultColor + " used &a/votepromote");
                Player.GlobalMessage("&8A vote to promote " + who.color + who.name + " " + Server.DefaultColor + "has been called!");
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
                    Server.s.Log(string.Concat(new object[] { "Votepromote results for ", who.name, ": ", votesYes, " yes and ", votesNo, " no votes." }), false);
                    if ((votesYes + votesNo) < Server.voteKickVotesNeeded)
                    {
                        Player.GlobalMessage("Not enough votes were made. " + who.color + who.name + " " + Server.DefaultColor + "shall remain the same rank!");
                    }
                    else if (num > 0)
                    {
                        string name;
                        Group group;
                        Player player = Player.Find(message);
                        if (player == null)
                        {
                            name = message;
                            group = Group.findPlayerGroup(message);
                        }
                        else
                        {
                            name = player.name;
                            group = player.group;
                        }
                        Group group2 = null;
                        bool flag = false;
                        for (int i = 0; i < Group.GroupList.Count; i++)
                        {
                            Group group3 = Group.GroupList[i];
                            if (flag)
                            {
                                if (group3.Permission < LevelPermission.Nobody)
                                {
                                    group2 = group3;
                                }
                                break;
                            }
                            if (group3 == group)
                            {
                                flag = true;
                            }
                        }
                        if (group2 != null)
                        {
                            Command.all.Find("setrank").Use(p, name + " " + group2.name);
                        }

                    }
                    else
                    {
                        Player.GlobalMessage(who.color + who.name + " " + Server.DefaultColor + "shall remain the same rank!");
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
            return "votepromote";
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