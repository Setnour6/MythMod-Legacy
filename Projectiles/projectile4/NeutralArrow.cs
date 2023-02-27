using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class NeutralArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("神经箭");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 12;
			base.Projectile.height = 12;
            Projectile.hostile = false;
            Projectile.friendly = true;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = true;
            base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 900;
            Projectile.extraUpdates = 12;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 70;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
		public override void AI()
		{
            Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X));
            //projectile.timeLeft -= 1;
            if (base.Projectile.ai[0] == 0f)
            {
                base.Projectile.ai[0] = 1f;
            }
            float num = Projectile.timeLeft;
            if (base.Projectile.localAI[0] > num)
            {
                Projectile.ai[1] = 1;
            }
            float num2 = 1.5f;
            if (base.Projectile.ai[1] == 0f)
            {
                base.Projectile.localAI[0] += num2;
                if (base.Projectile.localAI[0] > num)
                {
                    Projectile.ai[1] = 1;
                    base.Projectile.localAI[0] = num;
                }
            }
            else
            {
                base.Projectile.localAI[0] -= num2;
                if (base.Projectile.localAI[0] <= 0f)
                {
                    base.Projectile.Kill();
                }
            }
            if(Projectile.timeLeft <= 0)
            {
                base.Projectile.Kill();
            }
            Projectile.velocity.Y += 0.004f;
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.2f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void Kill(int timeLeft)
        {
            float p = Main.rand.NextFloat(0, 2f) * (float)Math.PI;
            for (int i = 0; i <= 14; i++)
            {
                Vector2 v = new Vector2(0, 6f).RotatedBy((float)i / 7.5f * Math.PI + p);
                int num5 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("NeutralArrow2").Type, (int)((double)base.Projectile.damage * 0.1f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(1150, 1152) / 3750f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(31, 300, false);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D t = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                Color color = (new Color(1f,1f,1f,0) * 0.2f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos,null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
