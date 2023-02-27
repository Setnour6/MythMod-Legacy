using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class MeteorFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔岩陨石");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 3600;
            projectile.extraUpdates = 2;
            base.projectile.hostile = false;
		}
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 0.4f - new Vector2(4, 4), 0, 0, mod.DustType("Flame2"), 0, 0, 0, default(Color), 4f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(4, 4), 0, 0, mod.DustType("Flame"), 0, 0, 0, default(Color), 3f);
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
            target.AddBuff(24, 600);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 0.36f, 0f);
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, 4f);
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 150; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 6f)).RotatedBy(Math.PI * 300 / (double)i);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 54, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - projectile.position).Length() < 150 && !Main.npc[i].friendly && !Main.npc[i].dontTakeDamage)
                {
                    Main.npc[i].StrikeNPC((int)(projectile.damage / 6f * Main.rand.NextFloat(0.85f,1.15f)), 0, 1);
                }
            }
        }
        public int projTime = 15;
	}
}
