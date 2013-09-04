using System;
using System.Threading;
namespace MCForge
{
    public class Cmdfakechat : Command
    {
        public override string name { get { return "fakechat"; } }
        public override string shortcut { get { return "fc"; } }
        public override string type { get { return "fun"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public override void Use(Player p, string message)
        {
            if (message == "")
            {
                this.Help(p);
            }

            if (message.Split(new char[] { ' ' }).Length == 1)
            { Player.SendMessage(p, "Please enter a name with message. EX: /fc notch hello i love pizza!"); return; }

            else
            {
                string str = message.Split(new char[] { ' ' })[0].ToLower();

                if (str == "notch")
                {

                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%eCreator%9] Notch: %f" + message);
                }
                if (str == "honeydew")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%8[%6DWARF%8] HoneyDew: %f" + message);
                }
                if (str == "selena")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%eActress%d] Selena Gomez: %f" + message);
                }
                if (str == "justin")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%eISuckAtSinging%9] Justin Beiber: %f" + message);
                }
                if (str == "katy")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%5IKissedAGirl%d] Katy Perry: %f" + message);
                }
                if (str == "stewie")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%c[%aMommy!%c] Stewie: %f" + message);
                }
                if (str == "Rebecca")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%c[%dISUCKATSINGING%c] Rebecca Black: %f" + message);
                }
                if (str == "console")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage(Server.DefaultColor + "Console " + "%1[%a" + p.name + "%1]" + ": %f" + message);
                }
                if (str == "charlie")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%c[%aIMAWESOME%c] Charlie Sheen: %f" + message);
                }
                if (str == "miley")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%5Ima Smoker%d] Miley Cyrus: %f" + message);
                }
                if (str == "tom")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%a[%9Actor%a] Tom Cruise: %f" + message);
                }
                if (str == "arnold")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%4Admin%9] Arnold Schwarzenegger: %f" + message);
                }
                if (str == "luke")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%2[%cJedi%2] Luke Skywalker: %f" + message);
                }
                if (str == "vader")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%0[%4Evil%0] Darth Vader: %f" + message);
                }
                if (str == "lucas")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%eDirector%4] George Lucas: %f" + message);
                }
                if (str == "megan")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%6[%5Actress%6] Megan Foxx: %f" + message);
                }
                if (str == "eminem")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%aRapper%9] Eminem: %f" + message);
                }
                if (str == "jerry")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%eCelebrity%9] Jerry Springer: %f" + message);
                }
                if (str == "cj")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%eGangsta%4] Carl Johnson: %f" + message);
                }
                if (str == "chuck")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%0Badass%4] Chuck Norris: %f" + message);
                }
                if (str == "caveman")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%0Gieco%4] Caveman: %f" + message);
                }
                if (str == "john")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("&4[&eReverend&4] Reverend_John: %f" + message);
                }
                if (str == "herobrine")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("&a[&4Master&a] Herobrine: %f" + message);
                }
                if (str == "ninja")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%0Killer%4] Ninja: %f" + message);
                }
                if (str == "jackson")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%8[%5Thriller%8] Michael Jackson: %f" + message);
                }
                if (str == "chief")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%9Haloman%4] Master Chief: %f" + message);
                }
                if (str == "barney")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%5I_Love_You%d] Barney: %f" + message);
                }
                if (str == "william")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%8[%cPoet%8] William Shakesphere: %f" + message);
                }
                if (str == "gaga")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%6Pokerface%d] Lady Gaga: %f" + message);
                }
                if (str == "austin")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%e[%aGroovy%e] Austin Powers: %f" + message);
                }
                if (str == "chucky")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%c[%0Killerdoll%c] Chucky: %f" + message);
                }
                if (str == "shatner")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%6Negotiator%9] William Shatner: %f" + message);
                }
                if (str == "elvis")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%cRocken%9] Elvis Presley: %f" + message);
                }
                if (str == "donald")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%aYou're Fired!%4] Donald Trump: %f" + message);
                }
                if (str == "simon")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%0Judge%9] Simon Cowell: %f" + message);
                }
                if (str == "harry")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%cWizard%9] Harry Potter: %f" + message);
                }
                if (str == "ron")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%cWizard%4] Ron Weasley: %f" + message);
                }
                if (str == "hermione")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%5[%dWitch%5] Hermione Granger: %f" + message);
                }
                if (str == "elmo")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%c[%4Puppetball%c] Elmo: %f" + message);
                }
                if (str == "vin")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%0Badass%9] Vin Diesel: %f" + message);
                }
                if (str == "pikachu")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%e[%9Pokemon%e] Pikachu: %f" + message);
                }
                if (str == "xephos")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%eMonkeys%9] Xephos: %f" + message);
                }
                if (str == "voldemort")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%e[%9Wizard%e] Lord Voldemort: %f" + message);
                }
                if (str == "deadmau")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%a[%eElectro%a] DeadMau5: %f" + message);
                }
                if (str == "drevil")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%7[%0Evil%7] Dr. Evil: %f" + message);
                }
                if (str == "mario")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%0Smash%4] Mario: %f" + message);
                }
                if (str == "luigi")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%a[%0Smash%a] luigi: %f" + message);
                }
                if (str == "oprah")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%d[%eCelebrity%d] Oprah Winfrey: %f" + message);
                }
                if (str == "drphil")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%8[%9Celebrity%8] Dr. Phil: %f" + message);
                }
                if (str == "smeagol")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%8[%6Precious%8] Smeagol: %f" + message);
                }
                if (str == "tommyz")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%1Coder%4] tommyz_: %f" + message);
                }
                if (str == "hagrid")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%cWizard%9] Hagrid: %f" + message);
                }
                if (str == "gandalf")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%9[%5Wizard%9] Gandalf: %f" + message);
                }
                if (str == "peter")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%e[%cActor%e] Peter Griffin: %f" + message);
                }
                if (str == "ash")
                {
                    message = message.Substring(message.IndexOf(' ') + 1);
                    Player.GlobalMessage("%4[%9Trainer%4] Ash Ketchum: %f" + message);
                }
                // else 
                //  {
                //      message = message.Substring(message.IndexOf(' ') + 1);
                //     Player.GlobalMessage("%4[%0Admin%4] " + str + ": %f" + message);
                // }  
            }
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/fakechat <person> <message> - Makes a fake person talk.");
            Player.SendMessage(p, "People include: notch, honeydew, xephos, selena, justin, katy, stewie, peter, rebecca, console, charlie, miley, tom, arnold, luke, vader, lucas, megan, eminem, jerry, cj, chuck, caveman, john, herobrine, ninja, jackson, chief, barney, william, gaga, austin, chucky, shatner, elvis, donald, simon, harry, ron, voldemort, hermione, hagrid, elmo, vin, pikachu, deadmau, drevil, luigi, mario, drphil, oprah, tommyz, smeagol, gandalf, ash.");
            Player.SendMessage(p, "Shortcut: /fc");
        }
    }
}










