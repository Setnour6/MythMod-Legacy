using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.砖块
{
    public class 橄榄石晶莹宝石块 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
			this.DustType = 163;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("OlivineBrick").Type;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("橄榄石晶莹宝石块");
			base.AddMapEntry(new Color(87, 150, 0), modTranslation);
			this.MineResist = 5f;
			this.HitSound = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "橄榄石晶莹宝石块");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.375f;
            g = 0.975f;
            b = 0f;
            return;
        }
    }
}
