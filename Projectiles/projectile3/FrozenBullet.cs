using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FrozenBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰霜弹");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 30;
			base.projectile.height = 10;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 300;
			base.projectile.alpha = 0;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.velocity.Length() < 27f)
            {
                projectile.velocity *= 27f / projectile.velocity.Length();
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(44, 300);
            target.AddBuff(46, 300);
            if(Main.rand.Next(60) == 1)
            {
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
                {
                    target.AddBuff(mod.BuffType("Freeze"), 60);
                    target.AddBuff(mod.BuffType("Freeze2"), 62);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 60);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 62);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 60);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 62);
                        }
                    }
                }
            }
        }
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 88, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num].velocity *= 0.2f;
            }
        }
    }
}
