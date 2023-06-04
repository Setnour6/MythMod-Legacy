using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000A19 RID: 2585
	public class SulfurHammer : ModProjectile
	{
		// Token: 0x060033CB RID: 13259 RVA: 0x000109F0 File Offset: 0x0000EBF0
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("硫磺战锤");
		}

		// Token: 0x060033CC RID: 13260 RVA: 0x00287724 File Offset: 0x00285924
		public override void SetDefaults()
		{
			base.Projectile.width = 50;
			base.Projectile.height = 50;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = -1;
			base.Projectile.aiStyle = 3;
			base.Projectile.timeLeft = 600;
			this.AIType = 52;
		}

		// Token: 0x060033CD RID: 13261 RVA: 0x00287794 File Offset: 0x00285994
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.35f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f);
            if(Main.rand.Next(10) == 1)
            {
                int num = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 50, 50, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                Main.dust[num].noGravity = true;
            }
            if (Main.rand.Next(10) == 1)
            {
                int num2 = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 50, 50, 88, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                Main.dust[num2].noGravity = true;
            }
        }

        // Token: 0x060033CE RID: 13262 RVA: 0x0021D458 File Offset: 0x0021B658
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 16; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
            for (int i = 0; i <= 5; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 5000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("SulfurDust").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
        // Token: 0x060033CF RID: 13263 RVA: 0x00218984 File Offset: 0x00216B84
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.Projectile.ai[0] += 0.1f;
			if (base.Projectile.velocity.X != oldVelocity.X)
			{
				base.Projectile.velocity.X = -oldVelocity.X;
			}
			if (base.Projectile.velocity.Y != oldVelocity.Y)
			{
				base.Projectile.velocity.Y = -oldVelocity.Y;
			}
            for (int j = 0; j < 16; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
            for (int i = 0; i <= 5; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 5000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)num2, (float)num3, base.Mod.Find<ModProjectile>("SulfurDust").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            return false;
		}
	}
}
