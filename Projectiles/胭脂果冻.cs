using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200054D RID: 1357
    public class 胭脂果冻 : ModProjectile
	{
		// Token: 0x06001DBA RID: 7610 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("胭脂果冻");
            Main.projFrames[Projectile.type] = 3;
        }
        private float num16 = 0;
        // Token: 0x06001DBB RID: 7611 RVA: 0x0017EE28 File Offset: 0x0017D028
        public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 80;
			base.Projectile.timeLeft = 200;
			base.Projectile.penetrate = -1;
			base.Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            num16 += 0.15f;
            if (num16 > 3)
            {
                num16 = 0;
            }
            if (base.Projectile.frameCounter > 3)
            {
                num16 += 0.15f;
                base.Projectile.frame = (int)num16;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 2)
            {
                base.Projectile.frame = 0;
                num16 = 0;
            }
            Projectile projectile = base.Projectile;
            projectile.velocity.X = projectile.velocity.X * 0.985f;
            Projectile projectile2 = base.Projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.985f;
            Lighting.AddLight(base.Projectile.Center,0.5f, 0f, 0f);
            Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            if (projectile.timeLeft % 20 == 10)
            {
                float num = Main.rand.Next(-1000, 1000);
                float num1 = (float)(Math.Sqrt(100 - (num * num / 10000)));
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, num / 150, (float)(0 - num1) / 1.5f, base.Mod.Find<ModProjectile>("GlowingTouch").Type, (int)((double)base.Projectile.damage * 1.75), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }

		// Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 1.2f, base.Projectile.oldVelocity.Y * 1.2f, 0, default(Color), 1.5f);
			}
			float num2 = 1.566f;
			double num3 = Math.Atan2((double)base.Projectile.velocity.X, (double)base.Projectile.velocity.Y) - (double)(num2 / 2f);
			double num4 = (double)(num2 / 8f);
			if (base.Projectile.owner == Main.myPlayer)
			{
				for (int j = 0; j < 8; j++)
				{
					double num5 = num3 + num4 * (double)(j + j * j) / 2.0 + (double)(32f * (float)j);
					Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)(Math.Sin(num5) * 5.0), (float)(Math.Cos(num5) * 5.0), base.Mod.Find<ModProjectile>("荧光触须").Type, (int)((double)base.Projectile.damage * 1.75), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)(-(float)Math.Sin(num5) * 5.0), (float)(-(float)Math.Cos(num5) * 5.0), base.Mod.Find<ModProjectile>("荧光触须").Type, (int)((double)base.Projectile.damage * 1.75), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				}
			}
			SoundEngine.PlaySound(SoundID.Item105, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            target.AddBuff(70, 600);
            target.AddBuff(69, 600);
        }
	}
}
