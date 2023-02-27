using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class 火烧云 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
            Main.tileNoSunLight[(int)base.Type] = true;
            Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = false;
            Main.tileBlockLight[(int)base.Type] = false;
            Main.tileValue[(int)base.Type] = 0;
            this.minPick = 0;
			this.dustType = 55;
            this.drop = base.mod.ItemType("RedCloud");
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(255, 222, 173), modTranslation);
			this.mineResist = 5f;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = false;
            modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
