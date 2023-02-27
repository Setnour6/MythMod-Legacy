using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
	// Token: 0x02000E8F RID: 3727
    public class 石榴石 : ModTile
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
			this.dustType = 119;
			this.soundType = 21;
			this.soundStyle = 2;
            this.drop = base.mod.ItemType("Garnet");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("石榴石");
			base.AddMapEntry(new Color(211, 14, 68), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "石榴石");
		}
	}
}
