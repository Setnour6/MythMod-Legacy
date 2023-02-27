using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200054D RID: 1357
    public class LiRougeJelly : ModProjectile
	{
		// Token: 0x06001DBA RID: 7610 RVA: 0x0000C2EA File Offset: 0x0000A4EA
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("小胭脂果冻");
		}

		// Token: 0x06001DBB RID: 7611 RVA: 0x0017EE28 File Offset: 0x0017D028
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.alpha = 80;
			base.projectile.timeLeft = 3000;
			base.projectile.penetrate = 2;
			base.projectile.magic = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            if(base.projectile.timeLeft >= 2990)
            {
                base.projectile.timeLeft = Main.rand.Next(270, 335);
            }
            Lighting.AddLight(base.projectile.Center, 0.5f, 0f, 0f);
            Projectile projectile = base.projectile;
            projectile.velocity.X = projectile.velocity.X * 0.99f;
            Projectile projectile2 = base.projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.99f;
            Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 0.7f);
        }

		// Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 183, base.projectile.oldVelocity.X * 1.2f, base.projectile.oldVelocity.Y * 1.2f, 0, default(Color), 1.3f);
			}
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 105, 0.3f, 0f);
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(70, 240);
            target.AddBuff(69, 240);
        }
	}
}
