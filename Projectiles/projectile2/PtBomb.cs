using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
    public class PtBomb : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铂金钱手雷");
		}
        private float num = 0;
        // Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
        public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            projectile.thrown = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;
            if(projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if(x)
            {
                num += m;
                if(m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
            Dust.NewDust(new Vector2((float)projectile.Center.X, (float)projectile.Center.Y) + new Vector2(0,-10).RotatedBy(projectile.rotation), 0, 0, 6, 0f, 0f, 0, default(Color), 1f);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                if(projectile.velocity.Length() > 0.5f)
                {
                    if (base.projectile.velocity.X != oldVelocity.X)
                    {
                        base.projectile.velocity.X = -oldVelocity.X * 0.6f;
                    }
                    if (base.projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.projectile.velocity.Y = -oldVelocity.Y * 0.6f;
                    }
                }
                else
                {
                    base.projectile.velocity.Y *= 0;
                    base.projectile.velocity.X *= 0;
                    x = true;
                }
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            for (int j = 0; j < 28; j++)
            {
                Vector2 v = new Vector2(0, 10.5f).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("PtCoin"), (int)((double)base.projectile.damage * 0.2f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("PtFlame"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            for (int i = 0; i <= 40; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 100f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 100f;
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("PtDust"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].scale = Main.rand.Next(990, 1500) / 1000f * ((600 - timeLeft) / 600f + 0.4f);
            }
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
