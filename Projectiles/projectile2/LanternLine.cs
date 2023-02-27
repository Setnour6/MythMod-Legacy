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
            Projectile.width = 6;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = (int)1.5f;
            Projectile.timeLeft = 450;
            Projectile.alpha = 0;
            Projectile.penetrate = 2;
            Projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 300;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
        public override void AI()
        {
            Projectile.rotation = (float)
            System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
            NPC target = null;
            if (Projectile.timeLeft < 456 && Projectile.timeLeft > 80)
            {
                if(Main.rand.Next(0,5) >= 1)
                {
                    if (Main.rand.Next(0, 2) >= 1)
                    {
                        Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
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
                        Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.5f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, Mod.Find<ModDust>("GoldGlitter").Type, 0f, 0f, 200, Color.Yellow, 1f);
                        Main.dust[num13].velocity *= 0.0f;
                        Main.dust[num13].noGravity = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(0, 2) >= 1)
                    {
                        Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
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
                        Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
                        int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.7f);
                        Main.dust[num12].velocity *= 0.0f;
                        Main.dust[num12].noGravity = true;
                        Main.dust[num12].scale = (float)Main.rand.Next(90, 110) * 0.014f;
                        int num13 = Dust.NewDust(vector, 3, 3, Mod.Find<ModDust>("GoldGlitter").Type, 0f, 0f, 200, Color.Yellow, 1.2f);
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
                    Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
                    int num12 = Dust.NewDust(vector, 3, 3, 183, 0f, 0f, 0, default(Color), 2.5f * Projectile.timeLeft / 80f);
                    Main.dust[num12].velocity *= 0.0f;
                    Main.dust[num12].noGravity = true;
                    int num13 =Dust.NewDust(vector, 3, 3,  Mod.Find<ModDust>("GoldGlitter").Type, 0f, 0f, 200, Color.Yellow, 1f * Projectile.timeLeft / 80f);
                    Main.dust[num13].velocity *= 0.0f;
                    Main.dust[num13].noGravity = true;
                }
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
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag && Projectile.timeLeft % 60 > 40)
			{
				float num8 = 20f;
				Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num9) / 21f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num10) / 21f;
			}
            if (Projectile.timeLeft < 120)
			{
                Projectile.tileCollide = true;
            }
            if (!flag)
			{
                Projectile.velocity.Y += 0.0075f;
            }
            if(Projectile.velocity.Length() > 3f)
            {
                Projectile.velocity *= 0.95f;
            }
            else
            {
                Projectile.velocity *= 1.03f;
            }
        }
    }
}