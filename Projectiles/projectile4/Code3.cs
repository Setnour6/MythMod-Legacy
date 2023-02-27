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
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 300f, 14f);
            if(X > 0)
            {
                X -= 1;
                int num = Dust.NewDust(projectile.Center - new Vector2(4, 4), 2, 2, 226, 0, 0, 0, default(Color), X * 0.02f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, 645, (int)((double)base.projectile.damage * 3f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Main.projectile[num].timeLeft = 1;
            X = 60;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile4/Code3Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
    }
}
