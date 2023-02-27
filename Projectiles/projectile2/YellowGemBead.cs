using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200067D RID: 1661
    public class YellowGemBead : ModProjectile
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("黄玉弹球");
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001D6574 File Offset: 0x001D4774
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = 1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
		public override void AI()
		{
            int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, 87, 0, 0, 0, default(Color), 1f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
        }

		// Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int num = Projectile.NewProjectile(base.projectile.Center.X + base.projectile.velocity.X * 2f, base.projectile.Center.Y + base.projectile.velocity.Y * 2f, base.projectile.velocity.X, base.projectile.velocity.Y, 51, 10, 0, Main.myPlayer, 0f, 0f);
            Main.projectile[num].penetrate = 4;
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 0.4f, 0f);
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 87, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        public int projTime = 15;

		// Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
	}
}
