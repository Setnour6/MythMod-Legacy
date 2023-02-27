using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	public class 绿松石锁 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile((int)base.Type);
			this.dustType = 7;
			this.disableSmartCursor = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("");
			modTranslation.AddTranslation(GameCulture.English, "");
            base.AddMapEntry(new Color(22, 204, 179), modTranslation);
        }
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 54, 32, base.mod.ItemType("TurquoiseLock"), 1, false, 0, false, false);
		}
	}
}
