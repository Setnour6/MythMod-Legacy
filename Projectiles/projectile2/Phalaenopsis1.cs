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
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class Phalaenopsis1 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("蝴蝶兰");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 120;
            Projectile.alpha = 0;
            Projectile.penetrate = 15;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
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
                X = (float)Math.Sqrt((double)Projectile.velocity.X * (double)Projectile.velocity.X + (double)Projectile.velocity.Y * (double)Projectile.velocity.Y);
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
            Projectile.velocity *= 0.95f;
            if (Projectile.timeLeft > 90)
            {
                Vector2 vector = base.Projectile.Center - new Vector2(4, 4) + Projectile.velocity.RotatedBy(Main.rand.NextFloat(-1.4f,1.4f)) / Projectile.velocity.Length() * 10f;
                int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 0.9f * Projectile.ai[0]);
                Main.dust[num].velocity = new Vector2(0, 0);
                Main.dust[num].noGravity = true;
            }
            else
            {
                if (Projectile.timeLeft > 15)
                {
                    Vector2 vector = base.Projectile.Center - new Vector2(4, 4) + Projectile.velocity.RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f)) / Projectile.velocity.Length() * 10f;
                    int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 0.9f * 90f / (float)Projectile.timeLeft * Projectile.ai[0]);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity = new Vector2(0, 0);
                }
                else
                {
                    Vector2 vector = base.Projectile.Center - new Vector2(4, 4) + (Projectile.velocity).RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f)) / Projectile.velocity.Length() * 10f;
                    int num = Dust.NewDust(vector, 2, 2, 71, 0f, 0f, 0, default(Color), 6f * Projectile.ai[0]);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity = new Vector2(0, 0);
                }
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1.2f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 1.2f / 255f * Projectile.scale);
        }
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
    }
}