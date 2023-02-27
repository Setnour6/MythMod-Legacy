using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200054D RID: 1357
    public class 胭脂果冻 : ModProjectile
	{
		// Token: 0x06001DBA RID: 7610 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("胭脂果冻");
            Main.projFrames[projectile.type] = 3;
        }
        private float num16 = 0;
        // Token: 0x06001DBB RID: 7611 RVA: 0x0017EE28 File Offset: 0x0017D028
        public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.alpha = 80;
			base.projectile.timeLeft = 200;
			base.projectile.penetrate = -1;
			base.projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            num16 += 0.15f;
            if (num16 > 3)
            {
                num16 = 0;
            }
            if (base.projectile.frameCounter > 3)
            {
                num16 += 0.15f;
                base.projectile.frame = (int)num16;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 2)
            {
                base.projectile.frame = 0;
                num16 = 0;
            }
            Projectile projectile = base.projectile;
            projectile.velocity.X = projectile.velocity.X * 0.985f;
            Projectile projectile2 = base.projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.985f;
            Lighting.AddLight(base.projectile.Center,0.5f, 0f, 0f);
            Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            if (projectile.timeLeft % 20 == 10)
            {
                float num = Main.rand.Next(-1000, 1000);
                float num1 = (float)(Math.Sqrt(100 - (num * num / 10000)));
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, num / 150, (float)(0 - num1) / 1.5f, base.mod.ProjectileType("GlowingTouch"), (int)((double)base.projectile.damage * 1.75), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }

		// Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 1.2f, base.projectile.oldVelocity.Y * 1.2f, 0, default(Color), 1.5f);
			}
			float num2 = 1.566f;
			double num3 = Math.Atan2((double)base.projectile.velocity.X, (double)base.projectile.velocity.Y) - (double)(num2 / 2f);
			double num4 = (double)(num2 / 8f);
			if (base.projectile.owner == Main.myPlayer)
			{
				for (int j = 0; j < 8; j++)
				{
					double num5 = num3 + num4 * (double)(j + j * j) / 2.0 + (double)(32f * (float)j);
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)(Math.Sin(num5) * 5.0), (float)(Math.Cos(num5) * 5.0), base.mod.ProjectileType("荧光触须"), (int)((double)base.projectile.damage * 1.75), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)(-(float)Math.Sin(num5) * 5.0), (float)(-(float)Math.Cos(num5) * 5.0), base.mod.ProjectileType("荧光触须"), (int)((double)base.projectile.damage * 1.75), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				}
			}
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 105, 1f, 0f);
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
	}
}
