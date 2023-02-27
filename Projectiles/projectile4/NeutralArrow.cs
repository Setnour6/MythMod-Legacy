using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
			base.projectile.width = 12;
			base.projectile.height = 12;
            projectile.hostile = false;
            projectile.friendly = true;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = true;
            base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 900;
            projectile.extraUpdates = 12;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 70;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
		public override void AI()
		{
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
            //projectile.timeLeft -= 1;
            if (base.projectile.ai[0] == 0f)
            {
                base.projectile.ai[0] = 1f;
            }
            float num = projectile.timeLeft;
            if (base.projectile.localAI[0] > num)
            {
                projectile.ai[1] = 1;
            }
            float num2 = 1.5f;
            if (base.projectile.ai[1] == 0f)
            {
                base.projectile.localAI[0] += num2;
                if (base.projectile.localAI[0] > num)
                {
                    projectile.ai[1] = 1;
                    base.projectile.localAI[0] = num;
                }
            }
            else
            {
                base.projectile.localAI[0] -= num2;
                if (base.projectile.localAI[0] <= 0f)
                {
                    base.projectile.Kill();
                }
            }
            if(projectile.timeLeft <= 0)
            {
                base.projectile.Kill();
            }
            projectile.velocity.Y += 0.004f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.2f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
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
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("NeutralArrow2"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(1150, 1152) / 3750f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(31, 300, false);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D t = Main.projectileTexture[projectile.type];
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                Color color = (new Color(1f,1f,1f,0) * 0.2f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos,null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
