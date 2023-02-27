using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 藤蔓球 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("藤蔓球");
			Main.projFrames[base.projectile.type] = 1;
		}
		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.hostile = true;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 1500;
			base.projectile.alpha = 255;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
			int p = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 2f);
			Main.dust[p].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].noGravity = true;
			int q = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 2f);
			Main.dust[q].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].noGravity = true;
			int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 2f);
			Main.dust[r].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].noGravity = true;
		}
	}
}
