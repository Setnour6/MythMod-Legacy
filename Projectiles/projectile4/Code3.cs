using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class Code3 : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
            base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 400f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 300f, 14f);
            if(X > 0)
            {
                X -= 1;
                int num = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 2, 2, 226, 0, 0, 0, default(Color), X * 0.02f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, 645, (int)((double)base.Projectile.damage * 3f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Main.projectile[num].timeLeft = 1;
            X = 60;
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/Code3Glow"), base.Projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.Projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
    }
}
