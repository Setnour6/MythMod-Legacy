using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class PoisonGasF : ModProjectile
	{
		public override void SetDefaults()
		{
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.alpha = 255;
			base.Projectile.scale = 1f;
			base.Projectile.friendly = false;
            base.Projectile.hostile = false;

            base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 10;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = true;
        }
        private bool c = false;
		public override void AI()
		{
            if(!c)
            {
            }
            else
            {
                Projectile.velocity *= 0;
                base.Projectile.hostile = false;
                base.Projectile.friendly = true;
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X - 16, base.Projectile.position.Y + 8), base.Projectile.width * 3, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, 0f, -10f, 100, default(Color), 4f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
                int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X - 16, base.Projectile.position.Y + 8), base.Projectile.width * 3, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, 0f, -10f, 100, default(Color), 4f);
                Main.dust[num2].velocity *= 1.1f;
                Main.dust[num2].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;

                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
                if(Main.rand.Next(240) == 2)
                {
                    Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y - 8f, 0, 0, Mod.Find<ModProjectile>("PoisonGasBubbleF").Type, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            if(Projectile.wet)
            {
                Projectile.timeLeft = 0;
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!c)
            {
                Projectile.velocity *= 0;
                base.Projectile.timeLeft = 1200;
                c = true;
            }
            return false;
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(20, Projectile.timeLeft * 2, true);
            target.AddBuff(70, Projectile.timeLeft / 2, true);
        }
        // Token: 0x06003201 RID: 12801 RVA: 0x001B11D8 File Offset: 0x001AF3D8
        public override void Kill(int timeLeft)
		{
        }
	}
}
