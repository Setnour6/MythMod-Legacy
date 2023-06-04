using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
    public class NeutralBloodSword : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("神经");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 24;
            base.Projectile.tileCollide = false;
            base.Projectile.height = 24;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 120;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
			base.Projectile.scale = 1.5f;
		}
		public override void AI()
		{
            Projectile.velocity *= 0.9f;
			float num = base.Projectile.Center.X;
			float num2 = base.Projectile.Center.Y;
            if (Projectile.timeLeft <= 120)
            {
                int num3 = Dust.NewDust(base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 156, 0, 0, 0, default(Color), 1.6f * Projectile.timeLeft / 120f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity = new Vector2(0, 0);
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.23f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 2.55f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            for(int k = 0;k < 45;k++)
            {
                Vector2 v0 = Projectile.velocity.RotatedByRandom(Math.PI * 2d) * Main.rand.NextFloat(0f, Main.rand.NextFloat(0f, 1f)) * 0.1f;
                int num3 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 156, v0.X, v0.Y, 0, default(Color), 1.6f * Projectile.timeLeft / 290f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity = v0;
            }
            for (int k = 0; k < 24; k++)
            {
                Vector2 v0 = Projectile.velocity.RotatedByRandom(Math.PI * 2d) * Main.rand.NextFloat(0f, 1.5f) * 0.1f;
                int num3 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 156, v0.X, v0.Y, 0, default(Color), 1.6f * Projectile.timeLeft / 290f);
            }
            target.AddBuff(31, 300, false);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 0));
            }
        }
        // Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
        }
	}
}
