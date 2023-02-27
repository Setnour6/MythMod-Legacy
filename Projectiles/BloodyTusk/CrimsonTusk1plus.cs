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
            base.DisplayName.SetDefault("CrimsonTusk");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 8;
            base.projectile.height = 100;
            base.projectile.hostile = false;
            base.projectile.friendly = false;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = -1;
            base.projectile.timeLeft = 100;
            projectile.alpha = 255;
            base.projectile.tileCollide = true;
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
                Y = base.projectile.Center.Y;
                n = Main.rand.Next(8);
            }

            if (projectile.velocity.Y == 0 && X == 0)
            {
                for (int u = 0; u < 15; u++)
                {
                    int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y + 44f) + base.projectile.velocity * 3f, 0, 0, 117, (float)Main.rand.Next(-2000, 2000) / 6000f, -6f, 0, default(Color), 1.1f);
                    Main.dust[r].noGravity = false;
                }
                base.projectile.hostile = true;
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
                    projectile.active = false;
                }
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (base.projectile.velocity.X != oldVelocity.X)
            {
                base.projectile.velocity.X = 0f;
            }
            if (base.projectile.velocity.Y != oldVelocity.Y)
            {
                base.projectile.velocity.Y = 0f;
            }
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return false;
        }
    }
}
