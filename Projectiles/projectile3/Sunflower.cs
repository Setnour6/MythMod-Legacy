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
    public class Sunflower : ModProjectile
	{
        public override void SetDefaults()
		{
			Projectile.width = 46;
			Projectile.height = 46;
			Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
			Projectile.timeLeft = 3000;
		}
        int times = 0;
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(Projectile.timeLeft > 2950)
            {
                Projectile.soundDelay = 10;
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
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Glows/Sunflower_Glow"), base.Projectile.Center - Main.screenPosition, null, new Color(0.7f,0.7f,0.7f, 0), base.Projectile.rotation, new Vector2(23f, 23f), 1f, SpriteEffects.None, 0f);
        }
        public override void AI()
		{
            float num7 = (float)Math.Sqrt(Projectile.velocity.X * Projectile.velocity.X + base.Projectile.velocity.Y * base.Projectile.velocity.Y);
            int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
            Projectile.rotation += 0.05f * num7;
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
            if (Projectile.timeLeft <= 2950)
            {
                if (num7 < 9f)
                {
                    base.Projectile.velocity *= 1.2f;
                }
                if (num7 > 10f)
                {
                    base.Projectile.velocity *= 0.86f;
                }
                int num3 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                Projectile.velocity = Projectile.velocity * 0.98f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 3.5f;
                base.Projectile.tileCollide = false;
            }
            else
            {
                if (num7 < 9f)
                {
                    base.Projectile.velocity *= 1.2f;
                }
                if (num7 > 10f)
                {
                    base.Projectile.velocity *= 0.96f;
                }
                Projectile.velocity = Projectile.velocity * 0.995f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 0.15f;
            }
            if (num6 < 60 && Projectile.timeLeft < 2950)
            {
                base.Projectile.timeLeft = 0;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 v1 = target.Center;
            if(times < 2)
            {
                for (int t = 0; t < 4; t++)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0, 4f)).RotatedByRandom(Math.PI * 2d);
                    int y = Projectile.NewProjectile(v1.X, v1.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("SunFlowerpetal").Type, Projectile.damage / 2, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].scale = Main.rand.NextFloat(0.9f, 1.1f);
                    Main.projectile[y].damage = (int)(Projectile.damage * Main.projectile[y].scale);
                    Main.projectile[y].frame = Main.rand.Next(0, 8);
                }
                times++;
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
