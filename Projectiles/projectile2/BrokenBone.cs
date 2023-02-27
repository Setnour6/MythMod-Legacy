using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile2
{
    public class BrokenBone : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("断魂裂骨");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 22;
			base.projectile.height = 22;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 600;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}
        public bool T = false;
        public override void AI()
		{
            if(T)
            {
                projectile.velocity *= 0.95f;
            }
			projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.45f  * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0.1f  * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
		}
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public bool addspeed = false;
		public override Color? GetAlpha(Color lightColor)
		{
            float num = 1;
            if (projectile.timeLeft > 580)
            {
                num = 0;
            }
            if (projectile.timeLeft <= 580 && projectile.timeLeft > 500)
            {
                num = (580 - projectile.timeLeft) / 160f;
            }
            if (projectile.timeLeft <= 500 && projectile.timeLeft > 60)
            {
                num = 0.5f;
            }
            if (projectile.timeLeft <= 60)
            {
                num = projectile.timeLeft / 120f;
            }
            if(projectile.velocity.Length() <= 0.2f && !addspeed)
            {
                addspeed = true;
            }
            if(addspeed)
            {
                projectile.velocity *= 13f;
                projectile.velocity = projectile.velocity.RotatedBy(Main.rand.Next(-5000, 5000) / 15000f);
                addspeed = false;
            }
            projectile.velocity *= 0.95f;
            return new Color?(new Color(num, num, num, 0));
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.tileCollide = false;
            T = true;
            base.projectile.timeLeft = 60;
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            T = true;
            base.projectile.timeLeft = 60;
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
			int frameHeight = 22;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = projectile.oldPos[k / 2] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/断魂裂骨Glow"), drawPos, new Rectangle(0, frameHeight * projectile.frame, base.mod.GetTexture("Projectiles/projectile2/断魂裂骨Glow").Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
