using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020005D7 RID: 1495
    public class SmallFlame : ModProjectile
	{
		// Token: 0x060020B3 RID: 8371 RVA: 0x0000C20B File Offset: 0x0000A40B
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("大火球");
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x001A5BBC File Offset: 0x001A3DBC
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.alpha = 255;
			base.Projectile.aiStyle = 1;
			base.Projectile.penetrate = -1;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x001A5C18 File Offset: 0x001A3E18
		public override void AI()
		{
            int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
            int dustID2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 87, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.3f);/*粉尘效果不用管*/
            int dustID3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
			base.Projectile.velocity.Y = base.Projectile.velocity.Y + 0.05f;
			if(Main.rand.Next(0,100) == 1)
		    {
				int num34 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, base.Projectile.velocity.X + (float)Main.rand.Next(-200,200) / 200f, base.Projectile.velocity.Y + (float)Main.rand.Next(-2,2) / 200f, base.Mod.Find<ModProjectile>("SmallSmallFlame").Type, 555, 2f, Main.myPlayer, 0f, 0f);
                Main.projectile[num34].timeLeft = 240;
			}
		}
		// Token: 0x060020B6 RID: 8374 RVA: 0x0000D160 File Offset: 0x0000B360
		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(24, 720, true);
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x001A5E00 File Offset: 0x001A4000
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 6, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
