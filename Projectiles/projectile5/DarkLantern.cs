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
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile5
{
    public class DarkLantern : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸灯笼");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 3600;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0.5f));
        }
        private bool initialization = true;
        private bool Boom = false;
        public override void AI()
        {
            if (initialization)
            {
                num1 = Main.rand.Next(-120, 0);
                num2 = (int)Projectile.ai[0] * 4;
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                num5 = Main.rand.NextFloat(2.85f, 3.15f);
                Projectile.timeLeft = Main.rand.Next(3000, 4200);
                num6 = Projectile.timeLeft;
                Projectile.velocity = new Vector2(0, 0.0000006f).RotatedBy(Projectile.ai[1]);
                Fy = Main.rand.Next(4);
                initialization = false;
            }
            if(Projectile.timeLeft > num6 - num2 - 240)
            {
                float Sc = Projectile.velocity.Length() / 10f;
                if (Sc > 1)
                {
                    Sc = 1;
                    Projectile.hostile = true;
                }
                if (Projectile.velocity.Length() > 150)
                {
                    Projectile.Kill();
                }
                for (int g = 0; g < Projectile.velocity.Length() / 4f; g++)
                {
                    int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - Projectile.velocity / Projectile.velocity.Length() * g * 4, 0, 0, Mod.Find<ModDust>("Flame").Type, 0, 0, 0, default(Color), 4f * Sc);
                    Main.dust[r].noGravity = true;
                    if (Main.rand.Next(100) > 60)
                    {
                        int r0 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) + new Vector2(0, Main.rand.NextFloat(0, 36f)).RotatedByRandom(MathHelper.TwoPi) - Projectile.velocity / Projectile.velocity.Length() * g * 4, 0, 0, Mod.Find<ModDust>("Flame3").Type, 0, 0, 0, default(Color), 7f * Sc);
                        Main.dust[r0].noGravity = true;
                    }
                }
            }            
            num1 += 1;
            num2 -= 1;
            num4 += 0.01f;
            if(num2 == 0)
            {
                Projectile.velocity = new Vector2(0, 6).RotatedBy(Projectile.ai[1]);
                Boom = true;
            }
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) - (float)Math.PI * 0.5f;
            /*if (projectile.timeLeft < 995)
            {
                Vector2 vector = base.projectile.Center - new Vector2(4, 4);
                int num = Dust.NewDust(vector, 2, 2, 102, 0f, 0f, 0, default(Color), (float)projectile.scale * 0.8f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }*/
            if(num1 > 0 && num1 <= 120)
            {
                num = num1 / 120f;
            }
            x = num1 / 400f;
            y = (x * x * x - x * x * num5) / 1500f;
            if(y > 0.03f)
            {
                y = 0.03f;
            }
            if(Boom)
            {
                Projectile.velocity.Y += y;
                if(Projectile.scale < num3 * 2 && Projectile.timeLeft > 300)
                {
                    Projectile.scale += 0.005f;
                }
            }
            Projectile.velocity *= 0.99f;
            if(Projectile.velocity.Y > num3 && y > 0)
            {
                Projectile.velocity.Y *= num3 / Projectile.velocity.Y;
            }
            if (Projectile.timeLeft < 300)
            {
                Projectile.scale *= 0.99f;
            }
            //Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0.2f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * num1);
        }
        private float num = 0;
        private int num1 = 0;
        private int num6 = 0;
        private int num2 = -1;
        private float num3 = 0.8f;
        private float num4 = 0;
        private float num5 = 0;
        private float x = 0;
        private float y = 0;
        private int Fy = 0;
        private int fyc = 0;
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int nuM = TextureAssets.Projectile[base.Projectile.type].Value.Height;
            fyc += 1;
            if(fyc == 8)
            {
                fyc = 0;
                Fy += 1;
            }
            if(Fy > 3)
            {
                Fy = 0;
            }
            Color colorT = new Color(1f * num * (float)(Math.Sin(num4) + 2) / 3f, 1f * num * (float)(Math.Sin(num4) + 2) / 3f, 1f * num * (float)(Math.Sin(num4) + 2) / 3f, 0.5f * num * (float)(Math.Sin(num4) + 2) / 3f);
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, nuM)), colorT, base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)nuM / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
            Main.spriteBatch.Draw(Mod.GetTexture("Projectiles/projectile5/LanternFire"), base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 30 * Fy, 20, 30)), colorT, 0, new Vector2(10, 15), base.Projectile.scale * 0.5f, SpriteEffects.None, 1f);
            return false;
		}
    }
}