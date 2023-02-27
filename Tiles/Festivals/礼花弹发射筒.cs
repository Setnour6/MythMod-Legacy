using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ID;
using System.Threading;

namespace MythMod.Tiles.Festivals
{
	public class 礼花弹发射筒 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.addTile((int)base.Type);
			this.dustType = 123;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
            base.AddMapEntry(new Color(193, 131, 139), modTranslation);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("FireWorkBallShout"));
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void RightClick(int i, int j)
        {
            if (Main.dayTime)
            {
                Main.NewText("白天不要放烟花", 255, 255, 255);
                return;
            }
            Player player = Main.LocalPlayer;
            bool flag = true;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == mod.ItemType("FireWorkBall") && player.inventory[num66].stack > 0)
                {
                    Main.PlaySound(2, i * 16, (j * 16) - 15, 14, 1f, 0f);
                    Projectile.NewProjectile(i * 16, (j * 16) - 15, Main.rand.Next(-1000,1000) / 10000f, -5f, base.mod.ProjectileType("FireworkExx"), 1000, 110, Main.myPlayer, 0f, 0f);
                    player.inventory[num66].stack--;
                    for (int k = 0; k < 35; k++)
                    {
                        int num7 = Main.rand.Next(0, 100000);
                        int num8 = Main.rand.Next(0, (int)num7) / 10000;
                        int num6 = Dust.NewDust(new Vector2(i * 16, j * 16), 4, 4, 174, 0, -5 * (float)num8, 0, Color.Orange, 1.6f);
                        Main.dust[num6].noGravity = false;
                        Main.dust[num6].scale *= 0.8f;
                        Main.dust[num6].alpha = 200;
                        flag = false;
                        break;
                    }
                    break;
                }
                if (player.inventory[num66].type == mod.ItemType("SmallFireWorkBall") && player.inventory[num66].stack > 0)
                {
                    Main.PlaySound(2, i * 16, (j * 16) - 15, 14, 1f, 0f);
                    Projectile.NewProjectile(i * 16, (j * 16) - 15, Main.rand.Next(-1000, 1000) / 10000f, -4.2f, base.mod.ProjectileType("FireworkSxx"), 400, 110, Main.myPlayer, 0f, 0f);
                    player.inventory[num66].stack--;
                    for (int k = 0; k < 35; k++)
                    {
                        int num7 = Main.rand.Next(0, 100000);
                        int num8 = Main.rand.Next(0, (int)num7) / 10000;
                        int num6 = Dust.NewDust(new Vector2(i * 16, j * 16), 4, 4, 174, 0, -5 * (float)num8, 0, Color.Orange, 1.6f);
                        Main.dust[num6].noGravity = false;
                        Main.dust[num6].scale *= 0.8f;
                        Main.dust[num6].alpha = 200;
                        flag = false;
                        break;
                    }
                    break;
                }
            }
            if (flag)
            {
                Main.NewText("需要一发礼花弹", 255, 255, 255);
                return;
            }
        }
    }
}
