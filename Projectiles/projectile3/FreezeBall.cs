using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FreezeBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰封球");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
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
            if(projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), 4f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 1.5f - new Vector2(4, 4), 0, 0, 88, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
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
            target.AddBuff(44, 300);
            target.AddBuff(47, 300);
            target.AddBuff(46, 300);
            if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
            {
                target.AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                target.AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
            }
            if(target.type == 113)
            {
                for(int i = 0;i < 200;i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        Main.npc[i].AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                        Main.npc[i].AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                    }
                }
            }
            if (target.type == 114)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                    {
                        Main.npc[i].AddBuff(mod.BuffType("Freeze"), (int)projectile.ai[1]);
                        Main.npc[i].AddBuff(mod.BuffType("Freeze2"), (int)projectile.ai[1] + 2);
                    }
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 88, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int k = 0; k <= 20; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.06f, (float)((float)l * Math.Sin((float)a)) * 0.06f, base.mod.ProjectileType("FreezeBallBrake"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, projectile.ai[1] / 2f);
                Main.projectile[num4].timeLeft = (int)(projectile.damage * Main.rand.NextFloat(0.2f, 0.7f));
            }
        }
        public int projTime = 15;
	}
}
