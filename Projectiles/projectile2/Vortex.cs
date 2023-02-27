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
    public class Vortex : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("漩涡");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
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
            int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
            if (projectile.timeLeft > 300)
            {
                projectile.scale += 0.01f;
            }
            if (projectile.timeLeft <= 395 && projectile.timeLeft > 120)
            {
                Vector2 v = new Vector2(0, 1.5f).RotatedBy(projectile.timeLeft / 9f);
                int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X + projectile.velocity.X, v.Y + projectile.velocity.Y, base.mod.ProjectileType("Vortex2"), (int)(base.projectile.damage * 0.7f), 0, Main.myPlayer, 0f, 0f);
                int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X + projectile.velocity.X, v.Y + projectile.velocity.Y, base.mod.ProjectileType("Vortex2"), (int)(base.projectile.damage * 0.7f), 0, Main.myPlayer, 0f, 0f);
            }
            if (projectile.timeLeft <= 120)
            {
                Vector2 v = new Vector2(0, 1.5f * projectile.timeLeft / 120f).RotatedBy(projectile.timeLeft / 9f);
                int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X + projectile.velocity.X, v.Y + projectile.velocity.Y, base.mod.ProjectileType("Vortex2"), (int)(base.projectile.damage * 0.05f), 0, Main.myPlayer, 0f, 0f);
                Main.projectile[num2].timeLeft = projectile.timeLeft;
                int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X + projectile.velocity.X, v.Y + projectile.velocity.Y, base.mod.ProjectileType("Vortex2"), (int)(base.projectile.damage * 0.05f), 0, Main.myPlayer, 0f, 0f);
                Main.projectile[num3].timeLeft = projectile.timeLeft;
                projectile.scale *= 0.99f;
            }
            if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 1.5f)
            {
                base.projectile.velocity *= 1.05f;
            }
            if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 1.8f)
            {
                base.projectile.velocity *= 0.99f;
            }
            if(num6 >= 50)
            {
                projectile.velocity = projectile.velocity * 0.995f + (Main.player[num5].Center - base.projectile.Center) / num6 * 0.02f;
            }
            if(num6 < 300)
            {
                Main.player[num5].velocity += (projectile.Center - Main.player[num5].Center) * (0.0015f / num6) * (300 - num6);
            }
            if (projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2.25f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 1.00f * projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 0.67f / 255f * projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2.25f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 1.00f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.67f / 255f * projectile.scale * projectile.timeLeft / 120f);
            }
        }
        //14141414141414
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
        {
        }
    }
}