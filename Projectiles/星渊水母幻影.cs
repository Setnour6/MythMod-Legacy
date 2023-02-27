using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
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
            Main.projFrames[Projectile.type] = 5; /*【帧数为6】对应的贴图也要画6帧哦*/
		}
		private bool initialization = true;
        private float X;
		private Vector2 A ;
		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.Projectile.width = 100;
			base.Projectile.height = 100;
			base.Projectile.alpha = 255;
			base.Projectile.friendly = false;
			base.Projectile.hostile = true;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 300;
			base.Projectile.ignoreWater = false;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			if(base.Projectile.velocity.Y > -0.8f)
			{
				base.Projectile.velocity = new Vector2(0, -8 * base.Projectile.scale);
			}
			base.Projectile.velocity *= 0.96f;
			if(base.Projectile.timeLeft <= 300 && base.Projectile.timeLeft >= 249)
			{
				base.Projectile.alpha -= 5;
			}
			if(base.Projectile.timeLeft <= 51)
			{
				base.Projectile.alpha += 5;
			}
			if(base.Projectile.timeLeft % 10 == 0)
			{
				base.Projectile.frame += 1;
				if(base.Projectile.frame > 4)
				{
					base.Projectile.frame = 0;
				}
			}
			if (Projectile.timeLeft < 120 && Projectile.timeLeft > 280)
            {
                Projectile.hostile = false;
            }
			else
			{
				Projectile.hostile = true;
			}
			Lighting.AddLight(base.Projectile.Center, 0.2f * (255 - base.Projectile.alpha) / 255, 0, 0f);
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
		public override void Kill(int timeLeft)
		{
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			player.AddBuff(70, 120, true);
            player.AddBuff(base.Mod.Find<ModBuff>("极剧毒").Type, 30, true);
		}
		public override void PostDraw(Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Vector2 origin = new Vector2(50f, 50f);
			if(Projectile.timeLeft <= 120)
			{
				spriteBatch.Draw(base.Mod.GetTexture("Projectiles/星渊水母幻影光辉"), base.Projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), Color.White * (base.Projectile.timeLeft) * 0.0083333333333f, base.Projectile.rotation, origin, base.Projectile.scale, SpriteEffects.None, 0f);
			}
			else
			{
				spriteBatch.Draw(base.Mod.GetTexture("Projectiles/星渊水母幻影光辉"), base.Projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), Color.White * (base.Projectile.timeLeft), base.Projectile.rotation, origin, base.Projectile.scale, SpriteEffects.None, 0f);
			}
		}
	}
}
