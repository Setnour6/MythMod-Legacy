using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
    public class VolcanoAsh : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
            Main.tileShine2[(int)base.Type] = false;
            Main.tileValue[(int)base.Type] = 0;
            this.minPick = 264;
			this.dustType = 39;
            this.drop = base.mod.ItemType("VolcanoAsh");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("火山灰");
			base.AddMapEntry(new Color(70, 70, 70), modTranslation);
			this.mineResist = 5f;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "火山灰");
		}
        public override bool Drop(int i, int j)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, base.mod.ItemType("VolcanoAsh"), 1, false, 0, false, false);
            return false;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void RandomUpdate(int i, int j)
        {
            if (!Main.tile[i, j - 1].active())
            {
                switch (Main.rand.Next(1, 3))
                {
                    case 1:
                        WorldGen.PlaceTile(i, j - 1, mod.TileType("阴燃草"));
                        short num = (short)(Main.rand.Next(0, 23) * 18);
                        Main.tile[i, j - 1].frameX = num;
                        break;
                    case 2:
                        WorldGen.PlaceTile(i, j - 2, mod.TileType("高阴燃草"));
                        short num2 = (short)(Main.rand.Next(0, 21) * 18);
                        Main.tile[i, j - 2].frameX = num2;
                        Main.tile[i, j - 1].frameX = num2;
                        break;
                }
            }
            base.RandomUpdate(i, j);
        }
    }
}
