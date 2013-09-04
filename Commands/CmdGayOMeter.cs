using MCForge;
using System;

public class Cmdgayometer : Command
{
    public override string name { get { return "gayometer"; } }
    public override string shortcut { get { return "gom"; } }
    public override string type { get { return "fun"; } }
    public override bool museumUsable { get { return true; } }
    public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }

    public override void Use(Player p, string message)
    {

        Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " is using the %dGayoMeter..");
        Random rand = new Random();
        int roll = rand.Next(1, 13);
        if (roll == 1)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 0 percent gay.");
        }
        else if (roll == 2)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 10 percent gay.");
        }
        else if (roll == 3)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 20 percent gay.");
        }
        else if (roll == 4)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 30 percent gay.");
        }
        else if (roll == 5)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 40 percent gay.");
        }
        else if (roll == 6)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 50 percent gay.");
        }
        else if (roll == 7)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 60 percent gay.");
        }
        else if (roll == 8)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 70 percent gay.");
        }
        else if (roll == 9)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 80 percent gay.");
        }
        else if (roll == 10)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 90 percent gay.");
        }
        else if (roll == 11)
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 100 percent gay.");
        }
        else
        {
            System.Threading.Thread.Sleep(3000);
            Player.GlobalMessage("The GayoMeter responded: " + p.color + p.name + "&6 is 0 percent gay.");
        }
    }

    // This one controls what happens when you use /help [commandname].
    public override void Help(Player p)
    {
        Player.SendMessage(p, "/gayometer - Predicts how gay a person is.");
        Player.SendMessage(p, "Shortcut /gom");

    }
}

