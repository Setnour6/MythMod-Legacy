using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
	public class 克苏鲁之脑镜像 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之脑镜像");
            Main.projFrames[Projectile.type] = 8; /*【帧数为6】对应的贴图也要画6帧哦*/
		}
		private bool initialization = true;
        private float X;
		private Vector2 A ;
		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.Projectile.width = 200;
			base.Projectile.height = 182;
			base.Projectile.friendly = false;
			base.Projectile.hostile = false;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 300000000;
			base.Projectile.DamageType = DamageClass.Magic;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			if(NPC.CountNPCS(266) < 1)
			{
				base.Projectile.timeLeft = 0;
			}
		}
        // Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
        public override void Kill(int timeLeft)
		{
		}
       // public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
      //  {
           // Texture2D texture2D = Main.projectileTexture[base.projectile.type];
           // Player p = Main.player[Main.myPlayer];
            //int num = Main.projectileTexture[base.projectile.type].Height;
            //Main.spriteBatch.Draw(texture2D, (base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + (projectile.Center - p.Center)).RotatedBy((projectile.Center - p.Center).Length() / 2000f), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
           // Main.spriteBatch.Draw(texture2D, (base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + (projectile.Center - p.Center) * 1.5f).RotatedBy((projectile.Center - p.Center).Length() / 2000f * 1.5f), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            //Main.spriteBatch.Draw(texture2D, (base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + (projectile.Center - p.Center) * 2f).RotatedBy((projectile.Center - p.Center).Length() / 2000f * 2f), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            //Main.spriteBatch.Draw(texture2D, (base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY) + (projectile.Center - p.Center) * 2.5f).RotatedBy((projectile.Center - p.Center).Length() / 2000f * 2.5f), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
        //}
    }
}
