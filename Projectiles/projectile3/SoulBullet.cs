using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class SoulBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("幽魂弹");
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 30;
            Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.height = 10;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 800;
			base.Projectile.alpha = 255;
            base.Projectile.friendly = true;
            Projectile.extraUpdates = 5;
            this.CooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.4f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f);
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.timeLeft < 784)
            {
                int num90 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity, 0, 0, 135, 0f, 0f, 100, default(Color), 1.6f);
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity *= 0.0f;
            }
            else
            {
                int num90 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity, 0, 0, 135, 0f, 0f, 100, default(Color), 1.6f * (795 - Projectile.timeLeft) / 11f);
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity *= 0.0f;
                if (Projectile.velocity.Length() > 7f)
                {
                    Projectile.velocity *= 0.9f;
                }
                Projectile.alpha -= 10;
            }
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
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
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 60f + num9) / 61f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 60f + num10) / 61f;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.Next(4) == 1)
            {
                if (target.type != 488)
                {
                     Projectile.NewProjectile(target.Center.X, target.position.Y + target.height / 20f, 0, 0, 305, 1000, 0, Main.myPlayer, 0, 1);
                }
            }
        }
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 135, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].noGravity = true;
            }
        }
    }
}
