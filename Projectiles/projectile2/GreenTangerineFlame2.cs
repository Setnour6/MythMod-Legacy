using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200067D RID: 1661
    public class GreenTangerineFlame2 : ModProjectile
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("年桔烈火");
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001D6574 File Offset: 0x001D4774
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = false;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 600;
            base.projectile.hostile = true;
        }
        private bool l = false;
		// Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, 61, 0, 0, 0, default(Color), 2f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
            if(projectile.timeLeft >= 450 && projectile.velocity.Length() < 25f)
            {
                projectile.velocity += (player.Center - projectile.Center) / (player.Center - projectile.Center).Length() * 0.1f;
            }
            if (projectile.timeLeft >= 550 && projectile.velocity.Length() >= 15f)
            {
                projectile.velocity *= 0.98f;
            }
            if(Main.rand.Next(1000) == 50)
            {
                l = true;
                Vector2 v = projectile.velocity.RotatedBy(Math.PI / 18f);
                int x = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("GreenTangerineFlame2"), 140, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[x].timeLeft = projectile.timeLeft;
                Vector2 v2 = projectile.velocity.RotatedBy(Math.PI / -18f);
                int y = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v2.X, v2.Y, mod.ProjectileType("GreenTangerineFlame2"), 140, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[y].timeLeft = projectile.timeLeft;
                projectile.active = false;
            }
        }

		// Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}

        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            if(!l)
            {
                for (int i = 0; i < 30; i++)
                {
                    int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 61, 0f, 0f, 100, default(Color), 1.2f);
                    Main.dust[num].velocity *= 1.1f;
                    Main.dust[num].noGravity = true;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num].scale = 0.5f;

                        Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
            }
        }
        public int projTime = 15;

		// Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
	}
}
