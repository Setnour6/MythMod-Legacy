using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000E8F RID: 3727
    public class 硫磺矿 : ModTile
	{
		// Token: 0x060045D6 RID: 17878 RVA: 0x0027A6F0 File Offset: 0x002788F0
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileValue[(int)base.Type] = 415;
			this.minPick = 264;
			this.dustType = 113;
			this.soundType = 21;
			this.soundStyle = 2;
            this.drop = base.mod.ItemType("Sulfur");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("硫磺矿");
			base.AddMapEntry(new Color(247, 165, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "硫磺矿");
		}
	}
}
