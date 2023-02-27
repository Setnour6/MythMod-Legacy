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
namespace MythMod.Projectiles
{
    //135596
    public class 金绿烈焰团 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金绿烈焰团");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 42;
            projectile.height = 42;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 120;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            int num = (int)Player.FindClosest(base.projectile.Center, 8, 8);
			base.projectile.ai[1] += 1f;
			if (base.projectile.ai[1] < 220f && base.projectile.ai[1] > 20f)
			{
				float num2 = base.projectile.velocity.Length();
				Vector2 vector = Main.player[num].Center - base.projectile.Center;
				vector.Normalize();
				vector *= num2;
				base.projectile.velocity = (base.projectile.velocity * 24f + vector) / 25f;
				base.projectile.velocity.Normalize();
				base.projectile.velocity *= num2;
			}
            projectile.scale += (float)(Math.Sin((double)projectile.timeLeft / 120 * 3.14159265359f) * 0.004);
            if (initialization)
            {
                b = Main.rand.Next(-10, 10);
            }
            if (projectile.timeLeft < 100+ (float)b)
            {
                projectile.scale *= 0.99f;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.7176f / 2550f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.8196f / 2550f, (float)(255 - base.projectile.alpha) * 0.1373f / 2550f * projectile.scale);
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
		    Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
            for (int k = 0; k < 30; k++)
            {
                float i = k + 0.5f;
                if((int)k % 2 == 1)
                {
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("金绿烈焰团2"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                }
                else
                {
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos((2 * (float)i / 30) * 3.14159265358979f) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin((2 * (float)i / 30) * 3.14159265358979f) * 7) / 3 * 1.44f, base.mod.ProjectileType("金绿烈焰团3"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                }
            }
        }
    }
}