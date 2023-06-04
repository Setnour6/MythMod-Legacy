using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	public class 橄榄石宝石锁 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile((int)base.Type);
			this.DustType = 7;
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("");
			modTranslation.AddTranslation(GameCulture.English, "");
            modTranslation.AddTranslation(GameCulture.Chinese, "橄榄石宝石锁");
            base.AddMapEntry(new Color(87, 150, 0), modTranslation);
        }
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 54, 32, base.Mod.Find<ModItem>("OlivineLock").Type, 1, false, 0, false, false);
		}
	}
}
