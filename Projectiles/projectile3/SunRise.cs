using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile3
{
    public class SunRise : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("海日");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.Projectile.width = 15;
            base.Projectile.height = 15;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            Projectile.tileCollide = false;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = false;
            base.Projectile.penetrate = -1;
            Projectile.alpha = 255;
            base.Projectile.extraUpdates = 2;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            if(Projectile.alpha > 5)
            {
                Projectile.alpha -= 5;
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
                    if (num7 < 50)
                    {
                        Main.npc[j].StrikeNPC((int)(Projectile.damage * Main.rand.NextFloat(0.85f,1.15f)), Projectile.knockBack, Projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        Projectile.penetrate--;
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 480f + num9) / 481f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 480f + num10) / 481f;
                Projectile.velocity *= 0.99f;
                if(Projectile.velocity.Length() > 4)
                {
                    Projectile.velocity *= 0.95f;
                }
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.6f / 255f, (float)(255 - base.Projectile.alpha) * 0.1f / 255f, (float)(255 - base.Projectile.alpha) * 0.0f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            int k = Projectile.NewProjectile(Projectile.position.X, Projectile.position.Y, 0, 0, 612, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
            for (int i = 0; i < 200; i++)
            {
                if ((Main.npc[i].Center - Projectile.position).Length() < Main.npc[i].Hitbox.Width / 2f + 10)
                {
                    Main.npc[i].StrikeNPC((int)(Projectile.damage / 6f), 0, 1);
                }
            }
            Main.projectile[k].timeLeft = 30;
            target.AddBuff(189, 900, false);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, base.Projectile.GetAlpha(drawColor), Projectile.rotation, new Vector2(15, 15), Projectile.scale, SpriteEffects.None, 0f);
            if (Projectile.timeLeft > 590)
            {
                float k = (600 - Projectile.timeLeft) / 10f;
                for (int i = 0; i < 60; i++)
                {
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/SunLight"), Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle((int)(384 + Math.Sin(Main.time / 100d) * 234), (int)(384 + Math.Cos(Main.time / 100d) * 234), 150, 150), new Color(k - k / 20f * (float)i, 0f - 0f / 20f * (float)i, 0 - 0 / 20f * (float)i, (0.2f - 0.2f / 20f * (float)i)), Projectile.rotation + (float)Main.time / 50f + i / 12f, new Vector2(75, 75), (0.6f + i / 120f), SpriteEffects.None, 0f);
                }
            }
            if (Projectile.timeLeft <= 590 && Projectile.timeLeft > 550)
            {
                for (int i = 0; i < 60; i++)
                {
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/SunLight"), Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle((int)(384 + Math.Sin(Main.time / 100d) * 234), (int)(384 + Math.Cos(Main.time / 100d) * 234), 150, 150), new Color(1 - 1 / 20f * (float)i, 0f - 0f / 20f * (float)i, 0 - 0 / 20f * (float)i, (0.2f - 0.2f / 20f * (float)i)), Projectile.rotation + (float)Main.time / 50f + i / 12f, new Vector2(75, 75), (0.6f + i / 120f), SpriteEffects.None, 0f);
                }
            }
            if (Projectile.timeLeft <= 550 && Projectile.timeLeft > 100)
            {
                float k = 0.3f - (Projectile.timeLeft - 100) / 1500f;
                for (int i = 0; i < 60; i++)
                {
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/SunLight"), Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle((int)(384 + Math.Sin(Main.time / 100d) * 234), (int)(384 + Math.Cos(Main.time / 100d) * 234), 150, 150), new Color(1 - 1 / 20f * (float)i, k - k / 20f * (float)i, 0 - 0 / 20f * (float)i, (0.2f - 0.2f / 20f * (float)i)), Projectile.rotation + (float)Main.time / 50f + i / 12f, new Vector2(75, 75), (0.6f + i / 120f), SpriteEffects.None, 0f);
                }
            }
            if (Projectile.timeLeft <= 100 && Projectile.timeLeft > 50)
            {
                float k = 1f - (Projectile.timeLeft - 50) / 50f;
                float l = 1f - (Projectile.timeLeft - 50) / 50f * 0.7f;
                for (int i = 0; i < 60; i++)
                {
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/SunLight"), Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle((int)(384 + Math.Sin(Main.time / 100d) * 234), (int)(384 + Math.Cos(Main.time / 100d) * 234), 150, 150), new Color(1 - 1 / 20f * (float)i, l - l / 20f * (float)i, k * 0.6f - k * 0.6f / 20f * (float)i, (0.2f - 0.2f / 20f * (float)i)), Projectile.rotation + (float)Main.time / 50f + i / 12f, new Vector2(75, 75), (0.6f + i / 120f), SpriteEffects.None, 0f);
                }
            }
            if (Projectile.timeLeft <= 50)
            {
                float k = Projectile.timeLeft / 50f;
                for (int i = 0; i < 60; i++)
                {
                    Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/SunLight"), Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle((int)(384 + Math.Sin(Main.time / 100d) * 234), (int)(384 + Math.Cos(Main.time / 100d) * 234), 150, 150), new Color(k - k / 20f * (float)i, k - k / 20f * (float)i, k * 0.6f - k * 0.6f / 20f * (float)i, (0.2f - 0.2f / 20f * (float)i)), Projectile.rotation + (float)Main.time / 50f + i / 12f, new Vector2(75, 75), (0.6f + i / 120f), SpriteEffects.None, 0f);
                }
            }
            return false;
        }
    }
}
