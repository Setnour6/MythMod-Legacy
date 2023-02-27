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
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 10000;
            base.projectile.friendly = false;
			base.projectile.hostile = true;
			this.cooldownSlot = 1;
            base.projectile.tileCollide = false;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
		}
        public override bool PreAI()
        {
			NPC npc = Main.npc[NPC.FindFirstNPC(base.mod.NPCType("火山浮石"))];
			Vector2 playerposition = Main.screenPosition + new Vector2(Main.screenWidth / 2, Main.screenHeight / 2);
            num1 += 1;
			if(num1 < 600f)
			{
				projectile.Center = npc.Center + new Vector2(0, 100).RotatedBy(Math.PI * num1 * num1 / 14000f);
			}
			else
			{
				projectile.timeLeft = 120;
				Vector2 vector = npc.Center - projectile.Center + playerposition;
				float num2 = (float)(Math.Sqrt((playerposition.X - projectile.Center.X) * (playerposition.X - projectile.Center.X) + (playerposition.Y - projectile.Center.Y) * (playerposition.Y - projectile.Center.Y)));
				if(Math.Abs(Math.Atan2(vector.X, vector.Y) - Math.Atan2(playerposition.X - projectile.Center.X, playerposition.Y - projectile.Center.Y)) < 0.157f)
				{
					projectile.tileCollide = true;
					projectile.velocity = (playerposition - projectile.Center) / num2 * 10f;
				}
				else
				{
					projectile.Center = npc.Center + new Vector2(0, 100).RotatedBy(Math.PI * num1 * num1 / 14000f);
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
			projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            int dustID = Dust.NewDust(projectile.Center, 0, 0, 6, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 0.9f * (float)projectile.scale);/*粉尘效果不用管*/
            int dustID2 = Dust.NewDust(projectile.Center, 0, 0, 87, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 0.7f * (float)projectile.scale);/*粉尘效果不用管*/
            int dustID3 = Dust.NewDust(projectile.Center, 0, 0, 6, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 0.9f * (float)projectile.scale);/*粉尘效果不用管*/
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.45f  * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0.1f  * (float)projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
			base.projectile.velocity.Y += 0.1f;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
            return true;
		}
	}
}
