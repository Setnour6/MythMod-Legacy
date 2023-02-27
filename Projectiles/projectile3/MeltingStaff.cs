using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class MeltingStaff : ModProjectile
	{
		public override void SetDefaults()
		{
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.alpha = 255;
			base.Projectile.scale = 1f;
			base.Projectile.friendly = true;
            base.Projectile.hostile = false;
            base.Projectile.DamageType = DamageClass.Magic;
            Projectile.extraUpdates = 2;

            base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 3600;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = true;
        }
		public override void AI()
		{
            if(Projectile.timeLeft < 3580)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, 2f);
                if (Projectile.wet)
                {
                    Projectile.timeLeft = 0;
                }
            }

		}
		public override void Kill(int timeLeft)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int i = 0; i < 65; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Flame").Type, 0f, 0f, 100, Color.White, 4f);
                Main.dust[num5].velocity = v;
            }
        }
	}
}
