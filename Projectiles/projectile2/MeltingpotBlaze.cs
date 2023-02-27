using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
    public class MeltingpotBlaze : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔炉烈焰");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 210;
			base.projectile.height = 210;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = false;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            base.projectile.tileCollide = true;
            base.projectile.timeLeft = 90;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
            base.projectile.scale = 0.1f;

        }
        private bool boom = false;
		public override void AI()
		{
            projectile.velocity *= 0.98f;
            if (base.projectile.timeLeft <= 90)
            {
                boom = true;
            }
            if (boom)
            {
                base.projectile.scale += (float)(projectile.ai[0] - base.projectile.scale) / 24f;
                projectile.velocity *= 0.97f;
            }
            projectile.velocity -= new Vector2(0,Main.rand.NextFloat(0.8f)).RotatedByRandom(Math.PI * 2) + new Vector2(projectile.ai[0], projectile.ai[0]) / 10f;
            projectile.velocity.Y -= 0.2f;
            base.projectile.width = (int)(210 * projectile.scale);
            base.projectile.height = (int)(210 * projectile.scale);
            if(projectile.wet)
            {
                projectile.velocity.Y -= 0.4f;
                projectile.timeLeft -= 4;
                int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, 188, 0, -0.5f, 201, default(Color), 4f);
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 3.75f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.24f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * projectile.timeLeft / 120f);
        }
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                if (base.projectile.timeLeft > 30)
                {
                    return new Color?(new Color(1, (base.projectile.timeLeft - 25) / 30f, (base.projectile.timeLeft - 25) / 30f, 0));
                }
                else
                {
                    if (base.projectile.timeLeft > 20)
                    {
                        return new Color?(new Color(base.projectile.timeLeft / 30f, base.projectile.timeLeft / 180f, base.projectile.timeLeft / 180f, 0));
                    }
                    else
                    {
                        if (base.projectile.timeLeft > 10)
                        {
                            return new Color?(new Color(base.projectile.timeLeft * base.projectile.timeLeft / 600f, base.projectile.timeLeft / 180f, base.projectile.timeLeft / 180f, (20 - base.projectile.timeLeft) / 60f));
                        }
                        else
                        {
                            return new Color?(new Color(base.projectile.timeLeft * base.projectile.timeLeft / 600f, base.projectile.timeLeft / 180f, base.projectile.timeLeft / 180f, base.projectile.timeLeft / 60f));
                        }
                    }
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            projectile.velocity *= 0;
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 720, true);
        }
    }
}
