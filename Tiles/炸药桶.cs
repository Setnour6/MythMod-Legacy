using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	// Token: 0x02000CB2 RID: 3250
	public class 炸药桶 : ModTile
	{
		// Token: 0x06004151 RID: 16721 RVA: 0x0032B0F4 File Offset: 0x003292F4
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("炸药桶");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "炸药桶");
		}

		// Token: 0x06004152 RID: 16722 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}

		// Token: 0x06004153 RID: 16723 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
		// Token: 0x06004155 RID: 16725 RVA: 0x0032B204 File Offset: 0x00329404
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 16, base.mod.ItemType("TNTBoom"), 1, false, 0, false, false);
		}

		// Token: 0x06004156 RID: 16726 RVA: 0x0032B238 File Offset: 0x00329438
		public override void HitWire(int i, int j)
		{
			int num = i - (int)(Main.tile[i, j].frameX / 18 % 2);
			int num2 = j - (int)(Main.tile[i, j].frameY / 18 % 2);
			for (int k = num; k < num + 2; k++)
			{
				for (int l = num2; l < num2 + 2; l++)
				{
					if (Main.tile[k, l] == null)
					{
						Main.tile[k, l] = new Tile();
					}
					if (Main.tile[k, l].active() && Main.tile[k, l].type == base.Type)
					{
                        Projectile.NewProjectile(i * 16 - 200, j * 16 - 40, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16, j * 16 - 40, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16 + 200, j * 16 - 40, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16, j * 16 - 240, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16, j * 16 + 160, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16 + 112, j * 16 - 40 + 112, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16 - 112, j * 16 - 40 + 112, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16 + 112, j * 16 - 40 - 112, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(i * 16 - 112, j * 16 - 40 - 112, 0, -2, 108, 600, 0, Main.myPlayer, 10, 0f);
                        Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), i * 16, j *16);
                        for (int k2 = 0; k2 <= 10; k2++)
                        {
                            float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                            float m = (float)Main.rand.Next(0, 50000);
                            float l2 = (float)Main.rand.Next((int)m, 50000) / 1800f;
                            int num4 = Projectile.NewProjectile(i * 16, j * 16, (float)((float)l2 * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), 200, 10, Main.myPlayer, 0f, 0f);
                            Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
                        }
                        for (int k2 = 0; k2 <= 10; k2++)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                            int num4 = Projectile.NewProjectile(i * 16 + v.X, j * 16 + v.Y, 0, 0, base.mod.ProjectileType("爆炸效果光"), 600, 10, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(i * 16, j * 16, 0, 0, base.mod.ProjectileType("火球冲击波"), 0, 0, Main.myPlayer, 0f, 0f);
                        }
                        Main.tile[k, l].active(false);
                    }
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(num, num2);
				Wiring.SkipWire(num, num2 + 1);
				Wiring.SkipWire(num + 1, num2);
				Wiring.SkipWire(num + 1, num2 + 1);
			}
		}
	}
}
