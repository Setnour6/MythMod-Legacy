using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class 海蓝砖 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = false;
			Main.tileOreFinderPriority[(int)base.Type] = 0;
			this.MinPick = 224;
			this.DustType = 91;
            this.ItemDrop = base.Mod.Find<ModItem>("OceanBlueBlock").Type;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("海蓝砖");
			base.AddMapEntry(new Color(30, 144, 255), modTranslation);
			this.MineResist = 5f;
			this.HitSound = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "海蓝砖");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
