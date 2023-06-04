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
    public class PhantomFish : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("幻鱼");
            Main.projFrames[base.Projectile.type] = 8;
        }
        //7359668
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 52;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 400;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
            if(Projectile.timeLeft > 60)
            {
                if(Projectile.timeLeft > 370)
                {
                    return new Color?(new Color((400 - Projectile.timeLeft) / 30f, (400 - Projectile.timeLeft) / 30f, (400 - Projectile.timeLeft) / 30f, 0));
                }
                else
                {
                    return new Color?(new Color(255, 255, 255, 0));
                }
            }
            else
            {
                return new Color?(new Color(1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 0));
            }
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + (float)Math.PI * 1.5f;
            if (Projectile.timeLeft > 200)
            {
                Projectile.velocity = Projectile.velocity.RotatedBy(Projectile.ai[0] / 40f * (Projectile.timeLeft - 200) / 200f);
            }
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 8)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 7)
            {
                base.Projectile.frame = 0;
            }
            if (Projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.23f * Projectile.scale / 255f, (float)(255 - base.Projectile.alpha) * 2.55f / 255f * Projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 0.23f * Projectile.scale / 255f * Projectile.timeLeft / 120f, (float)(255 - base.Projectile.alpha) * 2.55f / 255f * Projectile.scale * Projectile.timeLeft / 120f);
            }
        }
        //14141414141414
        public override void Kill(int timeLeft)
        {
        }
    }
}