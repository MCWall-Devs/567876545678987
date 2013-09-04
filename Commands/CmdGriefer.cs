using MCForge;
public class CmdGriefer : Command
{
    public override string name { get { return "griefer"; } }
    public override string shortcut { get { return ""; } }
    public override string type { get { return "custom"; } }
    public override bool museumUsable { get { return false; } }
    public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
    public CmdGriefer() { }
    // Methods
    public override void Help(Player p)
    {
        Player.SendMessage(p, "/griefer <player> - Griefer Command. Makes <player> Griefer Rank, undoes all, and sends them to Griefer Map.");
    }

    public override void Use(Player p, string message)
    {
        if (message == "")
        {
            this.Help(p);
        }
        else
        {
            Player player = Player.Find(message);
            if (player == null)
            {
                Player.SendMessage(p, "The Player was not found");
            }
            else
            {
                LevelPermission permission = player.group.Permission;
                Command.all.Find("setrank").Use(p, player.name + " griefer");
                Command.all.Find("title").Use(p, player.name + " Griefer");
                if (permission >= LevelPermission.Operator)
                {
                    Player.SendMessage(p, "Warning! Player was Operator rank. Do /undo manually.");
                }
                else
                {
                    Command.all.Find("undo").Use(p, player.name + " all");
                }
                Command.all.Find("goto").Use(player, "griefmap");
                Player.SendMessage(player, "You Were Flagged as a Griefer!");
                Player.SendMessage(p, "Player " + player.name + " has been set as a Griefer, and moved to Griefer Map. ");
            }
        }
    }
}