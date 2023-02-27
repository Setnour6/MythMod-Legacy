using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class GreenFireGas : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("绿火焰");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 210;
			base.projectile.height = 210;
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
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            projectile.velocity *= 0.98f;
            if (base.projectile.timeLeft <= 60)
            {
                boom = true;
            }
            if (boom)
            {
                base.projectile.scale += (float)(0.7f * (projectile.ai[0] + 1) - base.projectile.scale) / 24f;
                projectile.velocity *= 0.97f;
            }
            projectile.velocity -= new Vector2(0, Main.rand.NextFloat(0.5f)).RotatedByRandom(Math.PI * 2);
            projectile.velocity.Y -= 0.03f;
            base.projectile.width = (int)(210 * projectile.scale);
            base.projectile.height = (int)(210 * projectile.scale);
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.75f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 1.8f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.45f / 255f * projectile.scale * projectile.timeLeft / 120f);
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
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
            base.projectile.tileCollide = false;
            projectile.velocity *= 0;
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
