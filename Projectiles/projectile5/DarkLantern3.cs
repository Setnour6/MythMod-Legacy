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
using MythMod.NPCs.LanternMoon;
namespace MythMod.Projectiles.projectile5
{
    public class DarkLantern3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸灯笼");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 3600;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1.5f;
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
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                num5 = Main.rand.NextFloat(2.85f, 3.15f);
                projectile.timeLeft = 5280;
                num6 = projectile.timeLeft;
                Fy = Main.rand.Next(4);
                initialization = false;
            }
            num1 += 1;
            num2 -= 1;
            num4 += 0.01f;
            if (num1 > 0 && num1 <= 120)
            {
                num = num1 / 120f;
            }
            if(num1 >= 1)
            {
                projectile.hostile = true;
            }
            rot += LanternGhostKing.Adc;
            if(projectile.timeLeft < 240)
            {
                projectile.scale *= 0.99f;
            }
            projectile.position =  LanternGhostKing.Cirposi + new Vector2(0,projectile.ai[1]).RotatedBy(projectile.ai[0] / 15d * Math.PI + rot);
            //Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0.2f / 255f * projectile.scale * num1, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * num1);
        }
        private float rot = 0;
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