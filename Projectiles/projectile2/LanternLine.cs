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
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    public class LanternLine : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("灯笼须");
        }
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = (int)1.5f;
            projectile.timeLeft = 450;
            projectile.alpha = 0;
            projectile.penetrate = 2;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 300;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        public override void AI()
        {
            projectile.rotation = (float)
            System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            NPC target = null;
            if (projectile.timeLeft < 456 && projectile.timeLeft > 80)
            {
                if(Main.rand.Next(0,5) >= 1)
                {
                    if (Main.rand.Next(0, 2) >= 1)
                    {
                        Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 0, 0, 183, 0f, 0f, 0, default(Color), 2.5f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, 262, 0f, 0f, 200, Color.Yellow, 0.7f);
                        Main.dust[num13].velocity *= 0.0f;
                        Main.dust[num13].noGravity = true;
                    }
                    else
                    {
                        Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.5f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, mod.DustType("GoldGlitter"), 0f, 0f, 200, Color.Yellow, 1f);
                        Main.dust[num13].velocity *= 0.0f;
                        Main.dust[num13].noGravity = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(0, 2) >= 1)
                    {
                        Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 0, 0, 183, 0f, 0f, 0, default(Color), 2.7f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, 262, 0f, 0f, 200, Color.Yellow, 0.8f);
                        Main.dust[num13].velocity *= 0.0f;
                        Main.dust[num13].noGravity = true;
                    }
                    else
                    {
                        Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.7f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, mod.DustType("GoldGlitter"), 0f, 0f, 200, Color.Yellow, 1.2f);
                        Main.dust[num13].velocity *= 0.0f;
                        Main.dust[num13].noGravity = true;
                    }
                }
            }
            else
            {
                if(Main.rand.Next(0,5) >= 1)
                {
                }
                else
                {
                    Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
                    int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.5f * projectile.timeLeft / 80f);
                    Main.dust[num12].velocity *= 0.0f;
                    Main.dust[num12].noGravity = true;
                    int num13 =Dust.NewDust(vector, 3, 3,  mod.DustType("GoldGlitter"), 0f, 0f, 200, Color.Yellow, 1f * projectile.timeLeft / 80f);
                    Main.dust[num13].velocity *= 0.0f;
                    Main.dust[num13].noGravity = true;
                }
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
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag && projectile.timeLeft % 60 > 40)
			{
				float num8 = 20f;
				Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
			}
            if (projectile.timeLeft < 120)
			{
                projectile.tileCollide = true;
            }
            if (!flag)
			{
                projectile.velocity.Y += 0.0075f;
            }
            if(projectile.velocity.Length() > 3f)
            {
                projectile.velocity *= 0.95f;
            }
            else
            {
                projectile.velocity *= 1.03f;
            }
        }
    }
}