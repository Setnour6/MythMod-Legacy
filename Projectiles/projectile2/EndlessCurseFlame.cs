using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class EndlessCurseFlame : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("不断咒火");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 210;
			base.projectile.height = 210;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            projectile.extraUpdates = 3;
            base.projectile.timeLeft = 300;
			this.cooldownSlot = 1;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(39, 60, false);
        }
        private bool boom = false;
        private bool co = false;
        private bool l = true;
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            if(projectile.timeLeft > 100)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f)).RotatedByRandom(Math.PI * 2f);
                int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 75, (float)v.X, (float)v.Y, 0, default(Color), 3f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity = v;
            }
            else
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f) * (float)projectile.timeLeft / 100f).RotatedByRandom(Math.PI * 2f);
                int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 75, (float)v.X, (float)v.Y, 0, default(Color), 3f * (float)projectile.timeLeft / 100f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity = v;
            }
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{

                return new Color?(new Color(0, 0, 0, 0));

		}
    }
}
