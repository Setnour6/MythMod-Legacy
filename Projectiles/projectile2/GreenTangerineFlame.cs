using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			base.Projectile.width = 28;
			base.Projectile.height = 28;
            base.Projectile.hostile = true;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
            Projectile.timeLeft = 60;
			this.CooldownSlot = 1;
            base.Projectile.scale = 0.4f;

        }
        private bool boom = false;
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            Projectile.velocity *= 0f;
            if (base.Projectile.timeLeft <= 60)
            {
                boom = true;
            }
            if (boom)
            {
                base.Projectile.scale += (float)(0.7f * (Projectile.ai[0] + 1) - base.Projectile.scale) / 24f;
                Projectile.velocity *= 0f;
            }
            base.Projectile.width = (int)(28 * Projectile.scale);
            base.Projectile.height = (int)(28 * Projectile.scale);
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.75f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 1.8f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.45f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            if(Projectile.timeLeft == 30)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("GreenTangerineFlame2").Type, 140, 0f, Main.myPlayer, 0f, 0f);
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.Projectile.timeLeft > 60)
            {
                return new Color?(new Color(155, 155, 155, 0));
            }
            else
            {
                if (base.Projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.Projectile.timeLeft - 25) / 30f * (155 / 255f), 1 * (155 / 255f), (base.Projectile.timeLeft - 25) / 30f * (155 / 255f), 0));
                }
                else
                {
                    return new Color?(new Color(base.Projectile.timeLeft / 180f * (155 / 255f), base.Projectile.timeLeft / 30f * (155 / 255f), base.Projectile.timeLeft / 180f * (155 / 255f), 0));
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.Kill();
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
