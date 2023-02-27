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
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = true;
			base.projectile.alpha = 255;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 100;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			if(base.projectile.timeLeft > 20)
			{
			    int ID = Dust.NewDust(projectile.Center, 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID].noGravity = true;
		        Main.dust[ID].velocity.X = projectile.velocity.Y;
		    	Main.dust[ID].velocity.Y = -projectile.velocity.X;
		    	int ID2 = Dust.NewDust(projectile.Center, 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID2].noGravity = true;
		        Main.dust[ID2].velocity.X = -projectile.velocity.Y;
		    	Main.dust[ID2].velocity.Y = projectile.velocity.X;
			}
			else
			{
                int ID = Dust.NewDust(projectile.Center, 0, 0, 159, 0, -projectile.velocity.X * base.projectile.timeLeft / 20f, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID].noGravity = true;
		        Main.dust[ID].velocity.X = projectile.velocity.Y;
		    	Main.dust[ID].velocity.Y = -projectile.velocity.X;
		    	int ID2 = Dust.NewDust(projectile.Center, 0, 0, 159, 0, projectile.velocity.X * base.projectile.timeLeft / 20f, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		        Main.dust[ID2].noGravity = true;
		        Main.dust[ID2].velocity.X = -projectile.velocity.Y * base.projectile.timeLeft / 20f;
		    	Main.dust[ID2].velocity.Y = projectile.velocity.X * base.projectile.timeLeft / 20f;
			}
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
	}
}
