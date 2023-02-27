using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class 海蓝砖 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = false;
			Main.tileValue[(int)base.Type] = 0;
			this.minPick = 224;
			this.dustType = 91;
            this.drop = base.mod.ItemType("OceanBlueBlock");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("海蓝砖");
			base.AddMapEntry(new Color(30, 144, 255), modTranslation);
			this.mineResist = 5f;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "海蓝砖");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
