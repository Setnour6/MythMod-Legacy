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
    public class MoonPlus : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("赤月");
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
            base.projectile.velocity.X *= 0.98f;
            base.projectile.velocity.Y *= 0.98f;
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
                        NPC target = Main.npc[j];
                        if (Main.rand.Next(3) == 1)
                        {
                            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
                            for (int k = 0; k <= 10; k++)
                            {
                                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                                float m = (float)Main.rand.Next(0, 50000);
                                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                                int num48 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                                Main.projectile[num48].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
                            }
                            for (int k = 0; k <= 10; k++)
                            {
                                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                                int num48 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("爆炸效果光"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                                if (projectile.damage > 300)
                                {
                                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("火球冲击波"), 0, 0, base.projectile.owner, 0f, 0f);
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
            if(Main.rand.Next(3) == 1)
            {
                Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
                for (int k = 0; k <= 10; k++)
                {
                    float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                    float m = (float)Main.rand.Next(0, 50000);
                    float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                    int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
                }
                for (int k = 0; k <= 10; k++)
                {
                    Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("爆炸效果光"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    if (projectile.damage > 300)
                    {
                        Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("火球冲击波"), 0, 0, base.projectile.owner, 0f, 0f);
                    }
                }
                projectile.Kill();
            }
            target.AddBuff(24, 600);
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