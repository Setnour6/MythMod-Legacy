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
			Projectile.width = 54;
			Projectile.height = 60;
			Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
			Projectile.timeLeft = 3000;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// Die immediately if ai[1] isn't 0 (We set this to 1 for the 5 extra explosives we spawn in Kill)
			if(Projectile.timeLeft > 2850)
            {
                if (Projectile.ai[1] != 0)
                {
                    return true;
                }
                Projectile.soundDelay = 10;

                // This code makes the projectile very bouncy.
                if (Projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
                {
                    Projectile.velocity.X = oldVelocity.X * -0.9f;
                }
                if (Projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
                {
                    Projectile.velocity.Y = oldVelocity.Y * -0.9f;
                }
            }
			return false;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Projectile.damage += 50;
            target.AddBuff(24, 600);
        }
        public override void AI()
		{
            float num7 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + base.Projectile.velocity.Y * base.Projectile.velocity.Y);
            int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
            Projectile.rotation += 0.05f * num7;
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
            if (Projectile.timeLeft <= 2850)
            {
                if (num7 < 5f)
                {
                    base.Projectile.velocity *= 1.2f;
                }
                if (num7 > 6f)
                {
                    base.Projectile.velocity *= 0.96f;
                }
                int num3 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                Projectile.velocity = Projectile.velocity * 0.98f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 3.5f;
                base.Projectile.tileCollide = false;
            }
            else
            {
                if (num7 < 27f)
                {
                    base.Projectile.velocity *= 1.2f;
                }
                if (num7 > 27.5f)
                {
                    base.Projectile.velocity *= 0.96f;
                }
            }
            if(num6 < 20 && num7 < 10)
            {
                Main.player[num5].QuickSpawnItem(base.Mod.Find<ModItem>("StormUnderTheSea").Type, 1);
                base.Projectile.timeLeft = 0;
            }
		}

		public override void Kill(int timeLeft)
		{
		}
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/渊海风暴Glow"), base.Projectile.Center - Main.screenPosition, null, Color.Yellow * ((float)Projectile.timeLeft / 480f), base.Projectile.rotation, new Vector2(27f, 30f), 1f, SpriteEffects.None, 0f);
        }
    }
}
