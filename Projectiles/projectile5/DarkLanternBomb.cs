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
namespace MythMod.Projectiles.projectile5
{
    public class DarkLanternBomb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸灯笼");
        }
        public override void SetDefaults()
        {
            projectile.width = 100;
            projectile.height = 100;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 3600;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0.5f));
        }
        private float y = 0;
        private bool initialization = true;
        private bool Boom = false;
        public override void AI()
        {
            if (initialization)
            {
                num1 = -(int)(projectile.ai[0]);
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                x = Main.rand.NextFloat(0.3f, 1800f);
                projectile.timeLeft = (int)(projectile.ai[0]) + 600;
                Fy = Main.rand.Next(4);
                y = 5;
                initialization = false;
            }
            num1 += 1;
            num2 -= 1;
            if(y > 1)
            {
                y -= 0.25f;
            }
            else
            {
                y = 1;
            }
            num4 += 0.01f;
            if (num1 > 0 && num1 <= 120)
            {
                num = num1 / 120f;
            }
            projectile.velocity *= 0f;
            if (projectile.timeLeft < 90)
            {
                projectile.scale += 0.05f;
                num += 0.1f;
            }
            if (projectile.timeLeft < 3)
            {
                projectile.scale += 0.05f;
                projectile.hostile = true;
                num += 0.5f;
            }
            //Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0.2f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * num1);
        }
        private float num = 0;
        private int num1 = 0;
        private int num2 = -1;
        private float num3 = 0.8f;
        private float num4 = 0;
        private float num5 = 0;
        private int Fy = 0;
        private int fyc = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int nuM = Main.projectileTexture[base.projectile.type].Height;
            fyc += 1;
            if (fyc == 8)
            {
                fyc = 0;
                Fy += 1;
            }
            if (Fy > 3)
            {
                Fy = 0;
            }
            Color colorT = new Color(1f * num * (float)(Math.Sin(num4) + 2) / 3f, 1f * num * (float)(Math.Sin(num4) + 2) / 3f, 1f * num * (float)(Math.Sin(num4) + 2) / 3f, 0.5f * num * (float)(Math.Sin(num4) + 2) / 3f);
            x += 0.01f;
            float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.05f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 2f * y, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.mod.GetTexture("UIImages/StarEffect"), base.projectile.Center - Main.screenPosition, null, new Color(1f, 0.05f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 0.8f * y, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/LanternFire"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 30 * Fy, 20, 30)), colorT, 0, new Vector2(10, 15), base.projectile.scale * 0.5f, SpriteEffects.None, 1f);
            for (float k = 0;k < num;k+=0.5f)
            {
                if (k > 0.5)
                {
                    Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, nuM)), new Color(1f,1f,1f,0), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)nuM / 2f), base.projectile.scale, SpriteEffects.None, 1f);
                }
                else
                {
                    Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, nuM)), colorT, base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)nuM / 2f), base.projectile.scale, SpriteEffects.None, 1f);
                }
            }
            return false;
        }
        private float x = 0;
        public override void Kill(int timeLeft)
        {
            MythPlayer mplayer = Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Shake = 15;
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
            /*for (int k = 0; k <= 10; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }*/
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("FireBallWave"), 0, 0, base.projectile.owner, 0f, 0f);
            for (int i = 0; i < 90; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(2.9f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(4f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v;
            }
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, (float)(2.4 * Math.Log10(projectile.damage)))).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y) + v * 45f, base.projectile.width, base.projectile.height, mod.DustType("Flame"), 0f, 0f, 100, Color.White, (float)(12f * Math.Log10(projectile.damage)));
                Main.dust[num5].velocity = v * 0.1f;
                Main.dust[num5].rotation = Main.rand.NextFloat(0, (float)(MathHelper.TwoPi));
            }
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(25f, 80f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 6, v.X, v.Y, 0, Color.White, 1f);
                Main.dust[num5].velocity = v;
            }
        }
    }
}