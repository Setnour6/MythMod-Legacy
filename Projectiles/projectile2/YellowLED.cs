using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000749 RID: 1865
    public class YellowLED : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("黄灯");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.projectile.width = 16;
            base.projectile.tileCollide = true;
            base.projectile.height = 16;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.melee = true;
            base.projectile.aiStyle = -1;
			base.projectile.scale = 1f;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
		public override void AI()
		{
            projectile.velocity *= 0.98f;
            projectile.velocity.Y += 0.15f;
            if (projectile.timeLeft % 3 == 0)
            {
                int num = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 16, 0, 0, 0, default(Color), 0.5f);
                Main.dust[num].velocity *= 0;
            }
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num8 = 50f;
                Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
                projectile.velocity *= 0.65f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            if ((int)(Main.time / 5f) % 12 >= 9 && (int)(Main.time / 5f) % 12 < 12)
            {
                return new Color?(new Color(255, 255, 255, 80));
            }
            else
            {
                return new Color?(new Color(90, 90, 90, 80));
            }
        }
        // Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 87, 0, 0, 0, default(Color), 1f);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            if ((int)(Main.time / 5f) % 12 >= 9 && (int)(Main.time / 5f) % 12 < 12)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球金light"), base.projectile.Center - Main.screenPosition, null, new Color(0.1f, 0.1f, 0.1f, 0), base.projectile.rotation, new Vector2(56f, 56f), 1, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
