using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class TwinsBeam1 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("双子魔眼剑气");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 3600;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
			base.projectile.scale = 1.5f;
		}
		public override void AI()
		{
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.25f / 255f, (float)(255 - base.projectile.alpha) * 1.5f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
            int num3 = Dust.NewDust(base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 75, 0, 0, 0, default(Color), 3f);
			float num = base.projectile.Center.X;
			float num2 = base.projectile.Center.Y;
			Main.dust[num3].noGravity = true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(39, 600, false);
		}
		// Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("EndlessCurseFlame"), (int)((double)base.projectile.damage * 0.5f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
        }
	}
}
