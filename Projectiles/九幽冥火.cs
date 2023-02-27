using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
	public class 九幽冥火 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("九幽冥火");
            Main.projFrames[projectile.type] = 3; /*【帧数为6】对应的贴图也要画6帧哦*/
		}
		private bool initialization = true;
        private float X;
		private Vector2 A ;
		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 24;
			base.projectile.height = 48;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 300;
			base.projectile.magic = true;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			if (initialization)
            {
                X = Main.rand.Next(0,2000) / 1000f;
				initialization = false;
            }
			if(base.projectile.timeLeft % 2 == 0)
			{
                base.projectile.frameCounter++;
			}
            if (base.projectile.frameCounter > 3)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 2)
            {
                base.projectile.frame = 0;
            }
			if (base.projectile.velocity.X * base.projectile.velocity.X + base.projectile.velocity.X * base.projectile.velocity.X > 120)
            {
                base.projectile.velocity = projectile.velocity.RotatedBy(Math.PI / 20f);
				base.projectile.velocity *= 0.99f;
            }
			float num = base.projectile.Center.X;
			float num2 = base.projectile.Center.Y;
			float num3 = 700f;
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float num4 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num5 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num6 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num4) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num5);
					if (num6 < num3)
					{
						num3 = num6;
						num = num4;
						num2 = num5;
						flag = true;
					}
				}
                if ((projectile.Center - Main.npc[i].Center).Length() <= 50 && Main.npc[i].active && !Main.npc[i].friendly)
                {
                    float num1 = 10 / (float)Math.Sqrt(((float)projectile.Center.X - (float)Main.npc[i].position.X) * ((float)projectile.Center.X - (float)Main.npc[i].position.X) + ((float)projectile.Center.Y - (float)Main.npc[i].position.Y) * ((float)projectile.Center.Y - (float)Main.npc[i].position.Y));
                    A = new Vector2((float)projectile.Center.X - (float)Main.npc[i].position.X, (float)projectile.Center.Y - (float)Main.npc[i].position.Y) * num1;
                }
            }
			if (flag)
			{
				if(base.projectile.timeLeft % 5 == 0 && projectile.timeLeft > 45)
				{
					int num34 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)-A.X,(float)-A.Y , base.mod.ProjectileType("灭世火光粒"), 6666, 0.2f, Main.myPlayer, 0f, 0f);

				}
				float num7 = 20f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num8 = num - vector.X;
				float num9 = num2 - vector.Y;
				float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num8) / (20f + (float)num3 / 1500f);
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num9) / (20f + (float)num3 / 1500f);
				return;
			}
			else
			{
				X += 1 / 30f;
			    projectile.velocity = projectile.velocity.RotatedBy(Math.PI / 60f * (float)Math.Sin(X * Math.PI));
			}
			if (projectile.timeLeft < 45)
            {
                projectile.scale *= 0.93f;
            }
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.378f / 255f * (float)projectile.scale, (float)(255 - base.projectile.alpha) * 0.75f / 255f * (float)projectile.scale, (float)(255 - base.projectile.alpha) * 0.714f / 255f * (float)projectile.scale);
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
		public override void Kill(int timeLeft)
		{
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
