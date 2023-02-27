using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 藤蔓散裂友好 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		private int num;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("藤蔓");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 3;
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 300;
			base.projectile.alpha = 255;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (initialization)
            {
				int num = Main.rand.Next(0,100000);
                X = Main.rand.Next(0,2000) / 1000f;
				initialization = false;
            }
			if(base.projectile.timeLeft < 75)
			{
				if(num >= 50000)
				{
			        projectile.velocity = projectile.velocity.RotatedBy(Math.PI / -20f);
			    	projectile.velocity *= 0.975f;
			    	int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.2f * (float)base.projectile.timeLeft / 75f + 0.2f);
		    	    Main.dust[r].velocity.X = 0;
		    	    Main.dust[r].velocity.Y = 0;
		    	    Main.dust[r].noGravity = true;
                	Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
				}
				else
				{
					projectile.velocity = projectile.velocity.RotatedBy(Math.PI / 20f);
			    	projectile.velocity *= 0.975f;
			    	int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.2f * (float)base.projectile.timeLeft / 75f + 0.2f);
		    	    Main.dust[r].velocity.X = 0;
		    	    Main.dust[r].velocity.Y = 0;
		    	    Main.dust[r].noGravity = true;
                	Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
				}
			}
			else
			{
				X += 1 / 30f;
			    projectile.velocity = projectile.velocity.RotatedBy(Math.PI / 60f * (float)Math.Sin(X * Math.PI));
			    int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 1.4f);
			    Main.dust[r].velocity.X = 0;
			    Main.dust[r].velocity.Y = 0;
			    Main.dust[r].noGravity = true;
            	Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
			}
		}
	}
}
