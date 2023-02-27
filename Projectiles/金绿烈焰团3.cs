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
    public class 金绿烈焰团3 : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金绿烈焰团3");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 500;
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
        public override void AI()
        {
            projectile.velocity = projectile.velocity.RotatedBy(Math.PI / -400f);
            if (projectile.timeLeft < 100)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft < 60)
            {
                projectile.hostile = false;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.7176f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.8196f / 255f, (float)(255 - base.projectile.alpha) * 0.1373f / 255f * projectile.scale);
        }
        //14141414141414
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
    }
}