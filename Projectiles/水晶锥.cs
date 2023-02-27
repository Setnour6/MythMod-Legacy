using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
    public class 水晶锥 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("水晶锥");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 3600;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
		}
		public override void AI()
		{
			float num = base.projectile.Center.X;
			float num2 = base.projectile.Center.Y;
			bool flag = false;

			if (flag)
			{
				float num7 = 35f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num8 = num - vector.X;
				float num9 = num2 - vector.Y;
				float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num8) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num9) / 21f;
				return;
			}
		}

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 200), base.projectile.rotation, Utils.Size(texture2D) / 2f, 1, SpriteEffects.None, 0f);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            if (timeLeft != 0)
            {
                for (int a = 0; a < 12; a++)
                {
                    Vector2 vector = base.projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(2f, 4f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 1f);
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.15f) * 0.1f;
                }
            }
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块1"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块2"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块3"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.Next(-10, 10), Main.rand.Next(-10, 10), base.mod.ProjectileType("水晶碎块4"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
        }
	}
}
