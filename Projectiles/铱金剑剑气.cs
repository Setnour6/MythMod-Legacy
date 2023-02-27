using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 铱金剑剑气 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铱金剑剑气");
			Main.projFrames[base.projectile.type] = 19;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 150;
			base.projectile.timeLeft = 1200;
			base.projectile.alpha = 180;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 3)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame > 18)
			{
				base.projectile.frame = 0;
			}
			base.projectile.alpha--;
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * -1f / 255f, (float)(255 - base.projectile.alpha) * -1f / 255f, (float)(255 - base.projectile.alpha) * -1.0f / 255f);
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
			}
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X * 1.04f;
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.04f;
			if (base.projectile.velocity.X < 0f)
			{
				base.projectile.spriteDirection = -1;
				base.projectile.rotation = (float)Math.Atan2(-(double)base.projectile.velocity.Y, -(double)base.projectile.velocity.X);
				return;
			}
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(0, 0, 0, base.projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
		}
	}
}
