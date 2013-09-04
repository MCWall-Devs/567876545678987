using MCForge;
using System.Timers;
public class CmdVotedemote : Command
{
    // Methods
    public override string type { get { return "voting"; } }
    public override void Help(Player p)
    {
        p.SendMessage("/votedemote <player> - Calls a 30sec vote to demote <player>");
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
                Player.GlobalChat(p, p.color + p.name + " " + Server.DefaultColor + "tried to votedemote " + who.color + who.name + " " + Server.DefaultColor + "and failed!", false);
            }
            else
            {
                Player.GlobalMessageOps(p.color + p.name + Server.DefaultColor + " used &a/votedemote");
                Player.GlobalMessage("&4A vote to demote " + who.color + who.name + " " + Server.DefaultColor + "has been called!");
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
                    Server.s.Log(string.Concat(new object[] { "Votedemote results for ", who.name, ": ", votesYes, " yes and ", votesNo, " no votes." }), false);
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
                        for (int i = Group.GroupList.Count - 1; i >= 0; i--)
                        {
                            Group group3 = Group.GroupList[i];
                            if (flag)
                            {
                                if (group3.Permission > LevelPermission.Banned)
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
                        else
                        {
                            Player.SendMessage(p, "No higher ranks exist");
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
            return "votedemote";
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