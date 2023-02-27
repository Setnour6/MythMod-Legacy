﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class AuSwordChi : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("金币剑气");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 44;
			base.Projectile.height = 18;
			base.Projectile.hostile = false;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.timeLeft < 450 && Projectile.velocity.Y < 15f)
            {
                Projectile.velocity.Y += 0.2f;
            }
            if ((int)(Main.time / 5f) % 15 == 0)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 80) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("AuCoin").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int j = 0; j < 8; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("AuCoin").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
