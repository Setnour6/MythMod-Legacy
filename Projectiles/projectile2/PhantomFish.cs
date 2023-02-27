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
            DisplayName.SetDefault("幻鱼");
            Main.projFrames[base.projectile.type] = 8;
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 52;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 400;
            projectile.hostile = true;
            projectile.penetrate = 1;
            projectile.scale = 1f;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
		{
            if(projectile.timeLeft > 60)
            {
                if(projectile.timeLeft > 370)
                {
                    return new Color?(new Color((400 - projectile.timeLeft) / 30f, (400 - projectile.timeLeft) / 30f, (400 - projectile.timeLeft) / 30f, 0));
                }
                else
                {
                    return new Color?(new Color(255, 255, 255, 0));
                }
            }
            else
            {
                return new Color?(new Color(1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 0));
            }
        }
        private bool initialization = true;
        private float b;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + (float)Math.PI * 1.5f;
            if (projectile.timeLeft > 200)
            {
                projectile.velocity = projectile.velocity.RotatedBy(projectile.ai[0] / 40f * (projectile.timeLeft - 200) / 200f);
            }
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 8)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 7)
            {
                base.projectile.frame = 0;
            }
            if (projectile.timeLeft > 120)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.23f * projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 2.55f / 255f * projectile.scale);
            }
            else
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.23f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 2.55f / 255f * projectile.scale * projectile.timeLeft / 120f);
            }
        }
        //14141414141414
        public override void Kill(int timeLeft)
        {
        }
    }
}