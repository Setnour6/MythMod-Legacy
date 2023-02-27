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
    public class WindBlade : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("风之刃");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 44;
			base.projectile.height = 44;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 8;
			base.projectile.timeLeft = 480;
            base.projectile.localNPCHitCooldown = 0;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = false;
            base.projectile.tileCollide = true;
            base.projectile.alpha = 55;
		}
		public override void AI()
		{
            base.projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.3f + 0.8f * projectile.timeLeft / 480f;
            base.projectile.velocity.X *= 1.05f;
            base.projectile.velocity.Y *= 1.05f;
            Lighting.AddLight(base.projectile.Center, 0f, (float)projectile.timeLeft / 1200f, (float)projectile.timeLeft / 1200f);
            if (projectile.timeLeft % 3 == 1)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 22, 22, 99, projectile.velocity.X, projectile.velocity.Y, 0, default(Color), 1.5f);
                Main.dust[r].noGravity = true;
            }
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
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
            for (int i = 0; i < 20; i++)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.2f - new Vector2(4, 4), 22, 22, 99, projectile.oldVelocity.X, projectile.oldVelocity.Y, 0, default(Color), 1.5f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 150));
            }
            else
            {
                return new Color?(new Color((float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, 0));
            }
        }
	}
}