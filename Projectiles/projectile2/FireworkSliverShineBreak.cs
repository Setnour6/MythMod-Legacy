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
    public class FireworkSliverShineBreak : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球银闪散裂");
        }
        private int c;
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 105;
            projectile.penetrate = -1;
            projectile.scale = 0.4f;
            this.cooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float z;
        public override void AI()
        {
            if (initialization)
            {
                if (projectile.velocity.Length() >= 1)
                {
                    z = projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                c = Main.rand.Next(140, 280);
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
            if (projectile.timeLeft < 600 && projectile.timeLeft >= 585)
            {
                if (Y < 1)
                {
                    projectile.scale *= (float)Y / (projectile.timeLeft / 585);
                }
                else
                {
                    projectile.scale *= (float)Y * projectile.timeLeft / 585;
                }
            }
            if (projectile.timeLeft < 628 - c / 5 && projectile.timeLeft > 100 + (float)b)
            {
                projectile.scale += (float)Math.Sin((float)(float)(projectile.timeLeft - (float)c) / 11.8 * 3.141526535898f) / 8;
            }
            if (projectile.timeLeft < 580 && projectile.timeLeft >= 100 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 100 + (float)b)
            {
                projectile.scale *= 0.95f;
            }
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 595)
            {
                Vector2 vector = base.projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), (float)projectile.scale * 0.4f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            if (projectile.timeLeft < 480)
            {
                if(Main.rand.Next(130) == 1)
                {
                    int num = Main.rand.Next(3, 7);
                    for(int u = 0; u < num; u++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 45000f;
                        int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) + base.projectile.velocity.X, (float)((float)l * Math.Sin((float)a)) + base.projectile.velocity.Y, base.mod.ProjectileType("FireworkSilverShine"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[num2].scale = projectile.scale * 1.3f;
                    }
                    Main.PlaySound(2, (int)base.projectile.Center.X, (int)base.projectile.Center.Y, 14, 0.6f, 0f);
                    projectile.timeLeft = 0;
                }
            }
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.2f / 255f * projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            if (projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球银light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft - 300) / (1200f * z * z), projectile.scale * (projectile.timeLeft - 300) / (1200f * z * z), projectile.scale * (projectile.timeLeft - 300) / (1200f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (800 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return false;
		}
    }
}