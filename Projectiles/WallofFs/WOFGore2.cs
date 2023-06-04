using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.WallofFs
{
    public class WOFGore2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("被诅咒的肉碎片");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 62;
			base.Projectile.height = 62;
            Projectile.hostile = true;
            Projectile.friendly = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 3600000;
        }
        public float scal = 0f;
        public float scalMax = 1f;
        public float scalx = 1f;
        public Vector2 v = new Vector2(0,0);
        public override void AI()
		{
            Projectile.velocity *= 0;
            if (Projectile.timeLeft >= 3600000)
            {
                v = Projectile.position;
                Projectile.rotation = Main.rand.NextFloat(0, (float)(Math.PI * 2));
            }
            Vector2 vk = new Vector2(0,Main.rand.NextFloat(0,6f)).RotatedByRandom(Math.PI * 2);
            Projectile.position = v + vk;
            if(NPC.CountNPCS(113) <= 0)
            {
                Projectile.Kill();
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 120; i++)
            {
                Vector2 vz = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 5, 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = vz;
            }
        }
    }
}
