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
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.alpha = 255;
			base.projectile.scale = 1f;
			base.projectile.friendly = true;
            base.projectile.hostile = false;
            base.projectile.magic = true;
            projectile.extraUpdates = 2;

            base.projectile.penetrate = 1;
			base.projectile.timeLeft = 3600;
            base.projectile.ignoreWater = false;
            base.projectile.tileCollide = true;
        }
		public override void AI()
		{
            if(projectile.timeLeft < 3580)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, 2f);
                if (projectile.wet)
                {
                    projectile.timeLeft = 0;
                }
            }

		}
		public override void Kill(int timeLeft)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            for (int i = 0; i < 65; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 2f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, 4f);
                Main.dust[num5].velocity = v;
            }
        }
	}
}
