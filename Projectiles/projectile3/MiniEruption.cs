using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile3
{
    public class MiniEruption : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("迷你喷流");
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 50;
			base.Projectile.height = 50;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 200;
			base.Projectile.alpha = 0;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
            for (int i = 0; i < 8; i++)
            {
                int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 4f) * Math.PI + num7) * 7 / 1.5f * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 4f) * Math.PI + num7) * 7) / 1.5f * 2.88f, 100, base.Projectile.damage / 3 * 2, 0.2f, Main.myPlayer, 0f, 0f);
                Main.projectile[num2].timeLeft = 200;
                Main.projectile[num2].hostile = false;
                Main.projectile[num2].friendly = true;
            }
        }
        public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f * base.Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.6f / 255f * base.Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f);
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
			base.Projectile.velocity *= Main.rand.Next(95, 98) / 100f;
			if (Projectile.timeLeft < 180)
            {
                Projectile.scale *= 0.985f;
            }
            if(Projectile.scale < 0.1f && Projectile.ai[1] != 1)
            {
                //Vector2 v3 = projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.55f, 0.55f)) * Main.rand.Next(25, 27) / 15f / projectile.velocity.Length() * 9f;
                //int num3 = Projectile.NewProjectile((projectile.Center + projectile.velocity).X, (projectile.Center + projectile.velocity).Y, v3.X, v3.Y, 100, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
                //Main.projectile[num3].hostile = false;
                //Main.projectile[num3].friendly = true;
                Projectile.Kill();
            }
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
	}
}
