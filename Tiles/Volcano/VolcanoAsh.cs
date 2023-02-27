using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
    public class VolcanoAsh : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
            Main.tileShine2[(int)base.Type] = false;
            Main.tileOreFinderPriority[(int)base.Type] = 0;
            this.MinPick = 264;
			this.DustType = 39;
            this.ItemDrop = base.Mod.Find<ModItem>("VolcanoAsh").Type;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("火山灰");
			base.AddMapEntry(new Color(70, 70, 70), modTranslation);
			this.MineResist = 5f;
			this.HitSound = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "火山灰");
		}
        public override bool Drop(int i, int j)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, base.Mod.Find<ModItem>("VolcanoAsh").Type, 1, false, 0, false, false);
            return false;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void RandomUpdate(int i, int j)
        {
            if (!Main.tile[i, j - 1].HasTile)
            {
                switch (Main.rand.Next(1, 3))
                {
                    case 1:
                        WorldGen.PlaceTile(i, j - 1, Mod.Find<ModTile>("阴燃草").Type);
                        short num = (short)(Main.rand.Next(0, 23) * 18);
                        Main.tile[i, j - 1].TileFrameX = num;
                        break;
                    case 2:
                        WorldGen.PlaceTile(i, j - 2, Mod.Find<ModTile>("高阴燃草").Type);
                        short num2 = (short)(Main.rand.Next(0, 21) * 18);
                        Main.tile[i, j - 2].TileFrameX = num2;
                        Main.tile[i, j - 1].TileFrameX = num2;
                        break;
                }
            }
            base.RandomUpdate(i, j);
        }
    }
}
