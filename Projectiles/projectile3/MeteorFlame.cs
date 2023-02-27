using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
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
			base.Projectile.width = 32;
			base.Projectile.height = 32;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 3600;
            Projectile.extraUpdates = 2;
            base.Projectile.hostile = false;
		}
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 0.4f - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Flame2").Type, 0, 0, 0, default(Color), 4f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Flame").Type, 0, 0, 0, default(Color), 3f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            if((player.Center - Projectile.Center).Length() < 600 && Projectile.Center.Y > player.Center.Y - 100)
            {
                Projectile.tileCollide = true;
            }
            else
            {
                Projectile.tileCollide = false;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 600);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.36f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, 4f);
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 150; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 6f)).RotatedBy(Math.PI * 300 / (double)i);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 54, 0f, 0f, 100, Color.White, 1.5f);
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - Projectile.position).Length() < 150 && !Main.npc[i].friendly && !Main.npc[i].dontTakeDamage)
                {
                    Main.npc[i].StrikeNPC((int)(Projectile.damage / 6f * Main.rand.NextFloat(0.85f,1.15f)), 0, 1);
                }
            }
        }
        public int projTime = 15;
	}
}
