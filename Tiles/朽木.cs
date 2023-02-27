using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class 朽木 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = false;
			Main.tileShine2[(int)base.Type] = false;
			Main.tileValue[(int)base.Type] = 0;
			this.dustType = 22;
			this.soundType = 21;
			this.soundStyle = 2;
            this.drop = base.mod.ItemType("WornWood");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(68, 65, 40), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
	}
}
