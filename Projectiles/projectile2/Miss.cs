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
    public class Miss : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Miss");
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 325;
            Projectile.height = 155;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 400;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.scale = 0;
            this.CooldownSlot = 1;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(150, 150, 150, 0) * (0.7f + (float)Math.Sin(Projectile.timeLeft / 7f) / 2f));
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                Projectile.rotation += Main.rand.NextFloat(-0.105f, 0.105f);
                Projectile.velocity.Y = -5f;
                initialization = false;
            }
            if(Projectile.scale < 0.2 && Projectile.timeLeft > 25)
            {
                Projectile.scale += 0.02f;
            }
            if(Projectile.timeLeft <= 25 && Projectile.scale >= 0.02f)
            {
                Projectile.scale -= 0.02f;
            }
            Projectile.velocity.Y *= 0.96f;
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