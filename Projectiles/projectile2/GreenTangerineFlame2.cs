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
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = false;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 600;
            base.Projectile.hostile = true;
        }
        private bool l = false;
		// Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, 61, 0, 0, 0, default(Color), 2f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
            if(Projectile.timeLeft >= 450 && Projectile.velocity.Length() < 25f)
            {
                Projectile.velocity += (player.Center - Projectile.Center) / (player.Center - Projectile.Center).Length() * 0.1f;
            }
            if (Projectile.timeLeft >= 550 && Projectile.velocity.Length() >= 15f)
            {
                Projectile.velocity *= 0.98f;
            }
            if(Main.rand.Next(1000) == 50)
            {
                l = true;
                Vector2 v = Projectile.velocity.RotatedBy(Math.PI / 18f);
                int x = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("GreenTangerineFlame2").Type, 140, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[x].timeLeft = Projectile.timeLeft;
                Vector2 v2 = Projectile.velocity.RotatedBy(Math.PI / -18f);
                int y = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("GreenTangerineFlame2").Type, 140, 0f, Main.myPlayer, 0f, 0f);
                Main.projectile[y].timeLeft = Projectile.timeLeft;
                Projectile.active = false;
            }
        }

		// Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
			return false;
		}

        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            if(!l)
            {
                for (int i = 0; i < 30; i++)
                {
                    int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 61, 0f, 0f, 100, default(Color), 1.2f);
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
