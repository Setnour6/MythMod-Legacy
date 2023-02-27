using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020009B9 RID: 2489
	public class 硫磺玄武岩链球 : ModProjectile
	{
		// Token: 0x0600318B RID: 12683 RVA: 0x0001003B File Offset: 0x0000E23B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("硫磺玄武岩链球");
		}

		// Token: 0x0600318C RID: 12684 RVA: 0x0026DFDC File Offset: 0x0026C1DC
		public override void SetDefaults()
		{
			base.projectile.width = 56;
			base.projectile.height = 56;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.penetrate = -1;
			base.projectile.melee = true;
			base.projectile.alpha = 255;
		}

		// Token: 0x0600318D RID: 12685 RVA: 0x0026E044 File Offset: 0x0026C244
		public override void AI()
		{
			Vector2 vector = Main.player[base.projectile.owner].Center - base.projectile.Center;
			base.projectile.rotation = Utils.ToRotation(vector) - 1.57f;
			if (Main.player[base.projectile.owner].dead)
			{
				base.projectile.Kill();
				return;
			}
			Main.player[base.projectile.owner].itemAnimation = 10;
			Main.player[base.projectile.owner].itemTime = 10;
			if (vector.X < 0f)
			{
				Main.player[base.projectile.owner].ChangeDir(1);
				base.projectile.direction = 1;
			}
			else
			{
				Main.player[base.projectile.owner].ChangeDir(-1);
				base.projectile.direction = -1;
			}
			Main.player[base.projectile.owner].itemRotation = Utils.ToRotation(vector * -1f * (float)base.projectile.direction);
			base.projectile.spriteDirection = ((vector.X > 0f) ? -1 : 1);
			if (base.projectile.ai[0] == 0f && vector.Length() > 400f)
			{
				base.projectile.ai[0] = 1f;
			}
			if (base.projectile.ai[0] == 1f || base.projectile.ai[0] == 2f)
			{
				float num = vector.Length();
				if (num > 1500f)
				{
					base.projectile.Kill();
					return;
				}
				if (num > 600f)
				{
					base.projectile.ai[0] = 2f;
				}
				float num2 = 1.6f;
				if (base.projectile.ai[0] == 2f)
				{
					num2 = 1.6f;
				}
                base.projectile.velocity += Vector2.Normalize(vector) * num2;
				if (vector.Length() < 25)
				{
					base.projectile.Kill();
					return;
				}
                if (base.projectile.velocity.Y < 0)
                {
                    base.projectile.tileCollide = false;
                }
                else
                {
                    base.projectile.tileCollide = true;
                }
            }
			float[] ai = base.projectile.ai;
			int num3 = 1;
			float num4 = ai[num3];
			ai[num3] = num4 + 1f;
			if (base.projectile.ai[1] > 5f)
			{
				base.projectile.alpha = 0;
			}
            if (projectile.velocity.Y < 6f)
            {
                projectile.velocity.Y += 0.5f;
            }
        }

		// Token: 0x0600318E RID: 12686 RVA: 0x00219BDC File Offset: 0x00217DDC
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Collision.HitTiles(base.projectile.position, base.projectile.velocity, base.projectile.width, base.projectile.height);
			base.projectile.ai[0] = 1f;
			base.projectile.netUpdate = true;
			Main.PlaySound(0, (int)base.projectile.position.X, (int)base.projectile.position.Y, 1, 1f, 0f);
            projectile.velocity *= -1;
            for (int j = 0; j < 27; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
            for (int i = 0; i <= 9; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 7000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("硫磺火粒"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            return false;
		}

		// Token: 0x0600318F RID: 12687 RVA: 0x0026E3CC File Offset: 0x0026C5CC
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Vector2 mountedCenter = Main.player[base.projectile.owner].MountedCenter;
			Color transparent = Color.Transparent;
			Texture2D texture = base.mod.GetTexture("UIImages/硫磺玄武岩链球chain");
			Vector2 vector = base.projectile.Center;
			Rectangle? sourceRectangle = null;
			Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num = (float)texture.Height;
			Vector2 vector2 = mountedCenter - vector;
			float rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) - 1.57f;
			bool flag = true;
			if (float.IsNaN(vector.X) && float.IsNaN(vector.Y))
			{
				flag = false;
			}
			if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
			{
				flag = false;
			}
			while (flag)
			{
				if (vector2.Length() < num + 1f)
				{
					flag = false;
				}
				else
				{
					Vector2 value = vector2;
					value.Normalize();
					vector += value * num;
					vector2 = mountedCenter - vector;
					Color color = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f));
					Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
				}
			}
			return true;
		}

		// Token: 0x06003190 RID: 12688 RVA: 0x0001004D File Offset: 0x0000E24D
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            for (int j = 0; j < 27; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 8f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 8f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
            for (int i = 0; i <= 9; i++)
            {
                float num4 = (float)(Main.rand.Next(500, 7000));
                double num1 = Main.rand.Next(0, 1000) / 500f;
                double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
                double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("硫磺火粒"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            base.projectile.ai[0] = 1f;
			base.projectile.netUpdate = true;
		}
	}
}
