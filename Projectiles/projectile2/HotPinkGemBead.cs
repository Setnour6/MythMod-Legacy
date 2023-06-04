using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class HotPinkGemBead : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("石榴石弹球");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = 1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 3600;
            base.Projectile.hostile = false;
		}
		public override void AI()
		{
            int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, Mod.Find<ModDust>("Garnet").Type, 0, 0, 0, default(Color), 1f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
			return false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            int num = Projectile.NewProjectile(base.Projectile.Center.X + base.Projectile.velocity.X * 2f, base.Projectile.Center.Y + base.Projectile.velocity.Y * 2f, base.Projectile.velocity.X, base.Projectile.velocity.Y, 51, 10, 0, Main.myPlayer, 0f, 0f);
            Main.projectile[num].penetrate = 4;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item27.WithVolumeScale(0.4f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Garnet").Type, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        public int projTime = 15;
	}
}
