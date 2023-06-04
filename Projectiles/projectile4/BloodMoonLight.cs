using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile4
{
    public class BloodMoonLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("血月棱镜");
        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;
        private Color c1 = new Color(0f, 0f, 0f, 0f);
        private Color c2 = new Color(0f, 0f, 0f, 0f);
        private Vector2 a0;
        private Vector2 a1;
        private Vector2 a2;
        private Vector2 a3;
        private Vector2 a4;
        private Vector2 a5;
        private Vector2 b0;
        private Vector2 b1;
        private Vector2 b2;
        private Vector2 b3;
        private Vector2 b4;
        private Vector2 b5;


        public override Color? GetAlpha(Color lightColor)
        {
            return c1;
        }
        public override void AI()
        {
            Projectile.localAI[0] += 0.1f;
            /*projectile.velocity *= 1.01f;*/
            Vector4 v1a = new Vector4(0.255f, 0.145f, 0.549f, 0.5f);
            Vector4 v1b = new Vector4(0.467f, 0.384f, 0.686f, 0.5f);
            Vector4 v1 = v1a * (float)(Math.Sin(Projectile.localAI[0]) + 1) * 0.5f + v1b * (float)(Math.Sin(Projectile.localAI[0] + Math.PI) + 1) * 0.5f;
            Vector4 v2a = new Vector4(0.760f, 0f, 0f, 0f);
            Vector4 v2b = new Vector4(0.976f, 0.188f, 0.07f, 0f);
            Vector4 v2 = v2a * (float)(Math.Sin(Projectile.localAI[0] - Math.PI / 2d) + 1) * 0.5f + v2b * (float)(Math.Sin(Projectile.localAI[0] + Math.PI / 2d) + 1) * 0.5f;
            c1 = new Color(v1.X, v1.Y, v1.Z, 0f);
            c2 = new Color(v2.X, v2.Y, v2.Z, 0f);
            float a = 50;
            float b = 70;
            float c = 22;
            float Delta = Projectile.localAI[0] * 2f;
            float x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            float y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a0 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 32f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a1 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 27f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a2 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 46f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a3 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 53f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a4 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 14f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            a5 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 22f;
            x = (float)((a - b) * Math.Cos(Delta) + c * Math.Cos((a / b - 1) * Delta));
            y = (float)((a - b) * Math.Sin(Delta) - c * Math.Sin((a / b - 1) * Delta));
            b0 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 29f;
            x = (float)((a - b) * Math.Cos(- Delta) + c * Math.Cos((a / b - 1) * - Delta));
            y = (float)((a - b) * Math.Sin(- Delta) - c * Math.Sin((a / b - 1) * - Delta));
            b1 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 11f;
            x = (float)((a - b) * Math.Cos(- Delta) + c * Math.Cos((a / b - 1) * - Delta));
            y = (float)((a - b) * Math.Sin(- Delta) - c * Math.Sin((a / b - 1) * - Delta));
            b2 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 93f;
            x = (float)((a - b) * Math.Cos(- Delta) + c * Math.Cos((a / b - 1) * - Delta));
            y = (float)((a - b) * Math.Sin(- Delta) - c * Math.Sin((a / b - 1) * - Delta));
            b3 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 68f;
            x = (float)((a - b) * Math.Cos(- Delta) + c * Math.Cos((a / b - 1) * - Delta));
            y = (float)((a - b) * Math.Sin(- Delta) - c * Math.Sin((a / b - 1) * - Delta));
            b4 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Delta += 57f;
            x = (float)((a - b) * Math.Cos(- Delta) + c * Math.Cos((a / b - 1) * - Delta));
            y = (float)((a - b) * Math.Sin(- Delta) - c * Math.Sin((a / b - 1) * - Delta));
            b5 = Projectile.Center - Projectile.velocity * 8f + new Vector2(x, y);
            Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            Vector2 vector = base.Projectile.Center - new Vector2(4, 4);
        }
        public override void Kill(int timeLeft)
        {
            for (int a = 0; a < 25; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3.7f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("CrystalBlue").Type, v.X, v.Y, 0, default(Color), 1f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.15f, 0.05f) * 0.1f;
            }
            for (int a = 0; a < 25; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(3.7f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("CrystalCrism").Type, v.X, v.Y, 0, default(Color), 1f);
                Main.dust[num].noGravity = false;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.15f, 0.05f) * 0.1f;
            }
            base.Kill(timeLeft);
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            Vector2 A0 = a0 - Projectile.Center;
            for (int i = 0;i < A0.Length();i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A0 / A0.Length() * i, null, c2 * ((A0.Length() - i) / A0.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if(i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A0 / A0.Length() * i, null, c2 * ((A0.Length() - i) / A0.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 A1 = a1 - Projectile.Center;
            for (int i = 0; i < A1.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A1 / A1.Length() * i, null, c2 * ((A1.Length() - i) / A1.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A1 / A1.Length() * i, null, c2 * ((A1.Length() - i) / A1.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 A2 = a2 - Projectile.Center;
            for (int i = 0; i < A2.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A2 / A2.Length() * i, null, c2 * ((A2.Length() - i) / A2.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A2 / A2.Length() * i, null, c2 * ((A2.Length() - i) / A2.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 A3 = a3 - Projectile.Center;
            for (int i = 0; i < A3.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A3 / A3.Length() * i, null, c2 * ((A3.Length() - i) / A3.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A3 / A3.Length() * i, null, c2 * ((A3.Length() - i) / A3.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 A4 = a4 - Projectile.Center;
            for (int i = 0; i < A4.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A4 / A4.Length() * i, null, c2 * ((A4.Length() - i) / A4.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A4 / A4.Length() * i, null, c2 * ((A4.Length() - i) / A4.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 A5 = a5 - Projectile.Center;
            for (int i = 0; i < A5.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A5 / A5.Length() * i, null, c2 * ((A5.Length() - i) / A5.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + A5 / A5.Length() * i, null, c2 * ((A5.Length() - i) / A5.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B0 = b0 - Projectile.Center;
            for (int i = 0; i < B0.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B0 / B0.Length() * i, null, c1 * ((B0.Length() - i) / B0.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B0 / B0.Length() * i, null, c1 * ((B0.Length() - i) / B0.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B1 = b1 - Projectile.Center;
            for (int i = 0; i < B1.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B1 / B1.Length() * i, null, c1 * ((B1.Length() - i) / B1.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B1 / B1.Length() * i, null, c1 * ((B1.Length() - i) / B1.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B2 = b2 - Projectile.Center;
            for (int i = 0; i < B2.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B2 / B2.Length() * i, null, c1 * ((B2.Length() - i) / B2.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B2 / B2.Length() * i, null, c1 * ((B2.Length() - i) / B2.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B3 = b3 - Projectile.Center;
            for (int i = 0; i < B3.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B3 / B3.Length() * i, null, c1 * ((B3.Length() - i) / B3.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B3 / B3.Length() * i, null, c1 * ((B3.Length() - i) / B3.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B4 = b4 - Projectile.Center;
            for (int i = 0; i < B4.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B4 / B4.Length() * i, null, c1 * ((B4.Length() - i) / B4.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B4 / B4.Length() * i, null, c1 * ((B4.Length() - i) / B4.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            Vector2 B5 = b5 - Projectile.Center;
            for (int i = 0; i < B5.Length(); i++)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B5 / B5.Length() * i, null, c1 * ((B5.Length() - i) / B5.Length()), base.Projectile.rotation, new Vector2(2f, 2f), 1f, SpriteEffects.None, 0f);
                if (i < 64 && i % 2 == 0)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile4/BloodMoonLightDust"), base.Projectile.Center - Main.screenPosition + B5 / B5.Length() * i, null, c1 * ((B5.Length() - i) / B5.Length()) * ((64 - i) / 64f), base.Projectile.rotation, new Vector2(2f, 2f), 1f + (64 - i) / 64f, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
    }
}