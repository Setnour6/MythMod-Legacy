using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 霜雪破散裂 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("霜雪破散裂");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 240;
			base.Projectile.alpha = 255;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            int ID = Dust.NewDust(Projectile.position, 0, 0, 180, 0, 0, 201, default(Color), 1.6f);/*粉尘效果不用管*/
            int ID2 = Dust.NewDust(Projectile.position, 0, 0, 187, 0, 0, 201, default(Color), 1.3f);/*粉尘效果不用管*/
            int ID3 = Dust.NewDust(Projectile.position, 0, 0, 172, 0, 0, 201, default(Color), 1.6f);/*粉尘效果不用管*/
			Main.dust[ID].noGravity = true;
			Main.dust[ID2].noGravity = true;
			Main.dust[ID3].noGravity = true;
			Main.dust[ID].velocity *= 0.0f;
			Main.dust[ID2].velocity *= 0.0f;
			Main.dust[ID3].velocity *= 0.0f;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.15f / 255f, (float)(255 - base.Projectile.alpha) * 0.75f / 255f);
			if(Projectile.timeLeft == 220)
			{
				Vector2 V = base.Projectile.velocity.RotatedBy(Math.PI / 3f);
				Vector2 V2 = base.Projectile.velocity.RotatedBy(Math.PI * 5f / 3f);
				int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)(V.X * 0.7f),(float)(V.Y * 0.7f), base.Mod.Find<ModProjectile>("霜雪破二阶散裂").Type, base.Projectile.damage / 4, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)(V2.X * 0.7f),(float)(V2.Y * 0.7f), base.Mod.Find<ModProjectile>("霜雪破二阶散裂").Type, base.Projectile.damage / 4, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				Main.projectile[num].timeLeft = 48;
				Main.projectile[num2].timeLeft = 48;
			}
			if(Projectile.timeLeft == 184)
			{
				Vector2 V = base.Projectile.velocity.RotatedBy(Math.PI / 3f);
				Vector2 V2 = base.Projectile.velocity.RotatedBy(Math.PI * 5f / 3f);
				int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)(V.X * 0.9f),(float)(V.Y * 0.9f), base.Mod.Find<ModProjectile>("霜雪破二阶散裂").Type, base.Projectile.damage / 4, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)(V2.X * 0.9f),(float)(V2.Y * 0.9f), base.Mod.Find<ModProjectile>("霜雪破二阶散裂").Type, base.Projectile.damage / 4, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				Main.projectile[num].timeLeft = 70;
				Main.projectile[num2].timeLeft = 70;
			}
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
	}
}
