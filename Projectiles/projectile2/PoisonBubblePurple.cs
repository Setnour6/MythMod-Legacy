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
    public class PoisonBubblePurple : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("剧毒气泡");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 120;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.scale = 0f;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(1 * Projectile.timeLeft / 120f, 1 * Projectile.timeLeft / 120f, 1 * Projectile.timeLeft / 120f, 0));
		}
        private bool initialization = true;
        private float b = 0;
        public override void AI()
        {
            if(initialization)
            {
                b = Main.rand.Next(200,500) / 10000f;
            }
            if (Projectile.timeLeft >= 120)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2.20f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0f * Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 2.55f / 255f * Projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 2.20f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 2.55f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            }
            if (Projectile.timeLeft >= 100)
            {
                Projectile.scale += b;
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