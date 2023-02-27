using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class HeartArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("爱心箭");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.ranged = true;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if (projectile.timeLeft == 71) { projectile.tileCollide = true; }
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            projectile.light = 0.1f;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if (Main.rand.Next(3) == 1)
            {
                if (target.type != 113 && target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
                {
                    target.AddBuff(mod.BuffType("Stunned"), 20, false);
                }
            }
		}
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                for (int a = 0; a < 90; a++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(25, 50) / 50f).RotatedByRandom(Math.PI * 2);
                    int num25 = Dust.NewDust(projectile.Center, 0, 0, 12, v.X, v.Y, 150, default(Color), 1.2f);
                    Main.dust[num25].noGravity = false;
                }
            }
        }
    }
}
