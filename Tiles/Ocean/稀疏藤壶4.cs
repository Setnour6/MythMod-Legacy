using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Ocean
{
	public class 稀疏藤壶4 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                36,
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateWidth = 36;
            TileObjectData.addTile((int)base.Type);
			this.DustType = 7;
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = Mod.Find<ModItem>("Barnacle").Type;
            LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("藤壶");
			base.AddMapEntry(new Color(178, 178 ,138), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "藤壶");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, Mod.Find<ModItem>("Barnacle").Type, 1, false, 0, false, false);
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            int num = Main.rand.Next(0, 18) * 2;
            int num2 = Main.rand.Next(0, 18) * 2;
            Main.tile[i, j].TileFrameX = (short)num;
            Main.tile[i, j].TileFrameY = (short)num2;
        }
    }
}
