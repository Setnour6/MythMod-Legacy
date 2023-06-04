using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;

namespace MythMod.Tiles
{
	public class Bars : ModTile
	{
		private float num5 = 0;
		private int num6 = 0;
		public override void SetStaticDefaults()
		{
			Main.tileShine[(int)base.Type] = 800;
			Main.tileSolid[(int)base.Type] = true;
			Main.tileSolidTop[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLighted[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleWrapLimit = 111;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile((int)base.Type);
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("Metal Bar");
			base.AddMapEntry(new Color(224, 194, 101), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "金属棒");
		}

		// Token: 0x0600445D RID: 17501 RVA: 0x00271C44 File Offset: 0x0026FE44
		public override bool CreateDust(int i, int j, ref int type)
		{
			switch (Main.tile[i, j].TileFrameX / 18)
			{
			case 0:
				type =  Mod.Find<ModDust>("Wave").Type;
				break;
			case 1:
				type = 29;
				break;
			case 2:
				type = 59;
				break;
			case 3:
				type = 1;
				break;
			case 4:
				type = 9;
				break;
			case 5:
				type = 62;
				break;
			case 6:
				type = 173;
				break;
			case 7:
				type = 172;
				break;
			case 8:
				type = 183;
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
                text = "OceanBlueBar";
				break;
			case 1:
                text = "DarkSeaBar";
				break;
			case 2:
                text = "MoonMossBar";
				break;
			case 3:
				text = "RedDustBar";
				break;
			case 4:
				text = "IridiumBar";
				break;
			case 5:
				text = "FreFirBar";
				break;
			case 6:
				text = "PoisonFlameBar";
				break;
			case 7:
				text = "ThunderBar";
				break;
			case 8:
				text = "DragonBreathBar";
				break;
			default:
				return false;
			}
			Item.NewItem(i * 16, j * 16, 16, 48, base.Mod.Find<ModItem>(text).Type, 1, false, 0, false, false);
			return false;
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			num5 += 0.3f;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			base.AddMapEntry(new Color(159 * (int)(Math.Sin(num5 / 10000f) * 0.5 + 1), 101, 196), modTranslation);
			if (!Lighting.NotRetro)
			{
				return;
			}
			int num = (int)Main.tile[i, j].TileFrameX;
			int num2 = (int)Main.tile[i, j].TileFrameY;
			int num3 = i % 1;
			int num4 = j % 1;
			num3 *= 162;
			num4 *= 40;
			num += num3;
			num2 += num4;
			Texture2D texture = base.Mod.GetTexture("Tiles/Bars_Glowmask");
			Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X + (float)this.GetDrawOffset(), (float)(j * 16) - Main.screenPosition.Y + (float)this.GetDrawOffset());
			if (CaptureManager.Instance.IsCapturing)
			{
				position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			}
			spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(num, num2, 18, 18)), new Color((int)(120 * Math.Sin(num5 / 10000f) + 80 + num6), (int)(120 * Math.Sin(num5 / 10000f) + 80 + num6), (int)(120 * Math.Sin(num5 / 10000f) + 80 + num6), (int)(120 * Math.Sin(num5 / 10000f) + 80 + num6)), 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
            if(Main.tile[i, j + 1].Slope != 0 || Main.tile[i, j + 1].IsHalfBlock || !Main.tile[i, j + 1].HasSameSlope(Main.tile[i, j]) || !Main.tile[i, j + 1].HasTile)
            {
                WorldGen.KillTile(i, j);
            }
		}
		private int GetDrawOffset()
		{
			int num;
			if ((float)Main.screenWidth < 1664f)
			{
				num = 193;
			}
			else
			{
				num = (int)(-0.5f * (float)Main.screenWidth + 1025f);
			}
			return num - 1;
		}
	}
}
