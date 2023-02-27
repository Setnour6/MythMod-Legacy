using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 海葵粒子 : ModProjectile
	{
		private bool num1 = true;
		private bool num4 = true;
		private float num = 0;
		private float num2 = 0;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("海葵粒子");

            Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 34;
            base.projectile.scale = 1;
            base.projectile.height = 34;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 90;
			this.cooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 100;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}
        private float num100 = 0;
		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
            if(projectile.timeLeft == 85)
            {
                num100 = Main.rand.Next(-100,101) / 1000f;
            }
            if (projectile.timeLeft == 70)
            {
                num100 = Main.rand.Next(-100, 101) / 1000f;
            }
            if (projectile.timeLeft == 55)
            {
                num100 = Main.rand.Next(-100, 101) / 1000f;
            }
            if (projectile.timeLeft < 90)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft < 90 && projectile.timeLeft > 50)
            {
                projectile.velocity.Y += 0.1f;
            }
            if (projectile.timeLeft < 75 && projectile.timeLeft > 30)
            {
                projectile.velocity = projectile.velocity.RotatedBy(num100);
            }
            if (projectile.timeLeft < 80)
			{
				base.projectile.scale = (float)projectile.timeLeft / 90;
				base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
			}
            else
			{
			    base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
			}
		}
        public override void Kill(int timeLeft)
		{
		}
		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 34;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = projectile.oldPos[k / 6] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/海葵粒子光效"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/渊海磷光光效").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
