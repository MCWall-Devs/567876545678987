using System;
using System.Threading;

namespace MCForge
{
    public class CmdSpam : Command
    {
        /********************************************************************************************************\
        <+> Copyright 2012 Sinjai                                                                              <+>
        <+>                                                                                                    <+>
        <+> licensed under a Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License.         <+>
        <+> http://creativecommons.org/licenses/by-nc-nd/3.0/                                                  <+>
        <+>                                                                                                    <+>
        <+> This command was made for use with MCForge only.                                                   <+>
        <+> You must attribute the work in the manner specified by the author or licensor.                     <+>
        <+> You may not use this work for commercial purposes.                                                 <+>
        <+> You may not alter, transform, or build upon this work.                                             <+>
        <+>                                                                                                    <+>
        <+> Any of the above conditions can be waived if you get written permission from the copyright holder. <+>
        \********************************************************************************************************/
        public override string name { get { return "spam"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "custom"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public override void Use(Player p, string message)
        {
            int amt = int.Parse(message.Split(' ')[0]);
            string msg = message.Substring(message.IndexOf(' ') + 1);
            int i = 0;
            for (i = 0; i < amt; i++)
            {
                Player.GlobalMessage(msg);
                Thread.Sleep(450);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/spam [number] [message] - spams the [message] [number] of times");
        }
    }
}