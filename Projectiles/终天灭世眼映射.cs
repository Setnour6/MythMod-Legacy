using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 终天灭世眼映射 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("终天灭世眼映射");
			Main.projFrames[base.projectile.type] = 3;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 150;
			base.projectile.height = 150;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 240;
			base.projectile.alpha = 180;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frame > 2)
			{
				base.projectile.frame = 0;
			}
			base.projectile.velocity *= 1.07f;
		}
	}
}
