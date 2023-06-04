using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;

namespace MythMod.Tiles.Festivals
{
	public class 元宝 : ModTile
	{
		private float num5 = 0;
		private int num6 = 0;
		public override void SetStaticDefaults()
		{
			Main.tileShine[(int)base.Type] = 800;
			Main.tileSolid[(int)base.Type] = false;
			Main.tileSolidTop[(int)base.Type] = false;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile((int)base.Type);
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("Currency Bar");
			base.AddMapEntry(new Color(224, 194, 101), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "元宝");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			switch (Main.tile[i, j].TileFrameX / 18)
			{
			case 0:
				type = 12;
				break;
			case 1:
				type = 11;
				break;
			case 2:
				type = 10;
				break;
			case 3:
				type = 13;
				break;
            case 4:
				type = 49;
				break;
			default:
				return false;
			}
			return true;
		}
		public override bool Drop(int i, int j)/* tModPorter Note: Removed. Use CanDrop to decide if an item should drop. Use GetItemDrops to decide which item drops. Item drops based on placeStyle are handled automatically now, so this method might be able to be removed altogether. */
		{
			string text;
			switch (Main.tile[i, j].TileFrameX / 18)
			{
			case 0:
                text = "CuYuanbao";
				break;
			case 1:
                text = "AgYuanbao";
				break;
			case 2:
                text = "AuYuanbao";
				break;
			case 3:
				text = "CYuanbao";
				break;
            case 4:
				text = "PtYuanbao";
				break;
			default:
				return false;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, base.Mod.Find<ModItem>(text).Type, 1, false, 0, false, false);
			return false;
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
		}
	}
}
