using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 血琉璃长矛火花 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("血琉璃长矛火花");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 24;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x0018AB58 File Offset: 0x00188D58
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		public override void Kill(int timeLeft)
        {
			float num12 = Main.rand.Next(-10000,10000)/10000f;
            for (int i = 0; i < 4; i++)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)(Math.Sin(((float)i / 2f) * 3.14159265359f + (float)num12) * 3.0) * 0.5f, (float)(Math.Cos(((float)i / 2f) * 3.14159265359f + (float)num12) * 3.0) * 0.5f, base.mod.ProjectileType("血琉璃长矛火花2"), (int)((double)base.projectile.damage * 0.08f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
	}
}
