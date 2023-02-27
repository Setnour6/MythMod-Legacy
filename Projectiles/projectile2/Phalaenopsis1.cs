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
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class Phalaenopsis1 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("蝴蝶兰");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 12;
            projectile.height = 12;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 2;
            projectile.timeLeft = 120;
            projectile.alpha = 0;
            projectile.penetrate = 15;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(0,0,0,0));
		}
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            if (initialization)
            {
                X = (float)Math.Sqrt((double)projectile.velocity.X * (double)projectile.velocity.X + (double)projectile.velocity.Y * (double)projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Sin(-(double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            projectile.velocity *= 0.95f;
            if (projectile.timeLeft > 90)
            {
                Vector2 vector = base.projectile.Center - new Vector2(4, 4) + projectile.velocity.RotatedBy(Main.rand.NextFloat(-1.4f,1.4f)) / projectile.velocity.Length() * 10f;
                int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 0.9f * projectile.ai[0]);
                Main.dust[num].velocity = new Vector2(0, 0);
                Main.dust[num].noGravity = true;
            }
            else
            {
                if (projectile.timeLeft > 15)
                {
                    Vector2 vector = base.projectile.Center - new Vector2(4, 4) + projectile.velocity.RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f)) / projectile.velocity.Length() * 10f;
                    int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 0.9f * 90f / (float)projectile.timeLeft * projectile.ai[0]);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity = new Vector2(0, 0);
                }
                else
                {
                    Vector2 vector = base.projectile.Center - new Vector2(4, 4) + (projectile.velocity).RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f)) / projectile.velocity.Length() * 10f;
                    int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 6f * projectile.ai[0]);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity = new Vector2(0, 0);
                }
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1.2f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 1.2f / 255f * projectile.scale);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
    }
}