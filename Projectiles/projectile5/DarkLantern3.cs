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
using MythMod.NPCs.LanternMoon;
namespace MythMod.Projectiles.projectile5
{
    public class DarkLantern3 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("爆炸灯笼");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 3600;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.scale = 1.5f;
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
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                num5 = Main.rand.NextFloat(2.85f, 3.15f);
                Projectile.timeLeft = 5280;
                num6 = Projectile.timeLeft;
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
                Projectile.hostile = true;
            }
            rot += LanternGhostKing.Adc;
            if(Projectile.timeLeft < 240)
            {
                Projectile.scale *= 0.99f;
            }
            Projectile.position =  LanternGhostKing.Cirposi + new Vector2(0,Projectile.ai[1]).RotatedBy(Projectile.ai[0] / 15d * Math.PI + rot);
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