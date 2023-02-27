using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 火山陨石 : ModProjectile
	{
		private int num1 = 0;
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("火山陨石");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 10000;
            base.Projectile.friendly = false;
			base.Projectile.hostile = true;
			this.CooldownSlot = 1;
            base.Projectile.tileCollide = false;
			ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
		}
        public override bool PreAI()
        {
			NPC npc = Main.npc[NPC.FindFirstNPC(base.Mod.Find<ModNPC>("火山浮石").Type)];
			Vector2 playerposition = Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
            num1 += 1;
			if(num1 < 600f)
			{
				Projectile.Center = npc.Center + new Vector2(0, 100).RotatedBy(Math.PI * num1 * num1 / 14000f);
			}
			else
			{
				Projectile.timeLeft = 120;
				Vector2 vector = npc.Center - Projectile.Center + playerposition;
				float num2 = (float)(Math.Sqrt((playerposition.X - Projectile.Center.X) * (playerposition.X - Projectile.Center.X) + (playerposition.Y - Projectile.Center.Y) * (playerposition.Y - Projectile.Center.Y)));
				if(Math.Abs(Math.Atan2(vector.X, vector.Y) - Math.Atan2(playerposition.X - Projectile.Center.X, playerposition.Y - Projectile.Center.Y)) < 0.157f)
				{
					Projectile.tileCollide = true;
					Projectile.velocity = (playerposition - Projectile.Center) / num2 * 10f;
				}
				else
				{
					Projectile.Center = npc.Center + new Vector2(0, 100).RotatedBy(Math.PI * num1 * num1 / 14000f);
				}
			}
			if(num1 > 750)
			{
				num1 = 0;
			}
			return false;
        }
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
            int dustID = Dust.NewDust(Projectile.Center, 0, 0, 6, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 0.9f * (float)Projectile.scale);/*粉尘效果不用管*/
            int dustID2 = Dust.NewDust(Projectile.Center, 0, 0, 87, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 0.7f * (float)Projectile.scale);/*粉尘效果不用管*/
            int dustID3 = Dust.NewDust(Projectile.Center, 0, 0, 6, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 0.9f * (float)Projectile.scale);/*粉尘效果不用管*/
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.45f  * (float)Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 0.1f  * (float)Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
			base.Projectile.velocity.Y += 0.1f;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
		public override bool PreDraw(ref Color lightColor)
		{
            return true;
		}
	}
}
