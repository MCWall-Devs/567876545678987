using MCForge;
using System.Timers;
public class CmdVoteban : Command
{
    // Methods
    public override string type { get { return "voting"; } }
    public override void Help(Player p)
    {
        p.SendMessage("/voteban <player> - Calls a 30sec vote to ban <player>");
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
                Player.GlobalChat(p, p.color + p.name + " " + Server.DefaultColor + "tried to voteban " + who.color + who.name + " " + Server.DefaultColor + "and failed!", false);
            }
            else
            {
                Player.GlobalMessageOps(p.color + p.name + Server.DefaultColor + " used &a/voteban");
                Player.GlobalMessage("&7A vote to ban " + who.color + who.name + " " + Server.DefaultColor + "has been called!");
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
                    Server.s.Log(string.Concat(new object[] { "Voteban results for ", who.name, ": ", votesYes, " yes and ", votesNo, " no votes." }), false);
                    if ((votesYes + votesNo) < Server.voteKickVotesNeeded)
                    {
                        Player.GlobalMessage("Not enough votes were made. " + who.color + who.name + " " + Server.DefaultColor + "shall remain the same rank!");
                    }
                    else if (num > 0)
                    {
                        bool flag = false;
                        bool flag2 = false;
                        if (message[0] == '#')
                        {
                            message = message.Remove(0, 1).Trim();
                            flag = true;
                            Server.s.Log("Stealth Ban Attempted", false);
                        }
                        else if (message[0] == '@')
                        {
                            flag2 = true;
                            message = message.Remove(0, 1).Trim();
                        }
                        Player from = Player.Find(message);
                        if (from == null)
                        {
                            if (!Player.ValidName(message))
                            {
                                Player.SendMessage(p, "Invalid name \"" + message + "\".");
                                return;
                            }
                            Group group = Group.findPlayerGroup(message);
                            if (group.Permission >= LevelPermission.Operator)
                            {
                                Player.SendMessage(p, "You can't ban a " + group.name + "!");
                                return;
                            }
                            if (group.Permission == LevelPermission.Banned)
                            {
                                Player.SendMessage(p, message + " is already banned.");
                                return;
                            }
                            group.playerList.Remove(message);
                            group.playerList.Save();
                            Player.GlobalMessage(message + " &f(offline)" + Server.DefaultColor + " is now &8banned" + Server.DefaultColor + "!");
                            Group.findPerm(LevelPermission.Banned).playerList.Add(message);
                        }
                        else
                        {
                            if (!Player.ValidName(from.name))
                            {
                                Player.SendMessage(p, "Invalid name \"" + from.name + "\".");
                                return;
                            }
                            if (from.group.Permission >= LevelPermission.Operator)
                            {
                                Player.SendMessage(p, "You can't ban a " + from.group.name + "!");
                                return;
                            }
                            if (from.group.Permission == LevelPermission.Banned)
                            {
                                Player.SendMessage(p, message + " is already banned.");
                                return;
                            }
                            from.group.playerList.Remove(message);
                            from.group.playerList.Save();
                            if (flag)
                            {
                                Player.GlobalMessageOps(from.color + from.name + Server.DefaultColor + " is now STEALTH &8banned" + Server.DefaultColor + "!");
                            }
                            else
                            {
                                Player.GlobalChat(from, from.color + from.name + Server.DefaultColor + " is now &8banned" + Server.DefaultColor + "!", false);
                            }
                            from.group = Group.findPerm(LevelPermission.Banned);
                            from.color = from.group.color;
                            Player.GlobalDie(from, false);
                            Player.GlobalSpawn(from, from.pos[0], from.pos[1], from.pos[2], from.rot[0], from.rot[1], false, "");
                            Group.findPerm(LevelPermission.Banned).playerList.Add(from.name);
                        }
                        Group.findPerm(LevelPermission.Banned).playerList.Save();
                        Server.s.Log("BANNED: " + message.ToLower(), false);
                        if (flag2)
                        {
                            Command.all.Find("undo").Use(p, message + " 0");
                            Command.all.Find("banip").Use(p, "@ " + message);
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
            return "voteban";
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