using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	class StormUnderTheSea : ModProjectile
	{
		public override void SetDefaults()
		{
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 54;
			projectile.height = 60;
			projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.timeLeft = 3000;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Die immediately if ai[1] isn't 0 (We set this to 1 for the 5 extra explosives we spawn in Kill)
			if(projectile.timeLeft > 2850)
            {
                if (projectile.ai[1] != 0)
                {
                    return true;
                }
                projectile.soundDelay = 10;

                // This code makes the projectile very bouncy.
                if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
                {
                    projectile.velocity.X = oldVelocity.X * -0.9f;
                }
                if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
                {
                    projectile.velocity.Y = oldVelocity.Y * -0.9f;
                }
            }
			return false;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.damage += 50;
            target.AddBuff(24, 600);
        }
        public override void AI()
		{
            float num7 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + base.projectile.velocity.Y * base.projectile.velocity.Y);
            int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            projectile.rotation += 0.05f * num7;
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
            if (projectile.timeLeft <= 2850)
            {
                if (num7 < 5f)
                {
                    base.projectile.velocity *= 1.2f;
                }
                if (num7 > 6f)
                {
                    base.projectile.velocity *= 0.96f;
                }
                int num3 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                projectile.velocity = projectile.velocity * 0.98f + (Main.player[num5].Center - base.projectile.Center) / num6 * 3.5f;
                base.projectile.tileCollide = false;
            }
            else
            {
                if (num7 < 27f)
                {
                    base.projectile.velocity *= 1.2f;
                }
                if (num7 > 27.5f)
                {
                    base.projectile.velocity *= 0.96f;
                }
            }
            if(num6 < 20 && num7 < 10)
            {
                Main.player[num5].QuickSpawnItem(base.mod.ItemType("StormUnderTheSea"), 1);
                base.projectile.timeLeft = 0;
            }
		}

		public override void Kill(int timeLeft)
		{
		}
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/渊海风暴Glow"), base.projectile.Center - Main.screenPosition, null, Color.Yellow * ((float)projectile.timeLeft / 480f), base.projectile.rotation, new Vector2(27f, 30f), 1f, SpriteEffects.None, 0f);
        }
    }
}
