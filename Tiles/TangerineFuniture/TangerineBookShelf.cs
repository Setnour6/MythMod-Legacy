using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.TangerineFuniture
{
	public class TangerineBookShelf : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileTable[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("年桔木书架");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.AnimationFrameHeight = 54;
			this.AdjTiles = new int[]
			{
				101
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "年桔木书架");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("TangerineBookShelf").Type, 1, false, 0, false, false);
		}
	}
}
