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
            // base.DisplayName.SetDefault("风之刃");
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 44;
			base.Projectile.height = 44;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 8;
			base.Projectile.timeLeft = 480;
            base.Projectile.localNPCHitCooldown = 0;
            base.Projectile.extraUpdates = 1;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = true;
            base.Projectile.alpha = 55;
		}
		public override void AI()
		{
            base.Projectile.alpha = (int)(55 + (float)(400 - (float)Projectile.timeLeft) / 2);
            base.Projectile.rotation -= (float)Math.Sqrt((float)Projectile.velocity.X * (float)Projectile.velocity.X + (float)Projectile.velocity.Y * (float)Projectile.velocity.Y) * 0.3f + 0.8f * Projectile.timeLeft / 480f;
            base.Projectile.velocity.X *= 1.05f;
            base.Projectile.velocity.Y *= 1.05f;
            Lighting.AddLight(base.Projectile.Center, 0f, (float)Projectile.timeLeft / 1200f, (float)Projectile.timeLeft / 1200f);
            if (Projectile.timeLeft % 3 == 1)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 1.2f - new Vector2(4, 4), 22, 22, 99, Projectile.velocity.X, Projectile.velocity.Y, 0, default(Color), 1.5f);
                Main.dust[r].noGravity = true;
            }
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC(Projectile.damage, Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                    }
                }
            }
        }
		public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 20; i++)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 1.2f - new Vector2(4, 4), 22, 22, 99, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 0, default(Color), 1.5f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 150));
            }
            else
            {
                return new Color?(new Color((float)Projectile.timeLeft / 60f, (float)Projectile.timeLeft / 60f, (float)Projectile.timeLeft / 60f, 0));
            }
        }
	}
}