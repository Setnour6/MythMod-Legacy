using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x0200082D RID: 2093
    public class 橄榄石 : ModTile
	{
		// Token: 0x06002D78 RID: 11640 RVA: 0x0023E040 File Offset: 0x0023C240
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileValue[(int)base.Type] = 900;
			this.minPick = 264;
			this.dustType = 39;
            this.drop = base.mod.ItemType("橄榄石");
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("橄榄石");
			base.AddMapEntry(new Color(99, 173, 0), modTranslation);
			this.mineResist = 5f;
			this.soundType = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "橄榄石");
		}
        public override bool Drop(int i, int j)
        {
            Item.NewItem(i * 16, j * 16, 16, 16, base.mod.ItemType("Olivine"), 3, false, 0, false, false);
            return false;
        }
        // Token: 0x06002D7B RID: 11643 RVA: 0x0000FE19 File Offset: 0x0000E019
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
