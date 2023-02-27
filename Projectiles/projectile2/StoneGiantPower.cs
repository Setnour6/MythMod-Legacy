using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			base.Projectile.width = 8;
			base.Projectile.height = 8;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 1200;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public bool flag = true;
		// Token: 0x06002158 RID: 8536 RVA: 0x001791F4 File Offset: 0x001773F4
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
            Projectile.velocity *= 0.99f;
            for (int t = 0; t < 200; t++)
            {
                if (Main.npc[t].type == 245 && Main.npc[t].active)
                {
                    Projectile.velocity += (Main.npc[t].Center - Projectile.Center) / (Main.npc[t].Center - Projectile.Center).Length() * 0.25f;
                    if ((Main.npc[t].Center - Projectile.Center).Length() < 50)
                    {
                        Projectile.timeLeft = 60;
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
            if(Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(Projectile.timeLeft / 60f, Projectile.timeLeft / 60f, Projectile.timeLeft / 60f, 0));
            }
		}
        // Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D t = TextureAssets.Projectile[Projectile.type].Value;
            int frameHeight = t.Height / Main.projFrames[Projectile.type];
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            if(Projectile.timeLeft >= 50)
            {
                for (int k = 0; k < Projectile.oldPos.Length; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                    Color color = (Color.Wheat * 0.2f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * Projectile.frame, t.Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                }
            }
            if (Projectile.timeLeft < 50)
            {
                for (int k = 0; k < Projectile.timeLeft; k++)
                {
                    Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, Projectile.gfxOffY);
                    Color color = (Color.Wheat * 0.2f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                    spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * Projectile.frame, t.Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}
