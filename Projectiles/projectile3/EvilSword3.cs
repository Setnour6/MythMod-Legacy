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
    public class EvilSword3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("邪魔剑气");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 10;
            projectile.alpha = 255;
            base.projectile.extraUpdates = 100;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            projectile.tileCollide = false;
            base.projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            if (projectile.alpha > 5)
            {
                projectile.alpha -= 25;
            }
            else
            {
                projectile.penetrate = 1;
            }
            float num20 = base.projectile.Center.X;
            float num30 = base.projectile.Center.Y;
            float num4 = 1200f;
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
                        num20 = num5;
                        num30 = num6;
                        flag = true;
                    }
                }
            }
            if (flag && projectile.timeLeft % 20 < 10)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num20 - vector1.X;
                float num10 = num30 - vector1.Y;
                Vector2 v = new Vector2(num20, num30) - projectile.Center;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * v.Length() * 2 + num9) / (v.Length() * 2 + 1);
                base.projectile.velocity.Y = (base.projectile.velocity.Y * v.Length() * 2 + num10) / (v.Length() * 2 + 1);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
    }
}
