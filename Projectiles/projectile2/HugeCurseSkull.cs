using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class HugeCurseSkull : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巨咒骷髅");
			Main.projFrames[base.projectile.type] = 2;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 52;
			base.projectile.height = 62;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.timeLeft % 30 < 15)
            {
                projectile.frame = 0;
            }
            else
            {
                projectile.frame = 1;
            }
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 6f, 0, 0, 174, 0f, 0f, 100, default(Color), 2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.0f;
            int num10 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 3f, 0, 0, 188, 0f, 0f, 100, default(Color), 3f);
            Main.dust[num10].velocity *= 0.0f;
        }
        public override void Kill(int timeLeft)
        {
            for (int j = 0; j < 8; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 270, (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            float num60 = (float)Main.rand.Next(0, 10000);
            float num80 = Main.rand.Next(-1000, 1000) / 1000f;
            double num90 = (double)Math.Sqrt(1 - (int)num80 * (int)num80);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num80, (float)num90)) * 7;
            for (int i = 0; i < 40; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 125f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 6, (float)num80, (float)num90, 150, default(Color), 1.8f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 2.5f;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].noGravity = true;
            }
        }
    }
}
