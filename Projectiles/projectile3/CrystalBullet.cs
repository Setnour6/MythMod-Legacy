using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class CrystalBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("金刚砂弹");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 30;
			base.projectile.height = 10;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
            projectile.ranged = true;
            base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 800;
			base.projectile.alpha = 255;
            base.projectile.friendly = true;
            projectile.extraUpdates = 5;
            this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.timeLeft < 784)
            {
            }
            else
            {
                projectile.alpha -= 10;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
		{
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            for (int a = 0; a < 12; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(6f, 7.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("Crystal"), v.X, v.Y, 0, default(Color), 0.7f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.15f) * 0.1f;
            }
            for (int j = 0; j < 200; j++)
            {
                if (!Main.npc[j].dontTakeDamage && (Main.npc[j].Center - projectile.Center).Length() < 90f && !Main.npc[j].friendly)
                {
                    Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), 100 / (Main.npc[j].Center - projectile.Center).Length(), (int)((Main.npc[j].Center.X - projectile.Center.X) / Math.Abs(Main.npc[j].Center.X - projectile.Center.X)));
                }
            }
        }
    }
}
