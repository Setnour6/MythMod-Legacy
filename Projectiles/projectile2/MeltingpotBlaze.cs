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
    public class MeltingpotBlaze : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔炉烈焰");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 210;
			base.Projectile.height = 210;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
            base.Projectile.tileCollide = true;
            base.Projectile.timeLeft = 90;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
            base.Projectile.scale = 0.1f;

        }
        private bool boom = false;
		public override void AI()
		{
            Projectile.velocity *= 0.98f;
            if (base.Projectile.timeLeft <= 90)
            {
                boom = true;
            }
            if (boom)
            {
                base.Projectile.scale += (float)(Projectile.ai[0] - base.Projectile.scale) / 24f;
                Projectile.velocity *= 0.97f;
            }
            Projectile.velocity -= new Vector2(0,Main.rand.NextFloat(0.8f)).RotatedByRandom(Math.PI * 2) + new Vector2(Projectile.ai[0], Projectile.ai[0]) / 10f;
            Projectile.velocity.Y -= 0.2f;
            base.Projectile.width = (int)(210 * Projectile.scale);
            base.Projectile.height = (int)(210 * Projectile.scale);
            if(Projectile.wet)
            {
                Projectile.velocity.Y -= 0.4f;
                Projectile.timeLeft -= 4;
                int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 188, 0, -0.5f, 201, default(Color), 4f);
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 3.75f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.24f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
        }
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                if (base.Projectile.timeLeft > 30)
                {
                    return new Color?(new Color(1, (base.Projectile.timeLeft - 25) / 30f, (base.Projectile.timeLeft - 25) / 30f, 0));
                }
                else
                {
                    if (base.Projectile.timeLeft > 20)
                    {
                        return new Color?(new Color(base.Projectile.timeLeft / 30f, base.Projectile.timeLeft / 180f, base.Projectile.timeLeft / 180f, 0));
                    }
                    else
                    {
                        if (base.Projectile.timeLeft > 10)
                        {
                            return new Color?(new Color(base.Projectile.timeLeft * base.Projectile.timeLeft / 600f, base.Projectile.timeLeft / 180f, base.Projectile.timeLeft / 180f, (20 - base.Projectile.timeLeft) / 60f));
                        }
                        else
                        {
                            return new Color?(new Color(base.Projectile.timeLeft * base.Projectile.timeLeft / 600f, base.Projectile.timeLeft / 180f, base.Projectile.timeLeft / 180f, base.Projectile.timeLeft / 60f));
                        }
                    }
                }
            }
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            Projectile.velocity *= 0;
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 720, true);
        }
    }
}
