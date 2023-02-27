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
namespace MythMod.Projectiles.projectile5.Sweats
{
    public class AppleProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("苹果糖");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 1000;
            Projectile.alpha = 0;
            Projectile.penetrate = 200;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (Projectile.timeLeft < 995)
            {
            }
            if(Projectile.penetrate < 196)
            {
                Projectile.alpha += 1;
            }
            if(Projectile.velocity.Y < 15)
            {
                Projectile.velocity.Y += 0.01f;
            }
            Lighting.AddLight(Projectile.Center, -1, -1, -1);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f * (255 - Projectile.alpha) / 255f, 1f * (255 - Projectile.alpha) / 255f, 1f * (255 - Projectile.alpha) / 255f, 0.6f * (255 - Projectile.alpha) / 255f));
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.penetrate--;
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                base.Projectile.ai[0] += 0.1f;
                if (base.Projectile.velocity.X != oldVelocity.X)
                {
                    base.Projectile.velocity.X = -oldVelocity.X * 0.25f;
                }
                if (base.Projectile.velocity.Y != oldVelocity.Y)
                {
                    base.Projectile.velocity.Y = -oldVelocity.Y * 0.25f;
                }
            }
            return false;
        }
    }
}