using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
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
			Main.projFrames[base.Projectile.type] = 19;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 150;
			base.Projectile.timeLeft = 1200;
			base.Projectile.alpha = 180;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.Projectile.frameCounter++;
			if (base.Projectile.frameCounter > 3)
			{
				base.Projectile.frame++;
				base.Projectile.frameCounter = 0;
			}
			if (base.Projectile.frame > 18)
			{
				base.Projectile.frame = 0;
			}
			base.Projectile.alpha--;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * -1f / 255f, (float)(255 - base.Projectile.alpha) * -1f / 255f, (float)(255 - base.Projectile.alpha) * -1.0f / 255f);
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.ai[1] = 1f;
				SoundEngine.PlaySound(SoundID.Item20, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			Projectile projectile = base.Projectile;
			projectile.velocity.X = projectile.velocity.X * 1.04f;
			Projectile projectile2 = base.Projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.04f;
			if (base.Projectile.velocity.X < 0f)
			{
				base.Projectile.spriteDirection = -1;
				base.Projectile.rotation = (float)Math.Atan2(-(double)base.Projectile.velocity.Y, -(double)base.Projectile.velocity.X);
				return;
			}
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(0, 0, 0, base.Projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
		}
	}
}
