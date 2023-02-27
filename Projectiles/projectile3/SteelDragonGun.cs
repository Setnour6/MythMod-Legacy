using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class SteelDragonGun : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("钢铁巨龙炮");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 150;
            base.projectile.hostile = false;
            projectile.tileCollide = true;
        }
        private float omega = 0;
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 144)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 4.8f - new Vector2(-4, 4), 0, 0, 6, 0, 0, 0, default(Color), 4f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 4f - new Vector2(-4, 4), 0, 0, 188, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
                if (projectile.timeLeft % 3 == 0)
                {
                    Projectile.NewProjectile((projectile.Center - projectile.velocity * 3).X, (projectile.Center - projectile.velocity * 3).Y, projectile.velocity.X * 0.05f, projectile.velocity.Y * 0.05f, mod.ProjectileType("迷你喷流"), projectile.damage / 8, projectile.knockBack, Main.myPlayer, 0f, 1f);
                }
                float num2 = base.projectile.Center.X;
                float num3 = base.projectile.Center.Y;
                float num4 = 400f;
                bool flag = false;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                    {
                        float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                        float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                        float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                        if (num7 < num4)
                        {
                            num4 = num7;
                            num2 = num5;
                            num3 = num6;
                            flag = true;
                        }
                    }
                }
                if (flag)
                {
                    float num8 = 20f;
                    Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                    float num9 = num2 - vector1.X;
                    float num10 = num3 - vector1.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / num11;
                    num9 *= num11;
                    num10 *= num11;
                    base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
                    base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
                }
                else
                {
                    if (Math.Abs(omega) < 0.1f)
                    {
                        omega += Main.rand.NextFloat(-0.005f, 0.005f);
                    }
                    else
                    {
                        omega *= 0.99f;
                    }
                    projectile.velocity = projectile.velocity.RotatedBy(omega);
                }
                if(projectile.velocity.Length() >= 13)
                {
                    projectile.velocity *= 0.98f;
                }
                if (projectile.velocity.Length() <= 12)
                {
                    projectile.velocity *= 1.02f;
                }
            }
            projectile.spriteDirection = (int)((projectile.velocity.X) / Math.Abs(projectile.velocity.X));
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
            /*for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }*/
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("FireFlame"), base.projectile.damage / 3, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("FireBallWave"), 0, 0, base.projectile.owner, 0f, 0f);
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
