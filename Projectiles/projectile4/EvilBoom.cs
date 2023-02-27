using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class EvilBoom : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("影炸弹");
		}
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 0;
			projectile.penetrate = 11;
			projectile.timeLeft = 3595;
            projectile.extraUpdates = 2;
            projectile.tileCollide = true;
        }
        private float Y = 0;
        private float X = 0;
        private float ω = 0;
        private bool Orbit = false;
        public override void AI()
		{
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 3595)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 86, 50f, 50f, 0, default(Color), (float)projectile.scale * 1.2f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 150;
            }
            if (projectile.velocity.Y < 2.5f)
            {
                projectile.velocity.Y += 0.04f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int i = 0; i < 120; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("DarkF2"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
        }
    }
}
