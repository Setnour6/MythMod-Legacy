using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.ID;
using System.Threading;

namespace MythMod.Tiles.Festivals
{
	// Token: 0x02000DD9 RID: 3545
	public class 双发礼花弹发射筒 : ModTile
	{
        private int i2 = 0;
        private int j2 = 0;
        // Token: 0x0600489C RID: 18588 RVA: 0x003496D4 File Offset: 0x003478D4
        public override void SetStaticDefaults()
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
			this.DustType = 123;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            this.MineResist = 3f;
			base.SetStaticDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
            base.AddMapEntry(new Color(193, 131, 139), modTranslation);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("FireWorkBallShoutDouble").Type);
        }
        // Token: 0x0600489D RID: 18589 RVA: 0x000138D5 File Offset: 0x00011AD5
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void RightClick(int i, int j)//右击
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
                if (player.inventory[num66].type == Mod.Find<ModItem>("FireWorkBall").Type && player.inventory[num66].stack > 1)
                {
                    SoundEngine.PlaySound(SoundID.Item14, new Vector2(i * 16, (j * 16) - 15));
                    Projectile.NewProjectile(i * 16, (j * 16) - 15, Main.rand.Next(-1000, 1000) / 10000f, -5f, base.Mod.Find<ModProjectile>("FireworkExxxx").Type, 1000, 110, Main.myPlayer, 20f, 0f);
                    player.inventory[num66].stack -= 2;
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
                if (player.inventory[num66].type == Mod.Find<ModItem>("SmallFireWorkBall").Type && player.inventory[num66].stack > 1)
                {
                    SoundEngine.PlaySound(SoundID.Item14, new Vector2(i * 16, (j * 16) - 15));
                    Projectile.NewProjectile(i * 16, (j * 16) - 15, Main.rand.Next(-1000, 1000) / 10000f, -4.2f, base.Mod.Find<ModProjectile>("FireworkSxxxx").Type, 400, 110, Main.myPlayer, 20f, 0f);
                    player.inventory[num66].stack -= 2;
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
                i2 = i;
                i2 = j;
            }
            if (flag)
            {
                Main.NewText("需要两发礼花弹", 255, 255, 255);
                return;
            }
        }
    }
}
