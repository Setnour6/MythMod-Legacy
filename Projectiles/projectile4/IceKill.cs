﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class IceKill : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
            Main.projFrames[Projectile.type] = 11;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 410;
			base.Projectile.height = 398;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 44;
		}
        public float num2 = 0;
        public override void AI()
        {
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 3)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 10)
            {
                base.Projectile.frame = 0;
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.timeLeft / 60f, (float)(255 - base.Projectile.alpha) * 0.15f / 255f * Projectile.timeLeft / 60f, (float)(255 - base.Projectile.alpha) * 0.72f / 255f * Projectile.timeLeft / 60f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY + Projectile.height / 2f), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
