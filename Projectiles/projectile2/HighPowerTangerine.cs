using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile2
{
    public class HighPowerTangerine : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("高能年桔");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 12;
            base.Projectile.tileCollide = true;
            base.Projectile.height = 12;
			base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = -1;
			base.Projectile.scale = 1f;
		}
		public override void AI()
		{
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override void Kill(int timeLeft)
        {
            float num60 = (float)Main.rand.Next(0, 10000);
            int num80 = Main.rand.Next(-1000, 1000) / 100;
            double num90 = (double)Math.Sqrt(100 - (int)num80 * (int)num80);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num80, (float)num90)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num80, (float)num90);
            float num100 = (float)Main.rand.Next(0, 10000) / 1000;
            float T = (float)(Main.rand.Next(0, 10000) / 5000 * Math.PI);
            for (int i = 0; i < 26; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 13f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 174, 0, 0, 0, Color.Red, 1.8f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 2f;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].noGravity = true;
            }
        }
	}
}
