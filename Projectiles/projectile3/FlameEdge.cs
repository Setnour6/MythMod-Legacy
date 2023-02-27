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
    public class FlameEdge : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("烈焰边锋");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 44;
			base.projectile.height = 44;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 18;
			base.projectile.timeLeft = 60;
            base.projectile.localNPCHitCooldown = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 55;
		}
		public override void AI()
		{
            base.projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X)) + (float)Math.PI * 0.25f;
            base.projectile.velocity.X *= 0.99f;
            base.projectile.velocity.Y *= 0.99f;
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
                        Main.npc[j].StrikeNPC(projectile.damage, projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        projectile.penetrate--;
                    }
                }
            }
        }
		public override void Kill(int timeLeft)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color((float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, 0));
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, base.projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(22, 22), projectile.scale, SpriteEffects.None, 0f);
            for (int i = 0; i < 20; i++)
            {
                float p = (float)projectile.timeLeft / 60f;
                Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i * 0.6f, null, new Color(p * (1 - 1 / 20f * (float)i), p * (1 - 1 / 4f * (float)i), p * (1 - 1 / 4f * (float)i),0), projectile.rotation, new Vector2(22, 22), projectile.scale * (1 - i / 60f), SpriteEffects.None, 0f);
            }
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 600);
        }
	}
}