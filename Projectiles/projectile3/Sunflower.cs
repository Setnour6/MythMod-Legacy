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
			projectile.width = 46;
			projectile.height = 46;
			projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
			projectile.timeLeft = 3000;
		}
        int times = 0;
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.timeLeft > 2950)
            {
                projectile.soundDelay = 10;
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
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Glows/Sunflower_Glow"), base.projectile.Center - Main.screenPosition, null, new Color(0.7f,0.7f,0.7f, 0), base.projectile.rotation, new Vector2(23f, 23f), 1f, SpriteEffects.None, 0f);
        }
        public override void AI()
		{
            float num7 = (float)Math.Sqrt(projectile.velocity.X * projectile.velocity.X + base.projectile.velocity.Y * base.projectile.velocity.Y);
            int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            projectile.rotation += 0.05f * num7;
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
            if (projectile.timeLeft <= 2950)
            {
                if (num7 < 9f)
                {
                    base.projectile.velocity *= 1.2f;
                }
                if (num7 > 10f)
                {
                    base.projectile.velocity *= 0.86f;
                }
                int num3 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                projectile.velocity = projectile.velocity * 0.98f + (Main.player[num5].Center - base.projectile.Center) / num6 * 3.5f;
                base.projectile.tileCollide = false;
            }
            else
            {
                if (num7 < 9f)
                {
                    base.projectile.velocity *= 1.2f;
                }
                if (num7 > 10f)
                {
                    base.projectile.velocity *= 0.96f;
                }
                projectile.velocity = projectile.velocity * 0.995f + (Main.player[num5].Center - base.projectile.Center) / num6 * 0.15f;
            }
            if (num6 < 60 && projectile.timeLeft < 2950)
            {
                base.projectile.timeLeft = 0;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Vector2 v1 = target.Center;
            if(times < 2)
            {
                for (int t = 0; t < 4; t++)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0, 4f)).RotatedByRandom(Math.PI * 2d);
                    int y = Projectile.NewProjectile(v1.X, v1.Y, v2.X, v2.Y, mod.ProjectileType("SunFlowerpetal"), projectile.damage / 2, 0.5f, Main.myPlayer, 10f, 25f);
                    Main.projectile[y].scale = Main.rand.NextFloat(0.9f, 1.1f);
                    Main.projectile[y].damage = (int)(projectile.damage * Main.projectile[y].scale);
                    Main.projectile[y].frame = Main.rand.Next(0, 8);
                }
                times++;
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
