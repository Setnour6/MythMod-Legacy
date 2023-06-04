using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class IcyThorn : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("冰棱刺");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 14;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 200;
			base.Projectile.alpha = 0;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.ai[1] = 1f;
				SoundEngine.PlaySound(SoundID.Item27.WithVolumeScale(0.2f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			Projectile projectile = base.Projectile;
			projectile.velocity.X = projectile.velocity.X * 1.07f;
			Projectile projectile2 = base.Projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.07f;
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
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item20, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
		}
	}
}
