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
            base.DisplayName.SetDefault("蕨叶");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 3;
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.hostile = true;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 480;
			base.projectile.alpha = 255;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (initialization)
            {
				X = Main.rand.Next(0,2000);
				initialization = false;
            }
			if(base.projectile.timeLeft < 100)
			{
			    projectile.velocity *= 0.975f;
			    int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.8f * (float)base.projectile.timeLeft / 75f + 0.2f);
		    	Main.dust[r].velocity.X = 0;
		    	Main.dust[r].velocity.Y = 0;
		    	Main.dust[r].noGravity = true;
				float num = Main.rand.Next(-1000,1000) / 1000f;
				int x = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 2, 0, 0, 0, default(Color), 1f * (float)base.projectile.timeLeft / 75f + 0.2f);
			    Main.dust[x].velocity.X = (float)projectile.velocity.Y * 1f * num;
			    Main.dust[x].velocity.Y = (float)projectile.velocity.X * 1f * num;
			    Main.dust[x].noGravity = true;
				if(base.projectile.timeLeft % ((int)(29 * (float)base.projectile.timeLeft / 150f) + 1) == 1)
				{
					int num34 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, - base.projectile.velocity.Y * 1f, base.projectile.velocity.X * 1f, base.mod.ProjectileType("蕨叶散裂"), 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num34].timeLeft = 48 * base.projectile.timeLeft / 150;
					int num35 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.Y * 1f, - base.projectile.velocity.X * 1f, base.mod.ProjectileType("蕨叶散裂"), 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num35].timeLeft = 48 * base.projectile.timeLeft / 150;
				}
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
			}
			else
			{
			    int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 3f, 0, 0, 61, 0, 0, 0, default(Color), 2f);
			    Main.dust[r].velocity.X = 0;
			    Main.dust[r].velocity.Y = 0;
			    Main.dust[r].noGravity = true;
				float num = Main.rand.Next(-1000,1000) / 1000f;
				int x = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 3f, 0, 0, 2, 0, 0, 0, default(Color), 1.6f);
			    Main.dust[x].velocity.X = (float)projectile.velocity.Y * 1.4f * num;
			    Main.dust[x].velocity.Y = (float)projectile.velocity.X * 1.4f * num;
			    Main.dust[x].noGravity = true;
				if(base.projectile.timeLeft % 24 == 1)
				{
					int num36 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -base.projectile.velocity.Y, base.projectile.velocity.X, base.mod.ProjectileType("蕨叶散裂"), 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num36].timeLeft = 48;
					int num37 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.Y, -base.projectile.velocity.X, base.mod.ProjectileType("蕨叶散裂"), 444, 2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num37].timeLeft = 48;
				}
            	Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
			}
			if(X >= 1000)
			{
			    projectile.velocity = projectile.velocity.RotatedBy(Math.PI / ((float)projectile.timeLeft + 700f) * X / 750f);
			}
            else
			{
			    projectile.velocity = projectile.velocity.RotatedBy((float)(0 - Math.PI) / ((float)projectile.timeLeft + 700f) * X / 750f);
			}
		}
	}
}
