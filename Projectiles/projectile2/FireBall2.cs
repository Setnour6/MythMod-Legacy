using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class FireBall2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("火球");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 3600;
            base.Projectile.hostile = false;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, 0));
            }
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3592)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4), 0, 0, Mod.Find<ModDust>("Flame2").Type, 0, 0, 0, default(Color), 4f);
                Main.dust[r].noGravity = true;
                if(Main.rand.Next(100) > 60)
                {
                    int r0 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) + new Vector2(0, Main.rand.NextFloat(0,36f)).RotatedByRandom(MathHelper.TwoPi), 0, 0, Mod.Find<ModDust>("Flame3").Type, 0, 0, 0, default(Color), 7f);
                    Main.dust[r0].noGravity = true;
                }
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(24, 1200);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
            for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("火山溅射").Type, base.Projectile.damage / 5, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
            for (int k = 0; k <= 2; k++)
            {
                if(Projectile.damage > 300)
                {
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("FireBallWave").Type, 0, 0, base.Projectile.owner, 0f, 0f);
                }
            }
            for (int i = 0; i < 170; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(Projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(Projectile.damage)));
                Main.dust[num5].velocity = v;
            }
        }
        public int projTime = 15;
	}
}
