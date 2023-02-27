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
    public class GoldLantern : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金灯笼");
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
            Projectile.timeLeft = 600;
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
        private float Sca = 0;
        public override void AI()
        {
            if (initialization)
            {
                num1 = Main.rand.Next(-120, 0);
                num2 = (int)Projectile.ai[0] * 4;
                num3 = Main.rand.NextFloat(0.3f, 1.8f);
                num4 = Main.rand.NextFloat(0.3f, 1800f);
                num5 = Main.rand.NextFloat(2.85f, 3.15f);
                Fy = Main.rand.Next(4);
                initialization = false;
            }
            num1 += 1;
            num2 -= 1;
            num4 += 0.01f;
            if(Projectile.timeLeft > 510)
            {
                Projectile.velocity *= 0.8f;
                Projectile.velocity = Projectile.velocity.RotatedBy(1 / 105d * Math.PI);
                Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) - (float)Math.PI * 0.5f;
                Sca += 0.01111111f;
            }
            else
            {
                Projectile.velocity *= 0;
                if (Projectile.timeLeft == 510)
                {
                    Vector2 v1 = new Vector2(0, -36).RotatedBy(Projectile.rotation + 1);
                    Vector2 v2 = new Vector2(0, -36).RotatedBy(Projectile.rotation - 1);
                    Projectile.NewProjectile(Projectile.Center.X + v1.X + 20, Projectile.Center.Y + v1.Y + 20, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("GoldLanternRay").Type, 0, 0, Main.myPlayer, Projectile.rotation + 1, Projectile.rotation);
                    Projectile.NewProjectile(Projectile.Center.X + v2.X + 20, Projectile.Center.Y + v2.Y + 20, Projectile.velocity.X, Projectile.velocity.Y, Mod.Find<ModProjectile>("GoldLanternRay").Type, 0, 0, Main.myPlayer, Projectile.rotation - 1, Projectile.rotation);
                }
            }
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
            if(Projectile.timeLeft < 120)
            {
                num = Projectile.timeLeft / 120f;
                Sca -= 0.01f;
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
            x += 0.01f;
            float K = (float)(Math.Sin(x + Math.Sin(x) * 6) * (0.95 + Math.Sin(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            float M = (float)(Math.Sin(x + Math.Tan(x) * 6) * (0.95 + Math.Cos(x + 0.24 + Math.Sin(x))) + 3) / 30f;
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, 0, new Vector2(512f, 512f), K * 2.8f , SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.8f, 0f, 0) * 0.4f, (float)(Math.PI * 0.5), new Vector2(512f, 512f), K * 2.8f * Sca, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.75), new Vector2(512f, 512f), M * 2.8f * Sca, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(1f, 0.6f, 0f, 0) * 0.4f, (float)(Math.PI * 0.25), new Vector2(512f, 512f), M * 2.8f * Sca, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, x * 6f, new Vector2(512f, 512f), (M + K) * 2.8f * Sca, SpriteEffects.None, 0f);
            spriteBatch.Draw(base.Mod.GetTexture("UIImages/StarEffect"), base.Projectile.Center - Main.screenPosition, null, new Color(0.8f, 0.4f, 0f, 0) * 0.4f, -x * 6f, new Vector2(512f, 512f), (float)Math.Sqrt(M * M + K * K) * 2.8f * Sca, SpriteEffects.None, 0f);
            return false;
		}
    }
}