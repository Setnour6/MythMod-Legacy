using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000A70 RID: 2672
    public class 绿松石法杖Pro : ModProjectile
	{
		// Token: 0x060031FF RID: 12799 RVA: 0x001B1094 File Offset: 0x001AF294
		public override void SetDefaults()
		{
			base.Projectile.width = 4;
			base.Projectile.height = 4;
			base.Projectile.aiStyle = 1;
			base.Projectile.alpha = 255;
			base.Projectile.scale = 1f;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = 2;
			base.Projectile.timeLeft = 3600;
			this.AIType = 14;
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x001B1124 File Offset: 0x001AF324
		public override void AI()
		{
			if(base.Projectile.timeLeft <= 3592)
			{
			    for (int i = 0; i < 2; i++)
                {
			    	int num = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), base.Projectile.width, base.Projectile.height, 220, 0f, 0f, 100, default(Color), 0.9f);
                    int num1 = Dust.NewDust(base.Projectile.Center, base.Projectile.width, base.Projectile.height, 229, (float)Main.rand.Next(-130, 130) / 100f, (float)Main.rand.Next(-130, 130) / 100f, 0, default(Color), 0.75f);
                    int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y), base.Projectile.width, base.Projectile.height, 54, 0f, 0f, 100, default(Color), 0.9f);
			    	Dust dust = Main.dust[num];
			    	dust = Main.dust[num];
                    dust.velocity *= 0.5f;
                    dust = Main.dust[num1];
                    dust.velocity *= 0.5f;
                    dust = Main.dust[num2];
			    	dust.velocity *= 0.5f;
				    Main.dust[num].noGravity = true;
                    Main.dust[num1].noGravity = true;
                    Main.dust[num2].noGravity = true;
			    }
			}
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x001B11D8 File Offset: 0x001AF3D8
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(base.Projectile.Center, base.Projectile.width, base.Projectile.height, 229, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, default(Color), 0.9f);
                int num1 = Dust.NewDust(base.Projectile.Center, base.Projectile.width, base.Projectile.height, 220, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, default(Color), 0.9f);
                int num2 = Dust.NewDust(base.Projectile.Center, base.Projectile.width, base.Projectile.height, 54, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 0, default(Color), 0.9f);
				Main.dust[num].noGravity = true;
                Main.dust[num1].noGravity = true;
                Main.dust[num2].noGravity = true;
			}
		}
	}
}
