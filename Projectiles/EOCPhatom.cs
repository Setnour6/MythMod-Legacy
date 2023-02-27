using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class EOCPhatom : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之眼之影");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 120;
			base.projectile.height = 120;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 200;
			base.projectile.timeLeft = 450;
			this.cooldownSlot = 1;
		}
        public bool Chase = true;
        public bool WeakeningFlag = false;
		public override void AI()
		{
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if (projectile.timeLeft >= 50)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.863f / 255f, (float)(255 - base.projectile.alpha) * 0.07843f / 255f, (float)(255 - base.projectile.alpha) * 0.2353f / 255f);
            }
            else
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.863f / 255f * projectile.timeLeft / 50f, (float)(255 - base.projectile.alpha) * 0.07843f / 255f * projectile.timeLeft / 50f, (float)(255 - base.projectile.alpha) * 0.2353f / 255f * projectile.timeLeft / 50f);
            }
            if(WeakeningFlag)
            {
                projectile.velocity *= 0.95f;
            }
            for(int u = 0; u < 200;u++)
            {
                if ((Main.npc[u].Center - projectile.Center).Length() < 200 && Chase && Main.npc[u].active)
                {
                    projectile.velocity = (Main.npc[u].Center - projectile.Center) / (Main.npc[u].Center - projectile.Center).Length() * projectile.velocity.Length();
                    Chase = false;
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            projectile.timeLeft = 50;
            WeakeningFlag = true;
            return false;
        }
        public override Color? GetAlpha(Color lightColor)
		{
            if(projectile.timeLeft >= 50)
            {
                return new Color?(new Color(220 / 255f, 20 / 255f, 60 / 255f, 0));
            }
            else
            {
                return new Color?(new Color(220 * projectile.timeLeft / 50f / 255f, 20 * projectile.timeLeft / 50f / 255f, 60 * projectile.timeLeft / 50f / 255f, 0));
            }
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
