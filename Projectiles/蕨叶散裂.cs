using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 蕨叶散裂 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蕨叶散裂");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.extraUpdates = 3;
			base.projectile.width = 8;
			base.projectile.height = 8;
			base.projectile.hostile = true;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 480;
			base.projectile.alpha = 255;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (initialization)
            {
				initialization = false;
            }
			else
			{
			    int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 61, 0, 0, 0, default(Color), 2f * base.projectile.timeLeft / 48);
			    Main.dust[r].velocity.X = 0;
			    Main.dust[r].velocity.Y = 0;
			    Main.dust[r].noGravity = true;
				float num = Main.rand.Next(-1000,1000) / 1000f;
				int x = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 2, 0, 0, 0, default(Color), 1.5f * base.projectile.timeLeft / 48);
			    Main.dust[x].velocity.X = (float)projectile.velocity.Y * 2f * num;
			    Main.dust[x].velocity.Y = (float)projectile.velocity.X * 2f * num;
			    Main.dust[x].noGravity = true;
            	Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
			}
		}
	}
}
