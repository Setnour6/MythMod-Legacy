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
    public class floatLantern : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("漂浮灯笼");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 3600;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 2f;
            this.cooldownSlot = 1;
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
                num2 = (int)projectile.ai[0] * 4;
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                num5 = Main.rand.NextFloat(2.85f, 3.15f);
                projectile.timeLeft = Main.rand.Next(600, 900);
                Fy = Main.rand.Next(4);
                initialization = false;
            }
            num1 += 1;
            num2 -= 1;
            num4 += 0.01f;
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
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
            if(projectile.timeLeft < 120)
            {
                num = projectile.timeLeft / 120f;
            }
            projectile.velocity *= 0.99f;
            projectile.velocity.Y += 0.05f;
            if(projectile.velocity.Y >= 1.5f)
            {
                projectile.velocity.Y = 1.5f;
            }
            //Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0.2f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * num1);
        }
        private float num = 0;
        private int num1 = 0;
        private int num2 = -1;
        private float num3 = 0.8f;
        private float num4 = 0;
        private float num5 = 0;
        private float x = 0;
        private float y = 0;
        private int Fy = 0;
        private int fyc = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int nuM = Main.projectileTexture[base.projectile.type].Height;
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
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, nuM)), colorT, base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)nuM / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/LanternFire"), base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 30 * Fy, 20, 30)), colorT, 0, new Vector2(10, 15), base.projectile.scale * 0.5f, SpriteEffects.None, 1f);
            return false;
		}
    }
}