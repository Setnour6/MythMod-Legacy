using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles
{
    public class 火烧云 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
            Main.tileNoSunLight[(int)base.Type] = true;
            Main.tileMergeDirt[(int)base.Type] = false;
			Main.tileBlockLight[(int)base.Type] = false;
            Main.tileBlockLight[(int)base.Type] = false;
            Main.tileOreFinderPriority[(int)base.Type] = 0;
            this.MinPick = 0;
			this.DustType = 55;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("RedCloud").Type;
            LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("");
			base.AddMapEntry(new Color(255, 222, 173), modTranslation);
			this.MineResist = 5f;
			this.HitSound = 21;
			Main.tileSpelunker[(int)base.Type] = false;
            modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
