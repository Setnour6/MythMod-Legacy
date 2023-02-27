using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
			Main.projFrames[base.projectile.type] = 3;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 48;
			base.projectile.height = 30;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 240;
			base.projectile.alpha = 0;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frame > 3)
			{
				base.projectile.frame = 0;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.482f / 255f, (float)(255 - base.projectile.alpha) * 0.408f / 255f, (float)(255 - base.projectile.alpha) * 1.0f / 255f);
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
			}
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
                int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 2f);
                Main.dust[num25].velocity *= 0.5f;
                Main.dust[num25].noGravity = true;
            if (projectile.timeLeft % 16 == 8)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((0 - base.projectile.velocity.Y) * 0.3f), (float)((base.projectile.velocity.X) * 0.3f), base.mod.ProjectileType("星空毁灭焰2"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((base.projectile.velocity.Y) * 0.3f), (float)((0 - base.projectile.velocity.X) * 0.3f), base.mod.ProjectileType("星空毁灭焰2"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
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
			for (int i = 0; i <= 25; i++)
			{
                int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num25].velocity *= 0.5f;
                Main.dust[num25].noGravity = true;
			}
		}
	}
}
