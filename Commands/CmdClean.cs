using System.Collections.Generic;
using System;
using System.Linq;
namespace MCForge.Commands
{
    public class CmdClean : Command
    {
        private List<Pos> buffer = new List<Pos>();
        private int removed = 0;
        public override string name { get { return "clean"; } }
        public override string shortcut { get { return ""; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return false; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }

        public override void Use(Player p, string message)
        {
            int currentBlock = 0;
            ushort x, y, z;
            foreach (byte block in p.level.blocks)
            {
                if (block != Block.air)
                {
                    p.level.IntToPos(currentBlock, out x, out y, out z);
                    BufferAdd(buffer, x, y, z);
                }
                currentBlock++;
            }
            buffer.ForEach(delegate(Pos pos)
            {
                if (CheckBlock(p, pos.x, pos.y, pos.z))
                {
                    p.level.Blockchange(p, pos.x, pos.y, pos.z, Block.air);
                    removed += 1;
                }
            });
            buffer.Clear();
            Player.SendMessage(p, removed.ToString() + " blocks removed");
            removed = 0;
        }
        bool CheckBlock(Player p, ushort x, ushort y, ushort z)
        {
            for (int a = -1; a <= 1; ++a)
            {
                if (a != 0)
                {
                    byte xyz = p.level.GetTile(x, y, z);
                    byte xx = p.level.GetTile((ushort)(x + a), y, z);
                    byte yy = p.level.GetTile(x, (ushort)(y + a), z);
                    byte zz = p.level.GetTile(x, y, (ushort)(z + a));
                    if (xx != Block.air)
                    {
                        return false;
                    }
                    if (yy != Block.air && yy != Block.dirt && yy != Block.grass && xyz != Block.dirt && xyz != Block.grass)
                    {
                        return false;
                    }
                    if (zz != Block.air)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        void BufferAdd(List<Pos> list, ushort x, ushort y, ushort z)
        {
            Pos pos; pos.x = x; pos.y = y; pos.z = z; list.Add(pos);
        }
        public struct Pos
        {
            public ushort x, y, z;
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/clean -- cleans up the blocks that are by themselves");
        }
    }
}
