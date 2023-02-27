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
namespace MythMod.Projectiles.projectile3
{
    //135596
    public class Infinite : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ÕýÎÞÇî");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 38;
            projectile.height = 24;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.scale = 0;
            this.cooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(150, 150, 150, 0) * (0.7f + (float)Math.Sin(projectile.timeLeft / 7f) / 2f));
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                projectile.rotation += Main.rand.NextFloat(-0.105f, 0.105f);
                projectile.velocity.Y = -5f;
                initialization = false;
            }
            if(projectile.scale < 0.5 && projectile.timeLeft > 25)
            {
                projectile.scale += 0.04f;
            }
            if(projectile.timeLeft <= 25)
            {
                projectile.scale -= 0.02f;
            }
            projectile.velocity.Y *= 0.96f;
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