using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 34;
			base.Projectile.height = 34;
			base.Projectile.hostile = true;
			base.Projectile.friendly = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 240;
			this.CooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 250;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
			num2 += 1;
			if(num1)
			{
				base.Projectile.timeLeft = Main.rand.Next(110, 750);
				num = Main.rand.Next(-100, 100);
				num1 = false;
			}
			float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
			base.Projectile.rotation -= (float)Math.Sqrt((float)Projectile.velocity.X * (float)Projectile.velocity.X + (float)Projectile.velocity.Y * (float)Projectile.velocity.Y) * 0.003f;
			if(num2 % 200 > 100 && num6 < 600f)
			{
	    		if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 5f)
	    		{
	    			base.Projectile.velocity *= 1.2f;
	    		}
				if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 6f)
	    		{
	    			base.Projectile.velocity *= 0.96f;
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
                Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI * num / 10000f);
			}
			else
			{
				if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 5f)
	    		{
	    			base.Projectile.velocity *= 1.2f;
	    		}
				if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 6f)
	    		{
	    			base.Projectile.velocity *= 0.96f;
	    		}
				int num3 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
				Projectile.velocity = Projectile.velocity * 0.96f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 0.25f;
			}
            if (Projectile.timeLeft < 100)
            {
                Projectile.scale *= 0.95f;
            }
            if (Projectile.timeLeft < 60)
            {
                Projectile.hostile = false;
            }
			if(Projectile.timeLeft < 90)
			{
				base.Projectile.scale = (float)Projectile.timeLeft / 90;
				base.Projectile.damage = (int)(80 * (float)Projectile.scale);
				base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f);
			}
            else
			{
			    base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f);
			}
			if(Projectile.timeLeft <= 10 && num4 && NPC.CountNPCS(Mod.Find<ModNPC>("星渊水母").Type) > 0)
			{
				float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
				for (int k = 0; k < 10; k++)
                {
                    float i = k + 0.5f;
                    if((int)k % 2 == 1)
                    {
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 1.08f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 1.08f, base.Mod.Find<ModProjectile>("渊海磷光1").Type, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                    }
                    else
                    {
                        Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 2.88f, base.Mod.Find<ModProjectile>("渊海磷光1").Type, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 1f, 0f);
                    }
                }
				Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, base.Mod.Find<ModProjectile>("渊海磷光").Type, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
				num4 = false;
			}
		}
        public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 34;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = Projectile.oldPos[k / 3] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/渊海磷光光效"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/渊海磷光光效").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
