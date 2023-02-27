using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 星散裂 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星散裂");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.alpha = 255;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 100;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			if(base.Projectile.timeLeft > 20)
			{
			    int ID = Dust.NewDust(Projectile.Center, 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID].noGravity = true;
		        Main.dust[ID].velocity.X = Projectile.velocity.Y;
		    	Main.dust[ID].velocity.Y = -Projectile.velocity.X;
		    	int ID2 = Dust.NewDust(Projectile.Center, 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID2].noGravity = true;
		        Main.dust[ID2].velocity.X = -Projectile.velocity.Y;
		    	Main.dust[ID2].velocity.Y = Projectile.velocity.X;
			}
			else
			{
                int ID = Dust.NewDust(Projectile.Center, 0, 0, 159, 0, -Projectile.velocity.X * base.Projectile.timeLeft / 20f, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID].noGravity = true;
		        Main.dust[ID].velocity.X = Projectile.velocity.Y;
		    	Main.dust[ID].velocity.Y = -Projectile.velocity.X;
		    	int ID2 = Dust.NewDust(Projectile.Center, 0, 0, 159, 0, Projectile.velocity.X * base.Projectile.timeLeft / 20f, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID2].noGravity = true;
		        Main.dust[ID2].velocity.X = -Projectile.velocity.Y * base.Projectile.timeLeft / 20f;
		    	Main.dust[ID2].velocity.Y = Projectile.velocity.X * base.Projectile.timeLeft / 20f;
			}
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
	}
}
