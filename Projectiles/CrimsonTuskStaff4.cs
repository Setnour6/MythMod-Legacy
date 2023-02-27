using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class CrimsonTuskStaff4 : ModProjectile
	{
		private bool initialization = true;
		private bool initialization2 = true;
        private float X;
		private float Y;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("CrimsonTuskStaff");
			Main.projFrames[base.projectile.type] = 6;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 8;
			base.projectile.height = 50;
			base.projectile.hostile = false;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 2400;
			base.projectile.extraUpdates = 10;
			base.projectile.tileCollide = true;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if(initialization2)
			{
				X = 0;
				initialization2 = false;
				Y = base.projectile.Center.Y;
			}
			if(projectile.velocity.Y == 0 && projectile.timeLeft >= 2378)
			{
				base.projectile.timeLeft = 0;
			}
			if(projectile.velocity.Y == 0 && projectile.timeLeft % 15 == 0 && X < 5)
			{
                base.projectile.frame++;
				if(X == 0)
				{            
					for (int i = 0; i < 25; i++)
                    {
				        int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y + 22f) + base.projectile.velocity * 3f, 0, 0, 5, (float)Main.rand.Next(-2000,2000) / 6000f, -1f, 0, default(Color), 0.7f);
			            Main.dust[r].velocity.X *= 0.95f;
			            Main.dust[r].noGravity = false;
					}
					base.projectile.friendly = true;
				}
				X += 1;
		    }
            if(projectile.timeLeft <= 500 && projectile.timeLeft % 10 == 0 && base.projectile.frame > 0)
			{
                base.projectile.frame--;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.projectile.velocity.X != oldVelocity.X)
            {
                base.projectile.velocity.X = 0f;
            }
            if (base.projectile.velocity.Y != oldVelocity.Y)
            {
                base.projectile.velocity.Y = 0f;
            }
			return false;
		}
	}
}
