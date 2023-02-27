using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
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
			base.Projectile.width = 210;
			base.Projectile.height = 210;
			base.Projectile.hostile = true;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
            base.Projectile.tileCollide = true;
            base.Projectile.timeLeft = 300;
			this.CooldownSlot = 1;
            base.Projectile.scale = 0.1f;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 30;
        }
        private bool boom = false;
        private bool co = false;
        private bool l = true;
        public override void AI()
        {
            if (l)
            {
                Projectile.localAI[0] = 0;
                l = false;
            }
            Projectile.localAI[0] += 1;
            Projectile.velocity *= 0.98f;
            if (base.Projectile.timeLeft <= 300)
            {
                boom = true;
            }
            if (boom)
            {
                base.Projectile.scale += (float)(0.2f - base.Projectile.scale) / 24f;
                Projectile.velocity *= 0.97f;
            }
            if (!co)
            {
                Projectile.velocity -= new Vector2(0, Main.rand.NextFloat(0.8f)).RotatedByRandom(Math.PI * 2);
                Projectile.velocity.Y += 0.2f;
            }
            else
            {
                Projectile.timeLeft -= 10;
            }
            if (Projectile.localAI[0] % 3 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3)).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(Projectile.position.X + v.X, Projectile.position.Y + v.Y, Projectile.velocity.X * 0.8f, Projectile.velocity.Y * 0.8f, Mod.Find<ModProjectile>("GreenFireGas").Type, 100, 0f, Main.myPlayer, 0f, 0f);
            }
            base.Projectile.width = (int)(210 * Projectile.scale);
            base.Projectile.height = (int)(210 * Projectile.scale);
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.75f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 1.8f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.45f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (base.Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                if (base.Projectile.timeLeft > 30)
                {
                    return new Color?(new Color((base.Projectile.timeLeft - 25) / 30f, 1, (base.Projectile.timeLeft - 25) / 30f, 0));
                }
                else
                {
                    return new Color?(new Color(base.Projectile.timeLeft / 180f, base.Projectile.timeLeft / 30f, base.Projectile.timeLeft / 180f, 0));
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            Projectile.velocity *= 0;
            co = true;
            return false;
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
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
