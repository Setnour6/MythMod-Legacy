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
    public class Vortex : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("漩涡");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 400;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, 0));
		}
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
            if (Projectile.timeLeft > 300)
            {
                Projectile.scale += 0.01f;
            }
            if (Projectile.timeLeft <= 395 && Projectile.timeLeft > 120)
            {
                Vector2 v = new Vector2(0, 1.5f).RotatedBy(Projectile.timeLeft / 9f);
                int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X + Projectile.velocity.X, v.Y + Projectile.velocity.Y, base.Mod.Find<ModProjectile>("Vortex2").Type, (int)(base.Projectile.damage * 0.7f), 0, Main.myPlayer, 0f, 0f);
                int num3 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X + Projectile.velocity.X, v.Y + Projectile.velocity.Y, base.Mod.Find<ModProjectile>("Vortex2").Type, (int)(base.Projectile.damage * 0.7f), 0, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.timeLeft <= 120)
            {
                Vector2 v = new Vector2(0, 1.5f * Projectile.timeLeft / 120f).RotatedBy(Projectile.timeLeft / 9f);
                int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X + Projectile.velocity.X, v.Y + Projectile.velocity.Y, base.Mod.Find<ModProjectile>("Vortex2").Type, (int)(base.Projectile.damage * 0.05f), 0, Main.myPlayer, 0f, 0f);
                Main.projectile[num2].timeLeft = Projectile.timeLeft;
                int num3 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X + Projectile.velocity.X, v.Y + Projectile.velocity.Y, base.Mod.Find<ModProjectile>("Vortex2").Type, (int)(base.Projectile.damage * 0.05f), 0, Main.myPlayer, 0f, 0f);
                Main.projectile[num3].timeLeft = Projectile.timeLeft;
                Projectile.scale *= 0.99f;
            }
            if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 1.5f)
            {
                base.Projectile.velocity *= 1.05f;
            }
            if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 1.8f)
            {
                base.Projectile.velocity *= 0.99f;
            }
            if(num6 >= 50)
            {
                Projectile.velocity = Projectile.velocity * 0.995f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 0.02f;
            }
            if(num6 < 300)
            {
                Main.player[num5].velocity += (Projectile.Center - Main.player[num5].Center) * (0.0015f / num6) * (300 - num6);
            }
            if (Projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2.25f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 1.00f * Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 0.67f / 255f * Projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2.25f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 1.00f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.67f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            }
        }
        //14141414141414
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
        {
        }
    }
}