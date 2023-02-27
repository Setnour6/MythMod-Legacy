using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class DiamondSwordChi : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("钻石币剑气");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 44;
			base.projectile.height = 18;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.timeLeft < 450 && projectile.velocity.Y < 15f)
            {
                projectile.velocity.Y += 0.2f;
            }
            if ((int)(Main.time / 5f) % 15 == 10)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 80) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("DiamondCoin"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int j = 0; j < 9; j++)
            {
                Vector2 v = new Vector2(0, 11).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("DiamondCoin"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
