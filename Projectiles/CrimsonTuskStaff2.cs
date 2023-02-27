using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class CrimsonTuskStaff2 : ModProjectile
	{
		private bool initialization = true;
		private bool initialization2 = true;
        private float X;
		private float Y;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("CrimsonTuskStaff");
			Main.projFrames[base.Projectile.type] = 6;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 32;
			base.Projectile.hostile = false;
			base.Projectile.friendly = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 2400;
			base.Projectile.extraUpdates = 10;
			base.Projectile.tileCollide = true;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
	public override void AI()
		{
			if(initialization2)
			{
				X = 0;
				initialization2 = false;
				Y = base.Projectile.Center.Y;
			}
			if(Projectile.velocity.Y == 0 && Projectile.timeLeft >= 2385)
			{
				base.Projectile.timeLeft = 0;
			}
			if(Projectile.velocity.Y == 0 && Projectile.timeLeft % 15 == 0 && X < 5)
			{
                base.Projectile.frame++;
				if(X == 0)
				{            
					for (int i = 0; i < 25; i++)
                    {
				        int r = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y + 22f) + base.Projectile.velocity * 3f, 0, 0, 5, (float)Main.rand.Next(-2000,2000) / 6000f, -1f, 0, default(Color), 0.7f);
			            Main.dust[r].velocity.X *= 0.95f;
			            Main.dust[r].noGravity = false;
					}
					base.Projectile.friendly = true;
				}
				X += 1;
		    }
            if(Projectile.timeLeft <= 500 && Projectile.timeLeft % 10 == 0 && base.Projectile.frame > 0)
			{
                base.Projectile.frame--;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.Projectile.velocity.X != oldVelocity.X)
            {
                base.Projectile.velocity.X = 0f;
            }
            if (base.Projectile.velocity.Y != oldVelocity.Y)
            {
                base.Projectile.velocity.Y = 0f;
            }
			return false;
		}
	}
}
