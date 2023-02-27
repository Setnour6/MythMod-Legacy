using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 连线星星 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("连线星星");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			base.Projectile.extraUpdates = 2;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			Projectile.velocity *= 0.985f;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
			if (Projectile.timeLeft > 100)
            {
		       	int ID = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		    	Main.dust[ID].noGravity = true;
		    	Main.dust[ID].velocity *= 0;
			}
			else
			{
				int ID = Dust.NewDust(Projectile.Center - new Vector2(4, 4), 0, 0, 159, 0, 0, 0, default(Color), 1.4f * Projectile.timeLeft / 100);/*粉尘效果不用管*/
		    	Main.dust[ID].noGravity = true;
		    	Main.dust[ID].velocity *= 0;
			}
			if (Projectile.timeLeft < 100)
            {
                Projectile.scale *= 0.95f;
            }
			if (Projectile.timeLeft < 60)
            {
                Projectile.hostile = false;
            }
			if (Projectile.timeLeft > 99 && Projectile.timeLeft % 100 == 0)
			{
                Projectile.velocity = new Vector2(Main.rand.Next(-140, 140) / 28f, Main.rand.Next(-140, 140) / 28f);
			}
			if (Projectile.timeLeft % 100 == 1)
			{
				int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,0, 0, base.Mod.Find<ModProjectile>("爆炸星星").Type, 555, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				Main.projectile[num].timeLeft = 0;
			}
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
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
