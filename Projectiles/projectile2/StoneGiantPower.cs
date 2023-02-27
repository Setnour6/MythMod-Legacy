using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x020005F4 RID: 1524
    public class StoneGiantPower : ModProjectile
	{
		// Token: 0x06002156 RID: 8534 RVA: 0x0000D493 File Offset: 0x0000B693
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("石巨人能源");
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x001AC3AC File Offset: 0x001AA5AC
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public bool flag = true;
		// Token: 0x06002158 RID: 8536 RVA: 0x001791F4 File Offset: 0x001773F4
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.5f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
            projectile.velocity *= 0.99f;
            for (int t = 0; t < 200; t++)
            {
                if (Main.npc[t].type == 245 && Main.npc[t].active)
                {
                    projectile.velocity += (Main.npc[t].Center - projectile.Center) / (Main.npc[t].Center - projectile.Center).Length() * 0.25f;
                    if ((Main.npc[t].Center - projectile.Center).Length() < 50)
                    {
                        projectile.timeLeft = 60;
                        if(flag)
                        {
                            flag = false;
                            if(Main.npc[t].life < Main.npc[t].lifeMax)
                            {
                                Main.npc[t].life += 1000;
                            }
                            else
                            {
                                Main.npc[t].life = Main.npc[t].lifeMax;
                            }
                        }
                    }
                }
            }
		}
        // Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
        public override Color? GetAlpha(Color lightColor)
		{
            if(projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(projectile.timeLeft / 60f, projectile.timeLeft / 60f, projectile.timeLeft / 60f, 0));
            }
		}
        // Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D t = Main.projectileTexture[projectile.type];
            int frameHeight = t.Height / Main.projFrames[projectile.type];
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            if(projectile.timeLeft >= 50)
            {
                for (int k = 0; k < projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                    Color color = (Color.Wheat * 0.2f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame, t.Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            if (projectile.timeLeft < 50)
            {
                for (int k = 0; k < projectile.timeLeft; k++)
                {
                    Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                    Color color = (Color.Wheat * 0.2f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                    spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame, t.Width, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}
