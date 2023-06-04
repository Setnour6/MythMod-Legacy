using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class GorgonianWaterBomb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("柳珊瑚水雷");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 34;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 600;
            base.Projectile.DamageType = DamageClass.Throwing;
            base.Projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if(!Projectile.wet)
            {
                Projectile.velocity.Y += 0.2f;
            }
            else
            {
                Projectile.velocity *= 0.98f;
            }
            Projectile.velocity *= 0.98f;
            Projectile.rotation += Projectile.velocity.X * 0.02f;
            if(Projectile.timeLeft < 130)
            {
                Projectile.alpha += 5;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                if(Projectile.velocity.Length() > 0.5f)
                {
                    if (base.Projectile.velocity.X != oldVelocity.X)
                    {
                        base.Projectile.velocity.X = -oldVelocity.X * 0.6f;
                    }
                    if (base.Projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.Projectile.velocity.Y = -oldVelocity.Y * 0.6f;
                    }
                }
                else
                {
                    base.Projectile.velocity.Y *= 0;
                    base.Projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft != 0)
            {
                SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
                for (int k = 0; k <= 30; k++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 40)).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(Projectile.Center.X + v.X, Projectile.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("MeltingpotBlaze").Type, 200, 0, Main.myPlayer, Main.rand.Next(2500, 3200) / 4000f, 0f);
                }
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
	}
}
