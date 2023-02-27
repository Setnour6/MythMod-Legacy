using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
    public class GreenTangerineFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("年桔烈火");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
            base.projectile.hostile = true;
            base.projectile.friendly = false;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            projectile.timeLeft = 60;
			this.cooldownSlot = 1;
            base.projectile.scale = 0.4f;

        }
        private bool boom = false;
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            projectile.velocity *= 0f;
            if (base.projectile.timeLeft <= 60)
            {
                boom = true;
            }
            if (boom)
            {
                base.projectile.scale += (float)(0.7f * (projectile.ai[0] + 1) - base.projectile.scale) / 24f;
                projectile.velocity *= 0f;
            }
            base.projectile.width = (int)(28 * projectile.scale);
            base.projectile.height = (int)(28 * projectile.scale);
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.75f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 1.8f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.45f / 255f * projectile.scale * projectile.timeLeft / 120f);
            if(projectile.timeLeft == 30)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("GreenTangerineFlame2"), 140, 0f, Main.myPlayer, 0f, 0f);
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.projectile.timeLeft > 60)
            {
                return new Color?(new Color(155, 155, 155, 0));
            }
            else
            {
                if (base.projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.projectile.timeLeft - 25) / 30f * (155 / 255f), 1 * (155 / 255f), (base.projectile.timeLeft - 25) / 30f * (155 / 255f), 0));
                }
                else
                {
                    return new Color?(new Color(base.projectile.timeLeft / 180f * (155 / 255f), base.projectile.timeLeft / 30f * (155 / 255f), base.projectile.timeLeft / 180f * (155 / 255f), 0));
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.Kill();
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
