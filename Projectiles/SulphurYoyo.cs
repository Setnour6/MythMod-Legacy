using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x02000A56 RID: 2646
	public class SulphurYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		// Token: 0x06003182 RID: 12674 RVA: 0x0000EF18 File Offset: 0x0000D118
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
        }
		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 400f, 16f);
            if (Main.rand.Next(90) == 1)
            {
                int num = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 16, 16, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                Main.dust[num].noGravity = true;
            }
            if (Main.rand.Next(90) == 1)
            {
                int num2 = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 16, 16, 88, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                Main.dust[num2].noGravity = true;
            }
            if (Main.rand.Next(12) == 1)
            {
                float num4 = (float)(Main.rand.Next(500, 4000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("硫磺火粒"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            if (X > 0)
            {
                X -= 1;
                if (Main.rand.Next(4) == 1)
                {
                    int num = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 16, 16, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num].noGravity = true;
                }
                if (Main.rand.Next(4) == 1)
                {
                    int num2 = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 16, 16, 88, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
                    Main.dust[num2].noGravity = true;
                }
                if (Main.rand.Next(2) == 1)
                {
                    float num4 = (float)(Main.rand.Next(500, 4000));
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("SulfurDust"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                }
            }
            else
            {
                X = 0;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/硫磺悠悠球Glow"), base.projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 0) * X * 0.01f, base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
        // Token: 0x06003183 RID: 12675 RVA: 0x001AA8C0 File Offset: 0x001A8AC0
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            X = 100;
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000064C1 File Offset: 0x000046C1
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            X = 100;
            return false;
		}
	}
}
