using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;
namespace MythMod.Projectiles.projectile3
{
    public class LaserKnife : ModProjectile
	{
        public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.timeLeft = 3000;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int u = 0; u < 5; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 100, (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.Kill();
            return false;
		}

		public override void AI()
		{
            projectile.rotation += 0.15f;
            projectile.velocity *= 0.99f;
            projectile.velocity.Y += 0.3f;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/激光手里剑Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(11f, 11f), 1f, SpriteEffects.None, 0f);
        }
    }
}
