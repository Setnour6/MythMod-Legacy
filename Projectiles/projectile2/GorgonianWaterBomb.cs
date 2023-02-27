using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class GorgonianWaterBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("柳珊瑚水雷");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 34;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 600;
            base.projectile.thrown = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if(!projectile.wet)
            {
                projectile.velocity.Y += 0.2f;
            }
            else
            {
                projectile.velocity *= 0.98f;
            }
            projectile.velocity *= 0.98f;
            projectile.rotation += projectile.velocity.X * 0.02f;
            if(projectile.timeLeft < 130)
            {
                projectile.alpha += 5;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                if(projectile.velocity.Length() > 0.5f)
                {
                    if (base.projectile.velocity.X != oldVelocity.X)
                    {
                        base.projectile.velocity.X = -oldVelocity.X * 0.6f;
                    }
                    if (base.projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.projectile.velocity.Y = -oldVelocity.Y * 0.6f;
                    }
                }
                else
                {
                    base.projectile.velocity.Y *= 0;
                    base.projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft != 0)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
                for (int k = 0; k <= 30; k++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 40)).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(projectile.Center.X + v.X, projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("MeltingpotBlaze"), 200, 0, Main.myPlayer, Main.rand.Next(2500, 3200) / 4000f, 0f);
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
