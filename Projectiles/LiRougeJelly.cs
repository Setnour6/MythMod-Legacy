using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
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
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 80;
			base.Projectile.timeLeft = 3000;
			base.Projectile.penetrate = 2;
			base.Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
		}

		// Token: 0x06001DBC RID: 7612 RVA: 0x0017EE90 File Offset: 0x0017D090
        public override void AI()
        {
            if(base.Projectile.timeLeft >= 2990)
            {
                base.Projectile.timeLeft = Main.rand.Next(270, 335);
            }
            Lighting.AddLight(base.Projectile.Center, 0.5f, 0f, 0f);
            Projectile projectile = base.Projectile;
            projectile.velocity.X = projectile.velocity.X * 0.99f;
            Projectile projectile2 = base.Projectile;
            projectile2.velocity.Y = projectile2.velocity.Y * 0.99f;
            Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 0.7f);
        }

		// Token: 0x06001DBD RID: 7613 RVA: 0x0017EF80 File Offset: 0x0017D180
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 30; i++)
			{
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 183, base.Projectile.oldVelocity.X * 1.2f, base.Projectile.oldVelocity.Y * 1.2f, 0, default(Color), 1.3f);
			}
			SoundEngine.PlaySound(SoundID.Item105.WithVolumeScale(0.3f), new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
		}

		// Token: 0x06001DBE RID: 7614 RVA: 0x0000C2FC File Offset: 0x0000A4FC
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            target.AddBuff(70, 240);
            target.AddBuff(69, 240);
        }
	}
}
