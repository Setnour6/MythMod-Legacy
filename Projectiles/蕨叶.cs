using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 蕨叶 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蕨叶");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.extraUpdates = 3;
			base.Projectile.width = 8;
			base.Projectile.height = 8;
			base.Projectile.hostile = true;
			base.Projectile.friendly = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 480;
			base.Projectile.alpha = 255;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (initialization)
            {
				X = Main.rand.Next(0,2000);
				initialization = false;
            }
			if(base.Projectile.timeLeft < 100)
			{
			    Projectile.velocity *= 0.975f;
			    int r = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.8f * (float)base.Projectile.timeLeft / 75f + 0.2f);
		    	Main.dust[r].velocity.X = 0;
		    	Main.dust[r].velocity.Y = 0;
		    	Main.dust[r].noGravity = true;
				float num = Main.rand.Next(-1000,1000) / 1000f;
				int x = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 2, 0, 0, 0, default(Color), 1f * (float)base.Projectile.timeLeft / 75f + 0.2f);
			    Main.dust[x].velocity.X = (float)Projectile.velocity.Y * 1f * num;
			    Main.dust[x].velocity.Y = (float)Projectile.velocity.X * 1f * num;
			    Main.dust[x].noGravity = true;
				if(base.Projectile.timeLeft % ((int)(29 * (float)base.Projectile.timeLeft / 150f) + 1) == 1)
				{
					int num34 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, - base.Projectile.velocity.Y * 1f, base.Projectile.velocity.X * 1f, base.Mod.Find<ModProjectile>("蕨叶散裂").Type, 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 48 * base.Projectile.timeLeft / 150;
					int num35 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.Y * 1f, - base.Projectile.velocity.X * 1f, base.Mod.Find<ModProjectile>("蕨叶散裂").Type, 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].timeLeft = 48 * base.Projectile.timeLeft / 150;
				}
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
			}
			else
			{
			    int r = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 3f, 0, 0, 61, 0, 0, 0, default(Color), 2f);
			    Main.dust[r].velocity.X = 0;
			    Main.dust[r].velocity.Y = 0;
			    Main.dust[r].noGravity = true;
				float num = Main.rand.Next(-1000,1000) / 1000f;
				int x = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 3f, 0, 0, 2, 0, 0, 0, default(Color), 1.6f);
			    Main.dust[x].velocity.X = (float)Projectile.velocity.Y * 1.4f * num;
			    Main.dust[x].velocity.Y = (float)Projectile.velocity.X * 1.4f * num;
			    Main.dust[x].noGravity = true;
				if(base.Projectile.timeLeft % 24 == 1)
				{
					int num36 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -base.Projectile.velocity.Y, base.Projectile.velocity.X, base.Mod.Find<ModProjectile>("蕨叶散裂").Type, 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num36].timeLeft = 48;
					int num37 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.Y, -base.Projectile.velocity.X, base.Mod.Find<ModProjectile>("蕨叶散裂").Type, 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num37].timeLeft = 48;
				}
            	Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
			}
			if(X >= 1000)
			{
			    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / ((float)Projectile.timeLeft + 700f) * X / 750f);
			}
            else
			{
			    Projectile.velocity = Projectile.velocity.RotatedBy((float)(0 - Math.PI) / ((float)Projectile.timeLeft + 700f) * X / 750f);
			}
		}
	}
}
