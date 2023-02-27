using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class SkullPBonbShoot : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("机械骷髅爆炸剑气");
			Main.projFrames[base.projectile.type] = 2;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 34;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.aiStyle = 27;
            this.cooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            if(projectile.timeLeft % 30 < 15)
            {
                projectile.frame = 0;
            }
            else
            {
                projectile.frame = 1;
            }
            if (Main.rand.Next(0, 150) > 75)
            {
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 2f, 0, 0, 6, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
            else
            {
                int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 2f, 0, 0, 6, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].velocity *= 0.0f;
            }
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                int uo = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 164, projectile.damage * 2, 1, Main.myPlayer, 0f, 0f);
                Main.projectile[uo].friendly = true;
                Main.projectile[uo].hostile = false;
            }
            for (int i = 0; i < 15; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int i = 0; i < 15; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        // Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
    }
}
