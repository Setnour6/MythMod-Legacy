using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.BloodyTusk
{
    public class CrimsonTusk1plus : ModProjectile
    {
        private bool initialization = true;
        private bool initialization2 = true;
        private float X;
        private float Y;
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("CrimsonTusk");
        }
        public override void SetDefaults()
        {
            base.Projectile.width = 8;
            base.Projectile.height = 100;
            base.Projectile.hostile = false;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = -1;
            base.Projectile.timeLeft = 100;
            Projectile.alpha = 255;
            base.Projectile.tileCollide = true;
        }
        public Texture2D[] T = new Texture2D[8];
        public int n = 0;
        public Vector2 drawPos = new Vector2(0, 50);
        public override void AI()
        {
            if (initialization2)
            {
                X = 0;
                initialization2 = false;
                Y = base.Projectile.Center.Y;
                n = Main.rand.Next(8);
            }

            if (Projectile.velocity.Y == 0 && X == 0)
            {
                for (int u = 0; u < 15; u++)
                {
                    int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y + 44f) + base.Projectile.velocity * 3f, 0, 0, 117, (float)Main.rand.Next(-2000, 2000) / 6000f, -6f, 0, default(Color), 1.1f);
                    Main.dust[r].noGravity = false;
                }
                base.Projectile.hostile = true;
                X = 1;
            }
            if (X == 1 && drawPos.Y < 0.05f)
            {
                drawPos.Y *= 0.9f;
            }
            if (drawPos.Y >= 0.05)
            {
                X = 2;
            }
            if (X == 2)
            {
                drawPos.Y += 0.5f;
                if (drawPos.Y > 52)
                {
                    Projectile.active = false;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.Projectile.velocity.X != oldVelocity.X)
            {
                base.Projectile.velocity.X = 0f;
            }
            if (base.Projectile.velocity.Y != oldVelocity.Y)
            {
                base.Projectile.velocity.Y = 0f;
            }
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            return false;
        }
    }
}
