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
    public class TangerineKnife : ModProjectile
	{
        public override void SetDefaults()
		{
			projectile.width = 38;
			projectile.height = 36;
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
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Tangerine2"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.timeLeft > 2850)
            {
                if (projectile.ai[1] != 0)
                {
                    return true;
                }
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
                    base.projectile.velocity *= 0.86f;
                }
                int num3 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                projectile.velocity = projectile.velocity * 0.98f + (Main.player[num5].Center - base.projectile.Center) / num6 * 3.5f;
                base.projectile.tileCollide = false;
            }
            if(projectile.timeLeft % 30 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Tangerine2"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
            }
            if (projectile.timeLeft % 30 == 15)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3.5f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("TangerineLeaf"), (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
            }
            else
            {
                if (num7 < 16f)
                {
                    base.projectile.velocity *= 1.2f;
                }
                if (num7 > 17f)
                {
                    base.projectile.velocity *= 0.96f;
                }
            }
            if (num6 < 60 && projectile.timeLeft < 2950)
            {
                base.projectile.timeLeft = 0;
            }
        }
    }
}
