using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000A70 RID: 2672
    public class GarnetStaffPro : ModProjectile
	{
		// Token: 0x060031FF RID: 12799 RVA: 0x001B1094 File Offset: 0x001AF294
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.aiStyle = 1;
			base.projectile.alpha = 255;
			base.projectile.scale = 1f;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 2;
			base.projectile.timeLeft = 3600;
			this.aiType = 14;
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x001B1124 File Offset: 0x001AF324
		public override void AI()
		{
			if(base.projectile.timeLeft <= 3594)
			{
                int num = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y), 10, 10, mod.DustType("Garnet"), 0f, 0f, 100, default(Color), 1f);
                int num1 = Dust.NewDust(base.projectile.Center, 10, 10, mod.DustType("Garnet"), (float)Main.rand.Next(-130, 130) / 100f, (float)Main.rand.Next(-130, 130) / 100f, 0, default(Color), 1f);
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y), 10, 10, mod.DustType("Garnet"), 0f, 0f, 100, default(Color), 1f);
                Dust dust = Main.dust[num];
                dust = Main.dust[num];
                dust = Main.dust[num1];
                dust = Main.dust[num2];
                dust.velocity *= 0.04f;
                Main.dust[num].noGravity = true;
                Main.dust[num1].noGravity = true;
                Main.dust[num2].noGravity = true;
            }
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x001B11D8 File Offset: 0x001AF3D8
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 8; i++)
			{
				int num = Dust.NewDust(base.projectile.Center, base.projectile.width, base.projectile.height, mod.DustType("Garnet"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 2.7f);
                int num1 = Dust.NewDust(base.projectile.Center, base.projectile.width, base.projectile.height, mod.DustType("Garnet"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 2.6f);
                int num2 = Dust.NewDust(base.projectile.Center, base.projectile.width, base.projectile.height, mod.DustType("Garnet"), base.projectile.velocity.X, base.projectile.velocity.Y, 0, default(Color), 2.2f);
				Main.dust[num].noGravity = true;
                Main.dust[num1].noGravity = true;
                Main.dust[num2].noGravity = true;
			}
		}
	}
}
