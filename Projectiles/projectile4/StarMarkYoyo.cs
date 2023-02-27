using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class StarMarkYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 300f, 14f);
            if(Main.rand.Next(15) == 1)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Star"), 0f, 0f, 100, default(Color), 0.8f);
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile4/StarMarkYoyoGlow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
    }
}
