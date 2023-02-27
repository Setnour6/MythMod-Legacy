using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile3
{
    public class DarkStaff2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("恶魔火球");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 3600;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 3600)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, mod.DustType("DarkF2"), 50f, 50f, 0, default(Color), (float)projectile.scale * 1.6f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].alpha = 150;
            }
            if(projectile.timeLeft <= 3585)
            {
                projectile.penetrate = 1;
                projectile.friendly = true;
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
                    float num8 = 20f;
                    Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                    float num9 = num2 - vector1.X;
                    float num10 = num3 - vector1.Y;
                    float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                    num11 = num8 / num11;
                    num9 *= num11;
                    num10 *= num11;
                    base.projectile.velocity.X = (base.projectile.velocity.X * 200f + num9) / 201f;
                    base.projectile.velocity.Y = (base.projectile.velocity.Y * 200f + num10) / 201f;
                }
            }
            
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 150));
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
    }
}