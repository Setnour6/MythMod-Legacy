using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class CrisomMoon2 : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("赤月");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 44;
			base.projectile.height = 44;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 8;
			base.projectile.timeLeft = 480;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 55;
		}
        private bool Hit = false;
        private float Omega = 0.8f;
        public override void AI()
        {
            base.projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            base.projectile.rotation -= Omega;
            Omega *= 0.994f;
            base.projectile.velocity.X *= 0.96f;
            base.projectile.velocity.Y *= 0.96f;
            Lighting.AddLight(base.projectile.Center, (float)projectile.timeLeft / 1200f, 0f, 0f);
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
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC((int)(projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)), projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        projectile.penetrate--;
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
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
            if(projectile.timeLeft == 270 && !Hit)
            {
                projectile.velocity = new Vector2(0, Main.rand.NextFloat(9f)).RotatedByRandom(Math.PI * 2);
            }
        }
		public override void Kill(int timeLeft)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            if(projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, 0));
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            float im = Omega * 50;
            if (im >= 1)
            {
                for (int i = 0; i < im; i++)
                {
                    Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i / im, null, new Color(i / im * Omega * 2.5f, i / im * Omega * 2.5f, i / im * Omega * 2.5f, i / im * projectile.alpha / 255f * Omega * 2.5f), projectile.rotation - Omega * i * 0.4f, new Vector2(22, 22), projectile.scale, effects, 0f);
                }
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.velocity = new Vector2(0, Main.rand.NextFloat(9f)).RotatedByRandom(Math.PI * 2);
            Hit = true;
            target.AddBuff(24, 600);
        }
	}
}