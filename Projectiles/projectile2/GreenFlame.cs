using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
    public class GreenFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("绿火焰");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 210;
			base.projectile.height = 210;
			base.projectile.hostile = true;
            base.projectile.friendly = false;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            base.projectile.tileCollide = true;
            base.projectile.timeLeft = 300;
			this.cooldownSlot = 1;
            base.projectile.scale = 0.1f;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 30;
        }
        private bool boom = false;
        private bool co = false;
        private bool l = true;
        public override void AI()
        {
            if (l)
            {
                projectile.localAI[0] = 0;
                l = false;
            }
            projectile.localAI[0] += 1;
            projectile.velocity *= 0.98f;
            if (base.projectile.timeLeft <= 300)
            {
                boom = true;
            }
            if (boom)
            {
                base.projectile.scale += (float)(0.2f - base.projectile.scale) / 24f;
                projectile.velocity *= 0.97f;
            }
            if (!co)
            {
                projectile.velocity -= new Vector2(0, Main.rand.NextFloat(0.8f)).RotatedByRandom(Math.PI * 2);
                projectile.velocity.Y += 0.2f;
            }
            else
            {
                projectile.timeLeft -= 10;
            }
            if (projectile.localAI[0] % 3 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3)).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(projectile.position.X + v.X, projectile.position.Y + v.Y, projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.8f, mod.ProjectileType("GreenFireGas"), 100, 0f, Main.myPlayer, 0f, 0f);
            }
            base.projectile.width = (int)(210 * projectile.scale);
            base.projectile.height = (int)(210 * projectile.scale);
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.75f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 1.8f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.45f / 255f * projectile.scale * projectile.timeLeft / 120f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                if (base.projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.projectile.timeLeft - 25) / 30f, 1, (base.projectile.timeLeft - 25) / 30f, 0));
                }
                else
                {
                    return new Color?(new Color(base.projectile.timeLeft / 180f, base.projectile.timeLeft / 30f, base.projectile.timeLeft / 180f, 0));
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            projectile.velocity *= 0;
            co = true;
            return false;
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
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
