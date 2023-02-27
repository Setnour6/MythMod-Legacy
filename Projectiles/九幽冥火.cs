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
            Main.projFrames[Projectile.type] = 3; /*【帧数为6】对应的贴图也要画6帧哦*/
		}
		private bool initialization = true;
        private float X;
		private Vector2 A ;
		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.Projectile.width = 24;
			base.Projectile.height = 48;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 300;
			base.Projectile.DamageType = DamageClass.Magic;
		}
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			if (initialization)
            {
                X = Main.rand.Next(0,2000) / 1000f;
				initialization = false;
            }
			if(base.Projectile.timeLeft % 2 == 0)
			{
                base.Projectile.frameCounter++;
			}
            if (base.Projectile.frameCounter > 3)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 2)
            {
                base.Projectile.frame = 0;
            }
			if (base.Projectile.velocity.X * base.Projectile.velocity.X + base.Projectile.velocity.X * base.Projectile.velocity.X > 120)
            {
                base.Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / 20f);
				base.Projectile.velocity *= 0.99f;
            }
			float num = base.Projectile.Center.X;
			float num2 = base.Projectile.Center.Y;
			float num3 = 700f;
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float num4 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num5 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num6 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num4) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num5);
					if (num6 < num3)
					{
						num3 = num6;
						num = num4;
						num2 = num5;
						flag = true;
					}
				}
                if ((Projectile.Center - Main.npc[i].Center).Length() <= 50 && Main.npc[i].active && !Main.npc[i].friendly)
                {
                    float num1 = 10 / (float)Math.Sqrt(((float)Projectile.Center.X - (float)Main.npc[i].position.X) * ((float)Projectile.Center.X - (float)Main.npc[i].position.X) + ((float)Projectile.Center.Y - (float)Main.npc[i].position.Y) * ((float)Projectile.Center.Y - (float)Main.npc[i].position.Y));
                    A = new Vector2((float)Projectile.Center.X - (float)Main.npc[i].position.X, (float)Projectile.Center.Y - (float)Main.npc[i].position.Y) * num1;
                }
            }
			if (flag)
			{
				if(base.Projectile.timeLeft % 5 == 0 && Projectile.timeLeft > 45)
				{
					int num34 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)-A.X,(float)-A.Y , base.Mod.Find<ModProjectile>("灭世火光粒").Type, 6666, 0.2f, Main.myPlayer, 0f, 0f);

				}
				float num7 = 20f;
				Vector2 vector = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num8 = num - vector.X;
				float num9 = num2 - vector.Y;
				float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num8) / (20f + (float)num3 / 1500f);
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num9) / (20f + (float)num3 / 1500f);
				return;
			}
			else
			{
				X += 1 / 30f;
			    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI / 60f * (float)Math.Sin(X * Math.PI));
			}
			if (Projectile.timeLeft < 45)
            {
                Projectile.scale *= 0.93f;
            }
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.378f / 255f * (float)Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.75f / 255f * (float)Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.714f / 255f * (float)Projectile.scale);
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
