using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class FireBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("火球");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, 0));
            }
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3592)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4), 0, 0, mod.DustType("Flame2"), 0, 0, 0, default(Color), 4f);
                Main.dust[r].noGravity = true;
            }
            if((player.Center - projectile.Center).Length() < 600 && projectile.Center.Y > player.Center.Y - 100)
            {
                projectile.tileCollide = true;
            }
            else
            {
                projectile.tileCollide = false;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int k = 0; k <= 10; k++)
            {
                if(projectile.damage > 300)
                {
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("FireBallWave"), 0, 0, base.projectile.owner, 0f, 0f);
                }
            }
            for (int i = 0; i < 170; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
        }
        public int projTime = 15;
	}
}
