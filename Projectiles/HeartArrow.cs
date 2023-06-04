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
            // base.DisplayName.SetDefault("爱心箭");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 26;
			base.Projectile.height = 30;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 65;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.aiStyle = 1;
            this.AIType = 1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if (Projectile.timeLeft == 71) { Projectile.tileCollide = true; }
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            Projectile.light = 0.1f;
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            if (Main.rand.Next(3) == 1)
            {
                if (target.type != 113 && target.type != 396 && target.type != 397 && target.type != 398 && target.type != Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                {
                    target.AddBuff(Mod.Find<ModBuff>("Stunned").Type, 20, false);
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
                    int num25 = Dust.NewDust(Projectile.Center, 0, 0, 12, v.X, v.Y, 150, default(Color), 1.2f);
                    Main.dust[num25].noGravity = false;
                }
            }
        }
    }
}
