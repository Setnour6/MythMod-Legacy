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
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
			Projectile.timeLeft = 3000;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int u = 0; u < 5; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 100, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
            Projectile.Kill();
            return false;
		}

		public override void AI()
		{
            Projectile.rotation += 0.15f;
            Projectile.velocity *= 0.99f;
            Projectile.velocity.Y += 0.3f;
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/激光手里剑Glow"), base.Projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.Projectile.rotation, new Vector2(11f, 11f), 1f, SpriteEffects.None, 0f);
        }
    }
}
