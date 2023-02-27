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
    public class 星空毁灭焰 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星空毁灭焰");
			Main.projFrames[base.Projectile.type] = 3;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 48;
			base.Projectile.height = 30;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 240;
			base.Projectile.alpha = 0;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.Projectile.frameCounter++;
			if (base.Projectile.frame > 3)
			{
				base.Projectile.frame = 0;
			}
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.482f / 255f, (float)(255 - base.Projectile.alpha) * 0.408f / 255f, (float)(255 - base.Projectile.alpha) * 1.0f / 255f);
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.ai[1] = 1f;
				SoundEngine.PlaySound(SoundID.Item20, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 2f);
                Main.dust[num25].velocity *= 0.5f;
                Main.dust[num25].noGravity = true;
            if (Projectile.timeLeft % 16 == 8)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((0 - base.Projectile.velocity.Y) * 0.3f), (float)((base.Projectile.velocity.X) * 0.3f), base.Mod.Find<ModProjectile>("星空毁灭焰2").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((base.Projectile.velocity.Y) * 0.3f), (float)((0 - base.Projectile.velocity.X) * 0.3f), base.Mod.Find<ModProjectile>("星空毁灭焰2").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
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
			SoundEngine.PlaySound(SoundID.Item20, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			for (int i = 0; i <= 25; i++)
			{
                int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num25].velocity *= 0.5f;
                Main.dust[num25].noGravity = true;
			}
		}
	}
}
