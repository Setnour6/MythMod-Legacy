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
			base.Projectile.width = 210;
			base.Projectile.height = 210;
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
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            Projectile.velocity *= 0.98f;
            if (base.Projectile.timeLeft <= 60)
            {
                boom = true;
            }
            if (boom)
            {
                base.Projectile.scale += (float)(0.7f * (Projectile.ai[0] + 1) - base.Projectile.scale) / 24f;
                Projectile.velocity *= 0.97f;
            }
            Projectile.velocity -= new Vector2(0, Main.rand.NextFloat(0.5f)).RotatedByRandom(Math.PI * 2);
            Projectile.velocity.Y -= 0.03f;
            base.Projectile.width = (int)(210 * Projectile.scale);
            base.Projectile.height = (int)(210 * Projectile.scale);
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.75f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 1.8f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.45f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
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
            base.Projectile.tileCollide = false;
            Projectile.velocity *= 0;
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
