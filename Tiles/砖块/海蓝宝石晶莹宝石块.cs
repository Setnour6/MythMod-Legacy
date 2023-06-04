using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.砖块
{
    public class 海蓝宝石晶莹宝石块 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = true;
			this.DustType = 156;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("AquamarineBrick").Type;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("海蓝宝石晶莹宝石块");
			base.AddMapEntry(new Color(0, 231, 236), modTranslation);
			this.MineResist = 5f;
			this.HitSound = 21;
			Main.tileSpelunker[(int)base.Type] = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "海蓝宝石晶莹宝石块");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0;
            g = 0.9f;
            b = 0.9f;
            return;
        }
    }
}
