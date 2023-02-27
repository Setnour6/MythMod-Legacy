using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 散裂之星 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("散裂之星");
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 66;
			base.Projectile.height = 66;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 750;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / 400);
			if (Projectile.timeLeft < 150)
            {
                Projectile.scale *= 0.99f;
            }
			if (Projectile.timeLeft < 90)
            {
                Projectile.hostile = false;
            }
			if (Projectile.timeLeft % 12 == 1 && !Projectile.hostile == false)
            {
				float num1 = (float)Math.Sin((float)Projectile.timeLeft / 100 * Math.PI) * 9;
				float num2 = (float)Math.Cos((float)Projectile.timeLeft / 100 * Math.PI) * 9;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, num1, num2, Mod.Find<ModProjectile>("散裂之星2").Type, 700, 2f, Main.myPlayer, 0f, 0f);
				Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -num1, -num2, Mod.Find<ModProjectile>("散裂之星2").Type, 700, 2f, Main.myPlayer, 0f, 0f);
            }
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1.2f / 255f, (float)(255 - base.Projectile.alpha) * 1.2f / 255f, (float)(255 - base.Projectile.alpha) * 1.2f / 255f);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x0000C861 File Offset: 0x0000AA61
		// Token: 0x06001EC8 RID: 7880 RVA: 0x0018AB58 File Offset: 0x00188D58
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
