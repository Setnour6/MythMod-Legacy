using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class EOCPhatom : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("克苏鲁之眼之影");
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 120;
			base.Projectile.height = 120;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 200;
			base.Projectile.timeLeft = 450;
			this.CooldownSlot = 1;
		}
        public bool Chase = true;
        public bool WeakeningFlag = false;
		public override void AI()
		{
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if (Projectile.timeLeft >= 50)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.863f / 255f, (float)(255 - base.Projectile.alpha) * 0.07843f / 255f, (float)(255 - base.Projectile.alpha) * 0.2353f / 255f);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.863f / 255f * Projectile.timeLeft / 50f, (float)(255 - base.Projectile.alpha) * 0.07843f / 255f * Projectile.timeLeft / 50f, (float)(255 - base.Projectile.alpha) * 0.2353f / 255f * Projectile.timeLeft / 50f);
            }
            if(WeakeningFlag)
            {
                Projectile.velocity *= 0.95f;
            }
            for(int u = 0; u < 200;u++)
            {
                if ((Main.npc[u].Center - Projectile.Center).Length() < 200 && Chase && Main.npc[u].active)
                {
                    Projectile.velocity = (Main.npc[u].Center - Projectile.Center) / (Main.npc[u].Center - Projectile.Center).Length() * Projectile.velocity.Length();
                    Chase = false;
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            Projectile.timeLeft = 50;
            WeakeningFlag = true;
            return false;
        }
        public override Color? GetAlpha(Color lightColor)
		{
            if(Projectile.timeLeft >= 50)
            {
                return new Color?(new Color(220 / 255f, 20 / 255f, 60 / 255f, 0));
            }
            else
            {
                return new Color?(new Color(220 * Projectile.timeLeft / 50f / 255f, 20 * Projectile.timeLeft / 50f / 255f, 60 * Projectile.timeLeft / 50f / 255f, 0));
            }
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
