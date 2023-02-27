using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class IcyThorn : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰棱刺");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 14;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 200;
			base.projectile.alpha = 0;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 0.2f, 0f);
			}
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X * 1.07f;
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.07f;
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
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
		}
	}
}
