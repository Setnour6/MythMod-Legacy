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
    public class FreezeKnife : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("风霜");
        }
		public override void SetDefaults()
		{
            base.projectile.width = 80;
            base.projectile.height = 80;
            base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 8;
			base.projectile.timeLeft = 720;
            base.projectile.localNPCHitCooldown = 0;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 55;
		}
        private float Omega = 0.8f;
        public override void AI()
        {
            base.projectile.alpha = (int)(55 + (float)(400 - (float)projectile.timeLeft) / 2);
            base.projectile.rotation += Omega;
            Omega *= 0.994f;
            base.projectile.velocity.X *= 0.96f;
            base.projectile.velocity.Y *= 0.96f;
            Lighting.AddLight(base.projectile.Center, (float)projectile.timeLeft / 1200f * 12 / 255f, (float)projectile.timeLeft / 1200f * 133 / 255f, (float)projectile.timeLeft / 1200f * 158 / 255f);
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
                        NPC target = Main.npc[j];
                        target.AddBuff(47, 300);
                        target.AddBuff(46, 300);
                        if (Main.rand.Next(3) == 1)
                        {
                            if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
                            {
                                target.AddBuff(mod.BuffType("Freeze"), 200);
                                target.AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                            }
                            if (target.type == 113)
                            {
                                for (int i = 0; i < 200; i++)
                                {
                                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                                    {
                                        Main.npc[i].AddBuff(mod.BuffType("Freeze"), 200);
                                        Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                                    }
                                }
                            }
                            if (target.type == 114)
                            {
                                for (int i = 0; i < 200; i++)
                                {
                                    if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                                    {
                                        Main.npc[i].AddBuff(mod.BuffType("Freeze"), 200);
                                        Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                                    }
                                }
                            }
                            projectile.Kill();
                        }
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
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft > 3)
            {
                Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
                for (int i = 0; i < 30; i++)
                {
                    int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 88, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num].scale = 0.5f;
                        Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int k = 0; k <= 20; k++)
                {
                    float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                    float m = (float)Main.rand.Next(0, 50000);
                    float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                    int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.06f, (float)((float)l * Math.Sin((float)a)) * 0.06f, base.mod.ProjectileType("FreezeBallBrake"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, projectile.ai[1] / 2f);
                    Main.projectile[num4].timeLeft = (int)(projectile.damage * Main.rand.NextFloat(0.02f, 0.07f));
                }
            }
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(47, 300);
            target.AddBuff(46, 300);
            if(Main.rand.Next(3) == 1)
            {
                if (target.type != 396 && target.type != 397 && target.type != 398 && target.type != mod.NPCType("AncientTangerineTreeEye"))
                {
                    target.AddBuff(mod.BuffType("Freeze"), 200);
                    target.AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                }
                if (target.type == 113)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 200);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                        }
                    }
                }
                if (target.type == 114)
                {
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].type == 113 || Main.npc[i].type == 114)
                        {
                            Main.npc[i].AddBuff(mod.BuffType("Freeze"), 200);
                            Main.npc[i].AddBuff(mod.BuffType("Freeze2"), 200 + 2);
                        }
                    }
                }
                projectile.Kill();
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
                    Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY) - projectile.velocity * i / im, null, new Color(i / im * (float)Math.Log(Omega * 4 + 1), i / im * (float)Math.Log(Omega * 4 + 1), i / im * (float)Math.Log(Omega * 4 + 1), i / im * projectile.alpha / 255f * (float)Math.Log(Omega * 4 + 1)), projectile.rotation + Omega * i * 0.4f, new Vector2(38, 34), projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}