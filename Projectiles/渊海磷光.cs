﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 渊海磷光 : ModProjectile
	{
		private bool num1 = true;
		private bool num4 = true;
		private float num = 0;
		private float num2 = 0;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("渊海磷光");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 34;
			base.projectile.height = 34;
			base.projectile.hostile = true;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 240;
			this.cooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 250;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
			num2 += 1;
			if(num1)
			{
				base.projectile.timeLeft = Main.rand.Next(110, 750);
				num = Main.rand.Next(-100, 100);
				num1 = false;
			}
			float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
			base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.003f;
			if(num2 % 200 > 100 && num6 < 600f)
			{
	    		if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 5f)
	    		{
	    			base.projectile.velocity *= 1.2f;
	    		}
				if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 6f)
	    		{
	    			base.projectile.velocity *= 0.96f;
	    		}
		    	if(num > 150)
	    		{
	     			num -= Main.rand.Next(0, 5);
	     		}
		    	else if(num < -150)
	    	   	{
		    		num += Main.rand.Next(0, 5);	
		    	}
		    	else
	    		{
		    		num += Main.rand.Next(-5, 5);
		    	}
                projectile.velocity = projectile.velocity.RotatedBy(Math.PI * num / 10000f);
			}
			else
			{
				if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 5f)
	    		{
	    			base.projectile.velocity *= 1.2f;
	    		}
				if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 6f)
	    		{
	    			base.projectile.velocity *= 0.96f;
	    		}
				int num3 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
				projectile.velocity = projectile.velocity * 0.96f + (Main.player[num5].Center - base.projectile.Center) / num6 * 0.25f;
			}
            if (projectile.timeLeft < 100)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft < 60)
            {
                projectile.hostile = false;
            }
			if(projectile.timeLeft < 90)
			{
				base.projectile.scale = (float)projectile.timeLeft / 90;
				base.projectile.damage = (int)(80 * (float)projectile.scale);
				base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
			}
            else
			{
			    base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
			}
			if(projectile.timeLeft <= 10 && num4 && NPC.CountNPCS(mod.NPCType("星渊水母")) > 0)
			{
				float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
				for (int k = 0; k < 10; k++)
                {
                    float i = k + 0.5f;
                    if((int)k % 2 == 1)
                    {
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 1.08f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 1.08f, base.mod.ProjectileType("渊海磷光1"), base.projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                    }
                    else
                    {
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 2.88f, base.mod.ProjectileType("渊海磷光1"), base.projectile.damage / 2, 0.2f, Main.myPlayer, 1f, 0f);
                    }
                }
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, base.mod.ProjectileType("渊海磷光"), base.projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
				num4 = false;
			}
		}
        public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 34;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = projectile.oldPos[k / 3] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/渊海磷光光效"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/渊海磷光光效").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
