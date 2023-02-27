using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			base.Projectile.width = 22;
			base.Projectile.height = 22;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 600;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
		}
        public bool T = false;
        public override void AI()
		{
            if(T)
            {
                Projectile.velocity *= 0.95f;
            }
			Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.45f  * (float)Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 0.1f  * (float)Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
		}
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        public bool addspeed = false;
		public override Color? GetAlpha(Color lightColor)
		{
            float num = 1;
            if (Projectile.timeLeft > 580)
            {
                num = 0;
            }
            if (Projectile.timeLeft <= 580 && Projectile.timeLeft > 500)
            {
                num = (580 - Projectile.timeLeft) / 160f;
            }
            if (Projectile.timeLeft <= 500 && Projectile.timeLeft > 60)
            {
                num = 0.5f;
            }
            if (Projectile.timeLeft <= 60)
            {
                num = Projectile.timeLeft / 120f;
            }
            if(Projectile.velocity.Length() <= 0.2f && !addspeed)
            {
                addspeed = true;
            }
            if(addspeed)
            {
                Projectile.velocity *= 13f;
                Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.Next(-5000, 5000) / 15000f);
                addspeed = false;
            }
            Projectile.velocity *= 0.95f;
            return new Color?(new Color(num, num, num, 0));
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.tileCollide = false;
            T = true;
            base.Projectile.timeLeft = 60;
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            T = true;
            base.Projectile.timeLeft = 60;
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 22;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = Projectile.oldPos[k / 2] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/断魂裂骨Glow"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/projectile2/断魂裂骨Glow").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
