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
			Projectile.width = 38;
			Projectile.height = 36;
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
                int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Tangerine2").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
                Main.projectile[t].timeLeft = 180;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(Projectile.timeLeft > 2850)
            {
                if (Projectile.ai[1] != 0)
                {
                    return true;
                }
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
                    base.Projectile.velocity *= 0.86f;
                }
                int num3 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                Projectile.velocity = Projectile.velocity * 0.98f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 3.5f;
                base.Projectile.tileCollide = false;
            }
            if(Projectile.timeLeft % 30 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(8f, 14f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Tangerine2").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
            }
            if (Projectile.timeLeft % 30 == 15)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 3.5f)).RotatedByRandom(Math.PI * 2f);
                int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("TangerineLeaf").Type, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[t].hostile = false;
                Main.projectile[t].friendly = true;
            }
            else
            {
                if (num7 < 16f)
                {
                    base.Projectile.velocity *= 1.2f;
                }
                if (num7 > 17f)
                {
                    base.Projectile.velocity *= 0.96f;
                }
            }
            if (num6 < 60 && Projectile.timeLeft < 2950)
            {
                base.Projectile.timeLeft = 0;
            }
        }
    }
}
