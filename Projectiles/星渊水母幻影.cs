using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
	public class 星渊水母幻影 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星渊水母幻影");
            Main.projFrames[projectile.type] = 5; /*【帧数为6】对应的贴图也要画6帧哦*/
		}
		private bool initialization = true;
        private float X;
		private Vector2 A ;
		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 100;
			base.projectile.height = 100;
			base.projectile.alpha = 255;
			base.projectile.friendly = false;
			base.projectile.hostile = true;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 300;
			base.projectile.ignoreWater = false;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			if(base.projectile.velocity.Y > -0.8f)
			{
				base.projectile.velocity = new Vector2(0, -8 * base.projectile.scale);
			}
			base.projectile.velocity *= 0.96f;
			if(base.projectile.timeLeft <= 300 && base.projectile.timeLeft >= 249)
			{
				base.projectile.alpha -= 5;
			}
			if(base.projectile.timeLeft <= 51)
			{
				base.projectile.alpha += 5;
			}
			if(base.projectile.timeLeft % 10 == 0)
			{
				base.projectile.frame += 1;
				if(base.projectile.frame > 4)
				{
					base.projectile.frame = 0;
				}
			}
			if (projectile.timeLeft < 120 && projectile.timeLeft > 280)
            {
                projectile.hostile = false;
            }
			else
			{
				projectile.hostile = true;
			}
			Lighting.AddLight(base.projectile.Center, 0.2f * (255 - base.projectile.alpha) / 255, 0, 0f);
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
		public override void Kill(int timeLeft)
		{
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			player.AddBuff(70, 120, true);
            player.AddBuff(base.mod.BuffType("极剧毒"), 30, true);
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Vector2 origin = new Vector2(50f, 50f);
			if(projectile.timeLeft <= 120)
			{
				spriteBatch.Draw(base.mod.GetTexture("Projectiles/星渊水母幻影光辉"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), Color.White * (base.projectile.timeLeft) * 0.0083333333333f, base.projectile.rotation, origin, base.projectile.scale, SpriteEffects.None, 0f);
			}
			else
			{
				spriteBatch.Draw(base.mod.GetTexture("Projectiles/星渊水母幻影光辉"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), Color.White * (base.projectile.timeLeft), base.projectile.rotation, origin, base.projectile.scale, SpriteEffects.None, 0f);
			}
		}
	}
}
