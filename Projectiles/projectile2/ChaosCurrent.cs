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
    public class ChaosCurrent : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("混乱炸流");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 100;
			base.projectile.height = 100;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            projectile.extraUpdates = 10;
            base.projectile.timeLeft = 300;
			this.cooldownSlot = 1;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(31, 300, false);
        }
        private bool boom = false;
        private bool co = false;
        private bool l = true;
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            Player p = Main.player[Main.myPlayer];
            if((p.Center - projectile.Center).Length() < 200)
            {
                if (projectile.timeLeft > 100)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f)).RotatedByRandom(Math.PI * 2f);
                    int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 114, (float)v.X, (float)v.Y, 0, default(Color), 3f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = v;
                }
                else
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f) * (float)projectile.timeLeft / 100f).RotatedByRandom(Math.PI * 2f);
                    int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 114, (float)v.X, (float)v.Y, 0, default(Color), 3f * (float)projectile.timeLeft / 100f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = v;
                }
            }
            else
            {
                if (projectile.timeLeft > 100)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f)).RotatedByRandom(Math.PI * 2f);
                    int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 114, (float)v.X * 200f / (p.Center - projectile.Center).Length(), (float)v.Y * 200f / (p.Center - projectile.Center).Length(), 0, default(Color), 3f * 200f / (p.Center - projectile.Center).Length());
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = v * 200f / (p.Center - projectile.Center).Length();
                }
                else
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f) * (float)projectile.timeLeft / 100f).RotatedByRandom(Math.PI * 2f);
                    int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 114, (float)v.X * 200f / (p.Center - projectile.Center).Length(), (float)v.Y * 200f / (p.Center - projectile.Center).Length(), 0, default(Color), 3f * (float)projectile.timeLeft / 100f * 200f / (p.Center - projectile.Center).Length());
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = v * 200f / (p.Center - projectile.Center).Length();
                }
            }
            if ((p.Center - projectile.Center).Length() < 200)
            {
                if (projectile.timeLeft == 290)
                {
                    for (int r = 0; r < 70; r++)
                    {
                        Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(1400, 2000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Chaos"), projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                }
            }
            else
            {
                if (projectile.timeLeft == 290)
                {
                    for (int r = 0; r < 70; r++)
                    {
                        Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(1400, 2000) / 10000f;
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X * 200f / (p.Center - projectile.Center).Length(), v.Y * 200f / (p.Center - projectile.Center).Length(), mod.ProjectileType("混乱粒子"), projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    }
                }
            }
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
                return new Color?(new Color(0, 0, 0, 0));
		}
    }
}
